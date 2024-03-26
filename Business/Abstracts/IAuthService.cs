using Core.Entities.Concretes;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{

    public interface IAuthService
        {
            IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
            IDataResult<User> Login(UserForLoginDto userForLoginDto);
            IResult UserExists(string email);
            IDataResult<AccessToken> CreateAccessToken(User username);
        }
    
}
