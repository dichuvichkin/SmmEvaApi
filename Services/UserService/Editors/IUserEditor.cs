using System.Threading.Tasks;
using SmmEvaApi.Models.User;

namespace SmmEvaApi.Services.UserService.Editors
{
    public interface IUserEditor
    {
        Task<User> CreateUserAsync(User user);
    }
}