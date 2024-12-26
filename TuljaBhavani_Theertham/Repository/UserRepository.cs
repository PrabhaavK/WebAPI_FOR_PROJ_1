using System.Threading.Tasks;
using TuljaBhavani_Theertham.Models;
using Microsoft.EntityFrameworkCore;

namespace TuljaBhavani_Theertham.Repository
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidateUser(string username, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
            return user != null;
        }

        public async Task<bool> AddUser(UserModel userModel)
        {
            var user = new User
            {
                Name = userModel.Name,
                UserName = userModel.UserName,
                Password = userModel.Password,
                Email = userModel.Email,
                Mobile = userModel.Mobile,
                Address = userModel.Address,
                Role = userModel.Role,
                AddharNo = userModel.AddharNo
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
