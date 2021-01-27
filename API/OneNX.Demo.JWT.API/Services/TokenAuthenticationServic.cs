﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OneNX.Demo.JWT.API.DTO;
using OneNX.Demo.JWT.API.Interface;
using OneNX.Demo.JWT.API.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OneNX.Demo.JWT.API.Services
{
   public class TokenAuthenticationService : IAuthenticateService
   {
      private readonly IUserService _userService;
      private readonly TokenManagement _tokenManagement;

      public TokenAuthenticationService(IUserService userService, IOptions<TokenManagement> tokenManagement)
      {
         _userService = userService;
         _tokenManagement = tokenManagement.Value;
      }

      public bool IsAuthenticated(LoginRequestDTO request, out string token)
      {
         token = string.Empty;
         if (!_userService.IsValid(request))
            return false;
         var claims = new[]
         {
                new Claim(ClaimTypes.Name,request.Username)
            };
         var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
         var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
         var jwtToken = new JwtSecurityToken(_tokenManagement.Issuer, _tokenManagement.Audience, claims, expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration), signingCredentials: credentials);

         token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

         return true;

      }
   }
}
