

using BaseLibrary.DTOs;
using BaseLibrary.Responses;

namespace ServerLibrary.Repositories.Contracts
{
    public interface ISecurityQuestion
    {
        Task<GeneralResponse> CreateAsync(SecurityQuestion securityQuestion);
    }
}
