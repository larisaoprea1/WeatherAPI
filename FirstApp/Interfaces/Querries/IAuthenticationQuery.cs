using Models.Authentication;


namespace Interfaces.Querries
{
    public interface IAuthenticationQuery { 
    
        Task<string> LoginIfUserExistsAsync(LoginModel loginModel);
    }
}
