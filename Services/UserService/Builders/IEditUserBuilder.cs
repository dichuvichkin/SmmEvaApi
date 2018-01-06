using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmmEvaApi.Models.User;

namespace SmmEvaApi.Services.UserService.Builders
{
    public interface IEditUserBuilder
    {
        User CreateUser(EntityEntry<User> user);
    }
}