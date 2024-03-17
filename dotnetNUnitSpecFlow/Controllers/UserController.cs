using Manager;
using Microsoft.AspNetCore.Mvc;

namespace dotnetNUnitSpecFlow.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("/GetUser")]
        public IActionResult GetUser()
        {
            var user = _userManager.GetUser();
            return Ok(user);
        }

        [HttpGet]
        [Route("/GetUserByIdAndFullname/{id}/{fullname}")]
        public IActionResult GetUserByIdAndFullname([FromRoute] int id, [FromRoute] string fullname)
        {
            var user = _userManager.GetUserByIdAndFullname(id, fullname);
            return Ok(user);
        }

        [HttpGet]
        [Route("/GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _userManager.GetUsers();
            return Ok(users);
        }
    }
}
