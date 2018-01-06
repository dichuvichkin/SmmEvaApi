using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmmEvaApi.Models.User;
using SmmEvaApi.Services.UserService.Builders;
using SmmEvaApi.Context;
using SQLitePCL;

namespace SmmEvaApi.Services.UserService.Editors
{
    public class UserEditor : IUserEditor
    {
        private readonly UserContext _context;
        private readonly IEditUserBuilder _userBuilder;

        public UserEditor(
            UserContext context,
            IEditUserBuilder userBuilder
        )
        {
            _context = context;
            _userBuilder = userBuilder;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var newUser = new User
            {
                UserId = Guid.NewGuid(),
                Email = user.Email,
                Name = user.Name
            };
            var result = await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return _userBuilder.CreateUser(result);
        }
    }
}