using DataAccess.Entities;
using Interfaces.Comands;
using Interfaces.Querries.Services;
using Microsoft.EntityFrameworkCore;
using Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Commands
{
    public class AuthenticationComand : IAuthenticationComand
    {
        private readonly AuraDeityContext _auraDeityContext;
        private readonly IJwtQueryService _jwtQueryService;

        public AuthenticationComand(AuraDeityContext auraDeityContext, IJwtQueryService jwtQueryService)
        {
            _auraDeityContext = auraDeityContext;
            _jwtQueryService = jwtQueryService;
        }
        public async Task<string> SignUpAsync(SignUpModel signUpModel)
        {
            try
            {
                var UserRegistered = await _auraDeityContext.UserAuths.AnyAsync(e => e.Email == e.Email.Trim().ToLower());
                /*if (UserRegistered)
                {
                    return "User already exist!";
                }*/
                ComputeHashPassword(signUpModel.Password, out byte[] keyPassword, out byte[] hashPassword);
                var userAuth = new UserAuthEntity
                {
                    Email = signUpModel.Email.Trim().ToLower(),
                    HashPassword = hashPassword,
                    KeyPassword = keyPassword,
                    CreatedDate = DateTime.Now
                };
                _auraDeityContext.UserAuths.Add(userAuth);
                var isSavedSuccessfully = await _auraDeityContext.SaveChangesAsync() > 0;
                return isSavedSuccessfully ? _jwtQueryService.GetJwtToken(userAuth.Email, userAuth.Id) : string.Empty;
            }
            catch
            {
                throw;
            }

        }
        private void ComputeHashPassword(string password, out byte[] keyPassword,out byte[] hashPassword)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                keyPassword = hmac.Key;
                hashPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
