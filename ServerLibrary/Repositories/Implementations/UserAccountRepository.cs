

using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServerLibrary.Data;
using ServerLibrary.Helpers;
using ServerLibrary.Repositories.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ServerLibrary.Repositories.Implementations
{
    public class UserAccountRepository(IOptions<JwtSection> _config, AppDbContext _appDbContext) : IUserAccount
    {
        public async Task<GeneralResponse> CreateAsync(Register user)
        {
            
            if(user == null)
            {
                return new GeneralResponse(false, "Model is empty");
            }

            
            var checkUserEmail = await CheckIfEmailIsRegisteredAlready(user.Email!);
            if (checkUserEmail != null) {
                return new GeneralResponse(false, "User already exist. Please try different one!");
            }

            var applicationUser = await AddToDatabase(new ApplicationUser()
            {
                Fullname = user.Fullname,
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
            });

            var checkIfAdminRoleAlreadyExist = await
                _appDbContext.SystemRoles.FirstOrDefaultAsync(x => x.Name!.Equals(Constants.Admin));
            if(checkIfAdminRoleAlreadyExist == null)
            {
                var createAdminRole = await AddToDatabase(new SystemRole()
                {
                    Name = Constants.Admin
                });

                await AddToDatabase(new UserRole()
                {
                   RoleId = createAdminRole.Id,
                   UserId = applicationUser.Id
                });

                return new GeneralResponse(true, "Account created successfully!");
            }

            var checkIfUserRoleAlreadyExist = await _appDbContext.SystemRoles.FirstOrDefaultAsync(x => x.Name!.Equals(Constants.User));
            SystemRole response = new();
            if(checkIfUserRoleAlreadyExist == null)
            {
                response = await AddToDatabase(new SystemRole()
                {
                    Name = Constants.User
                });

                await AddToDatabase(new UserRole()
                {
                   RoleId = response.Id,
                   UserId = applicationUser.Id
                });
            }
            else
            {
                await AddToDatabase(new UserRole()
                {
                   RoleId = checkIfUserRoleAlreadyExist.Id,
                   UserId = applicationUser.Id
                });
            }

            return new GeneralResponse(true, "Account created successfully!");
        }

        public async Task<LoginResponse> RefreshTokenAsync(RefreshToken token)
        {
            if(token == null)
            {
                return new LoginResponse(false, "Model is empty");
            }

            var getToken = await _appDbContext.RefreshTokenInfos.FirstOrDefaultAsync(x => x.Token!.Equals(token.Token));
            if(getToken == null)
            {
                return new LoginResponse(false, "Refresh token is required!");
            }

            var getUser = await _appDbContext.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == getToken.UserId);
            if (getUser == null) 
            {
                return new LoginResponse(false, "Refresh token cannot be generated because user not found!");
            }

            var userRole = await GetUserRole(getUser.Id);
            var roleName = await GetRoleName(userRole.RoleId);
            string jwtToken = GenerateToken(getUser, roleName.Name!);
            string refreshToken = GenerateRefreshToken();


            var updateRefreshToken = await _appDbContext.RefreshTokenInfos.FirstOrDefaultAsync(x => x.UserId == getUser!.Id);
            if (updateRefreshToken == null) 
            {
                return new LoginResponse(false, "Refresh token could not be generated because user has not signed in");
            }

            updateRefreshToken.Token = refreshToken;
            await _appDbContext.SaveChangesAsync();

            return new LoginResponse(true, "Token refreshed successfully!", jwtToken, refreshToken);
        }

        public async Task<LoginResponse> SignInAsync(Login user)
        {
            if(user == null)
            {
                return new LoginResponse(false, "Model is empty");
            }

            var applicationUser = await GetUserEmail(user.Email!);

            if (applicationUser == null) 
            {
                return new LoginResponse(false, "User does not exist in our record!");
            }

            if (!BCrypt.Net.BCrypt.Verify(user.Password, applicationUser.Password)) 
            {
                return new LoginResponse(false, "Invalid Password. Please try again!");
            }

            var getUserRole = await GetUserRole(applicationUser.Id);
            if (getUserRole == null) 
            {
                return new LoginResponse(false, "User role not found");
            }


            var getRoleName = await GetRoleName(getUserRole.RoleId);
            if (getRoleName == null) 
            {
                return new LoginResponse(false, "User role not found");
            }

            string jwtToken = GenerateToken(applicationUser, getRoleName!.Name!);
            string refreshToken = GenerateRefreshToken();

            //Save refresh token to the Database
            var getUser = await _appDbContext.RefreshTokenInfos.FirstOrDefaultAsync(x => x.UserId == applicationUser.Id);
            if(getUser != null)
            {
                getUser!.Token = refreshToken;
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                await AddToDatabase(new RefreshTokenInfo()
                {
                    Token = refreshToken,
                    UserId = applicationUser.Id
                }); 
            }

            return new LoginResponse(true, "Login successfully", jwtToken, refreshToken);
        }

        private async Task<ApplicationUser> CheckIfEmailIsRegisteredAlready(string email)
        {
            return await _appDbContext.ApplicationUsers.FirstOrDefaultAsync(x => x.Email!.ToLower()!.Equals(email!.ToLower()));
        }

        private async Task<T> AddToDatabase<T>(T model)
        {
            var result = _appDbContext.Add(model!);
            await _appDbContext.SaveChangesAsync();
            return (T)result.Entity;
        }

        private async Task<ApplicationUser> GetUserEmail(string email)
        {
            return await _appDbContext.ApplicationUsers.FirstOrDefaultAsync(x
                => x.Email!.ToLower().Equals(email!.ToLower()));
        }

        private async Task<UserRole> GetUserRole(int userId)
        {
            return await _appDbContext.UserRoles.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        private async Task<SystemRole> GetRoleName(int roleId)
        {
            return await _appDbContext.SystemRoles.FirstOrDefaultAsync(x => x.Id == roleId);
        }

        private static string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }

        private string GenerateToken(ApplicationUser user, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Value.Key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var userClaims = new[]
            {
              new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
              new Claim(ClaimTypes.Name, user.Fullname!),
              new Claim(ClaimTypes.Email, user.Email!),
              new Claim(ClaimTypes.Role, role!)
            };

            var token = new JwtSecurityToken(

                issuer: _config.Value.Issuer,
                audience: _config.Value.Audience,
                claims: userClaims,
                expires: DateTime.Now.AddSeconds(2),
                signingCredentials: credentials
                                          
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
