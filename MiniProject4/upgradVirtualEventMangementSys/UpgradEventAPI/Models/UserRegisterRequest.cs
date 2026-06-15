namespace UpgradEventAPI.Models
{
    public class UserRegisterRequest
    {
        public string EmailId { get; set; }  //DTOs
        public string Password { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }   
    }
}