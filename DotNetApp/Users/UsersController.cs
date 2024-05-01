using DotNetApp.Core;
using DotNetApp.Core.attribute;
using DotNetApp.Users.Dto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DotNetApp.Users;

[Public]
[ApiController]
[Route("api/users")]
public class UsersController(UsersService usersService) : Controller
{
    [HttpGet]
    [SwaggerOperation(Summary = "Get all users", Description = "Get all users", OperationId = "GetUsers")]
    public async Task<ActionResult<Response<List<UserDto>>>> GetUsers()
    {
        return await usersService.GetUsers();
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get user by id", Description = "Get user by id", OperationId = "GetUser")]
    public async Task<ActionResult<Response<UserDto>>> GetUser(string id)
    {
        return await usersService.GetUserById(id);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create user", Description = "Create user", OperationId = "CreateUser")]
    public async Task<ActionResult<Response<UserDto>>> CreateUser([FromBody] CreateUserDto userDto)
    {
        return await usersService.CreateUser(userDto);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Update user", Description = "Update user", OperationId = "UpdateUser")]
    public async Task<ActionResult<Response<UserDto>>> UpdateUser(string id, [FromBody] UpdateUserDto userDto)
    {
        return await usersService.UpdateUser(id, userDto);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete user", Description = "Delete user", OperationId = "DeleteUser")]
    public async Task<ActionResult<Response<UserDto>>> DeleteUser([FromRoute] string id)
    {
        return await usersService.DeleteUser(id);
    }
}