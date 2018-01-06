using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SmmEvaApi.Models.User;
using SmmEvaApi.Services.UserService.Builders;
using SmmEvaApi.Context;

namespace SmmEvaApi.Services.UserService.Editors
{
    public class UserEditor : IUserEditor
    {
        private readonly UserContext _context;
        private readonly IEditUserBuilder _userBuilder;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserEditor(
            UserContext context,
            IEditUserBuilder userBuilder,
            IPasswordHasher<User> passwordHasher
        )
        {
            _context = context;
            _userBuilder = userBuilder;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var hashedPassword = _passwordHasher.HashPassword(user, user.Password);
            var newUser = new User
            {
                UserId = Guid.NewGuid(),
                Email = user.Email,
                Name = user.Name,
                Password = hashedPassword
            };
            var result = await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return _userBuilder.CreateUser(result);
        }
    }
}