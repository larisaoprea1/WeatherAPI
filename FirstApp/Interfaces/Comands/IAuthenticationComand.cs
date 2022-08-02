using Models.Authentication;


namespace Interfaces.Comands
{
    public interface IAuthenticationComand
    { 
        Task<string>  SignUpAsync(SignUpModel signUpModel);
    }
}
