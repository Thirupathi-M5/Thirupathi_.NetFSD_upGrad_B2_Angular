using UpgradEventAPI.Models;

namespace UpgradEventAPI.Services
{
    public interface IAuthService
    {
        Task<string> Login(string email, string password);

       
    }
}