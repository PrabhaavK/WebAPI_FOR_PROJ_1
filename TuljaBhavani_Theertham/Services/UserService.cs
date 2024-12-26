using System.Threading.Tasks;
using TuljaBhavani_Theertham.Models;
using TuljaBhavani_Theertham.Repository;

namespace TuljaBhavani_Theertham.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<bool> RegisterUser(UserModel userModel)
        {
            return await _userRepository.AddUser(userModel);
        }
    }
}
