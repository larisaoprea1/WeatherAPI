using DataAccess.Entities;
using Interfaces.Querries;
using Interfaces.Querries.Services;
using Microsoft.EntityFrameworkCore;
using Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Querries
{
    public class AuthenticationQuery : IAuthenticationQuery
    {
        private readonly AuraDeityContext _auraDeityContext;
        private readonly IJwtQueryService _jwtQueryService;

        public AuthenticationQuery(AuraDeityContext auraDeityContext, IJwtQueryService jwtQueryService)
        {
            _auraDeityContext = auraDeityContext;
            _jwtQueryService = jwtQueryService;
        }

        public async Task<string> LoginIfUserExistsAsync(LoginModel loginModel)
        {
            try
            {
                var user = await _auraDeityContext.UserAuths.AsNoTracking().FirstOrDefaultAsync(e => e.Email == loginModel.Email.Trim().ToLower());
                if (user != null && IsPasswordCorrect(loginModel.Password, user.KeyPassword, user.HashPassword))
                {
                    return _jwtQueryService.GetJwtToken(user.Email, user.Id);
                }
                return string.Empty;
            }
            catch(Exception)
            {
                throw;
            }
        }
        private bool IsPasswordCorrect(string password, byte[] keyPassword,  byte[] hashedPassword)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(keyPassword))
            { 
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for(int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != hashedPassword[i])
                    {
                        return false;
                    }    
                }
                return true;
            }

        }
    }
}
