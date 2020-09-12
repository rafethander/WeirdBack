using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeirdBack.Dtos;
using WeirdBack.Helper;
using WeirdBack.Services;

namespace WeirdBack.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class LoginController:ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }



        //POST: api/Login/Check
        [HttpPost("Check")]
        public async Task<IActionResult> Check([FromBody]LoginDtos model)
        {
            var result = await _loginService.Login(model);

            if (result.Message != ApiResultMessages.Ok)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
