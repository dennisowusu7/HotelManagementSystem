using BaseLibrary.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityQuestionController(ISecurityQuestion _securityQuestionInterface) : ControllerBase
    {
        [HttpPost("question")]
        public async Task<IActionResult> CreateAsync(SecurityQuestion question)
        {
            if (question == null)
            {
                return BadRequest("Model is empty");
            }
            else
            {
                var result = await _securityQuestionInterface.CreateAsync(question);
                return Ok(result);
            }
        }
    }
}
