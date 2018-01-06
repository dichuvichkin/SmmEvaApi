using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SmmEvaApi.Models.User;
using SmmEvaApi.Models.User.Builders;
using SmmEvaApi.Services.UserService.Editors;

namespace SmmEvaApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowCoursesClient")]
    public class UserController : Controller
    {
        private readonly IUserBuilder _userBuilder;
        private readonly IUserEditor _userEditor;

        public UserController(
            IUserBuilder userBuilder,
            IUserEditor userEditor
        )
        {
            _userBuilder = userBuilder;
            _userEditor = userEditor;
        }

        public ActionResult Get(string email)
        {
            var user = _userBuilder.Build(email);
            return Json(user);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] User user)
        {
            var result = await _userEditor.CreateUserAsync(user);
            return Json(result);
        }
    }
}