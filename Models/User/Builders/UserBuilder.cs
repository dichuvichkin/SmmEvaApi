using System.Linq;
using SmmEvaApi.Context;

namespace SmmEvaApi.Models.User.Builders
{
    public class UserBuilder : IUserBuilder
    {
        private readonly UserContext _context;

        public UserBuilder(UserContext context)
        {
            _context = context;
        }

        public User Build(string email)
        {
            var user = _context.Users.Single(u => u.Email == email);

            return new User
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}