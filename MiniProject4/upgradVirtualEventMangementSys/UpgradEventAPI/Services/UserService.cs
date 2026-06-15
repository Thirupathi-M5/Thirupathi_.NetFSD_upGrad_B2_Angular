using DAL.DataAccess;
using DAL.Models;
using UpgradEventAPI.Models;

namespace UpgradEventAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserInfoService _userInfoService;

        public UserService(UserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public string Register(UserRegisterRequest request)
        {
            try
            {
                if (_userInfoService.IsEmailExists(request.EmailId))
                    return "User already exists";

                var user = new UserInfo
                {
                    EmailId = request.EmailId,
                    Password = request.Password,
                    Role = request.Role,
                    UserName = request.EmailId 
                };

                _userInfoService.AddUser(user);

                return "User registered successfully";
            }
            catch
            {
                return "Something went wrong while registering user";
            }
        }

        public List<UserInfo> GetAllUsers()
        {
            return _userInfoService.GetAllUsers();
        }
    }
}