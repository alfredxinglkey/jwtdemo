using OneNX.Demo.JWT.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneNX.Demo.JWT.API.Interface
{
   public interface IUserService
   {
      bool IsValid(LoginRequestDTO req);
   }
}
