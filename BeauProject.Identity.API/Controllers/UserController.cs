using BeauProject.Identity.Application.DTOs.User;
using BeauProject.Identity.Application.Features.UserType.Request.Command;
using BeauProject.Identity.Application.Features.UserType.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeauProject.Identity.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto createUserDto)
        {
            var result = await _mediator.Send(new RegisterUserRequest() { CreateUserDto = createUserDto });
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            var result = await _mediator.Send(new LoginUserRequest() { UserDto = userDto });

            if (string.IsNullOrEmpty(result.Data))
                return Unauthorized(result);

            return Ok(result);
        }

        [HttpGet("userInfo/{userName}")]
        public async Task<IActionResult> GetUser(string userName)
        {
            GetUserDto userDto = new GetUserDto() { UserName = userName };
            var result = await _mediator.Send(new GetUserRequest() { GetUserDto = userDto });

            if (result.Id == null)
                result = userDto;

            return Ok(result);
        }

        //----------------------------------------------------------------------------------//

        //private readonly IAuthService _authService;
        //public UserController(IAuthService authService)
        //{
        //    _authService = authService;
        //}

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var result = await _authService.LoginAsync(request);

        //    if (string.IsNullOrEmpty(result.Token))
        //        return Unauthorized(result);

        //    return Ok(result);
        //}

        //[HttpPost("register")]
        //public async Task Register([FromBody] UserDto request)
        //{
        //    await _authService.RegisterAsync(request);
        //}
    }
}
