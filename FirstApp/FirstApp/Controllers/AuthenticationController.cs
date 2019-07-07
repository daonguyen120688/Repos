using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Models;
using FirstApp.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _authService;

        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authService = authenticateService;
        }

        /// <summary>
        /// Validate user and issue a token if validation is successful
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult RequestToken([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }

            string token;

            if(_authService.IsAuthenticated(request,out token))
            {
                return Ok(token);
            }

            return BadRequest("Invalid Request");

        }
    }
}