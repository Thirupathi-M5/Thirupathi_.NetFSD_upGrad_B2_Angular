using DAL.Models;
using UpgradEventAPI.Models;

namespace UpgradEventAPI.Services
{
    public interface IUserService
    {
        string Register(UserRegisterRequest request);

        List<UserInfo> GetAllUsers();
    }
}