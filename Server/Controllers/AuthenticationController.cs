﻿using BaseLibrary.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController(IUserAccount _accountInterface) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> CreateAsync(Register user)
        {
            if(user == null)
            {
                return BadRequest("Model is empty");
            }
            else
            {
                var result = await _accountInterface.CreateAsync(user);
                return Ok(result);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> SignInAsync(Login user)
        {
            if(user == null)
            {
                return BadRequest("Model is empty");
            }
            else
            {
                var result = await _accountInterface.SignInAsync(user);
                return Ok(result);
            }
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshToken token)
        {
            if (token == null)
            {
                return BadRequest("Model is empty");
            }
            else
            {
                var result = await _accountInterface.RefreshTokenAsync(token);
                return Ok(result);
            }

        }
    }
}
