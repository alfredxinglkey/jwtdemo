using OneNX.Demo.JWT.API.DTO;
using OneNX.Demo.JWT.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneNX.Demo.JWT.API.Services
{
   public class UserService : IUserService
   {
      //模拟测试，默认都是人为验证有效
      public bool IsValid(LoginRequestDTO req)
      {
         return true;
      }
   }
}
