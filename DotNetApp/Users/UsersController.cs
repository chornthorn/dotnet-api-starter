using DotNetApp.Core;
using DotNetApp.Core.attribute;
using DotNetApp.Users.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApp.Users;

[Public]
[ApiController]
[Route("api/users")]
public class UsersController(UsersService usersService): Controller
{
    [HttpGet]
    public async Task<ActionResult<Response<List<UserDto>>>> GetUsers()
    {
        return await usersService.GetUsers();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Response<UserDto>>> GetUser(string id)
    {
        return await usersService.GetUserById(id);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<UserDto>>> CreateUser([FromBody] CreateUserDto userDto)
    {
        return await usersService.CreateUser(userDto);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<Response<UserDto>>> UpdateUser(string id,[FromBody] UpdateUserDto userDto)
    {
       return await usersService.UpdateUser(id, userDto);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<Response<UserDto>>> DeleteUser([FromRoute] string id)
    {
        return await usersService.DeleteUser(id);
    }
}