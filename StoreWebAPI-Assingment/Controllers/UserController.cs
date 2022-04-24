using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreWebAPI_Assingment.Keys;
using StoreWebAPI_Assingment.Models.User;
using StoreWebAPI_Assingment.Services;

namespace StoreWebAPI_Assingment.Controllers
{
    [Route("api/[controller]")]
    [UseApiKey]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequest request)
        {
            var user = await _service.CreateUserAsync(request);
            if (user != null)
            {
                return new OkObjectResult(user);
            }

            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return new OkObjectResult(await _service.GetUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _service.GetUserAsync(id);
            if (user != null)
            {
                return new OkObjectResult(user);
            }

            return new NotFoundResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UserRequest request)
        {
            var user = await _service.UpdateUserAsync(id, request);
            if (user != null)
            {
                return new OkObjectResult(user);
            }

            return new BadRequestResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            if (await _service.DeleteUserAsync(id))
            {
                return new OkResult();
            }

            return new BadRequestResult();
        }
    }
}
