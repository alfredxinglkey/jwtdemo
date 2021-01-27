using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneNX.Demo.JWT.API.DTO;
using OneNX.Demo.JWT.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Authorization;

namespace OneNX.Demo.JWT.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthenticateService authService;

		public AuthController(IAuthenticateService authService)
		{
			this.authService = authService;
		}

		[HttpPost]
		[Route("login")]
		[AllowAnonymous]
		public IActionResult Login([FromBody] LoginRequestDTO request)
		{
			
			string token;

			if (authService.IsAuthenticated(request, out token))
			{
				HttpContext.Response.Headers.Add("token", new StringValues(token));
				Response.Headers.Append("Access-Control-Expose-Headers", "token");
				return Ok(token);
			}

			return Ok();
		}

	}
}
