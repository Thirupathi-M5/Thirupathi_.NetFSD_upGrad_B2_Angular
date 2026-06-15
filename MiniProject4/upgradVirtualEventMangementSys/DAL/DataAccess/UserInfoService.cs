using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class UserInfoService
    {
        private readonly AddDbContext _context;

        //Dependency Injection constructor
        public UserInfoService(AddDbContext context)
        {
            _context = context;
        }

        
        public void AddUser(UserInfo user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        
        public List<UserInfo> GetAllUsers()
        {
            return _context.Users.ToList();
        }

       
        public UserInfo Login(string email, string password)
        {
            return _context.Users
                .FirstOrDefault(u => u.EmailId == email && u.Password == password); //linq
        }
        public bool IsEmailExists(string email)
        {
            return _context.Users.Any(u => u.EmailId == email);
        }
    }
}