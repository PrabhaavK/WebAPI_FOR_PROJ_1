using System.Threading.Tasks;
using TuljaBhavani_Theertham.Models;

namespace TuljaBhavani_Theertham.Services
{
    public interface IUserService
    {
        Task<bool> LoginUser(User user);
        Task<bool> RegisterUser(UserModel userModel);
    }
}
