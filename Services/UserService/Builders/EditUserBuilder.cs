using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmmEvaApi.Models.User;

namespace SmmEvaApi.Services.UserService.Builders
{
    public class EditUserBuilder : IEditUserBuilder
    {
        public User CreateUser(EntityEntry<User> user)
        {
            return new User
            {
                UserId = user.Entity.UserId,
                Email = user.Entity.Email,
                Name = user.Entity.Name
            };
        }
    }
}