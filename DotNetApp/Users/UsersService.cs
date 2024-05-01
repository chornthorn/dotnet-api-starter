using DotNetApp.Core;
using DotNetApp.Core.attribute;
using DotNetApp.Core.Exceptions;
using DotNetApp.Core.Helper;
using DotNetApp.Users.Dto;
using DotNetApp.Users.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApp.Users;

[Injectable]
public class UsersService(UsersRepository usersRepository)
{
    public async Task<ActionResult<Response<List<UserDto>>>> GetUsers()
    {
        try
        {
            var users = await usersRepository.GetUsers();
            var usersDto = users.Select(user => user.ToDto()).ToList();
            return new Response<List<UserDto>>
            {
                Data = usersDto,
                Message = "Retrieved users successfully",
            };
        }
        catch (Exception ex)
        {
            return new Response<List<UserDto>>
            {
                Data = [],
                Message = ex.Message,
            };
        }
    }
    
    public async Task<ActionResult<Response<UserDto>>> GetUserById(string id)
    {
        var user = await usersRepository.GetUserById(id);
        
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }
        
        return new Response<UserDto>
        {
            Data = user.ToDto(),
            Message = "Retrieved user successfully",
        };
    }
    
    public async Task<ActionResult<Response<UserDto>>> CreateUser(CreateUserDto createUserDto)
    {
        try
        {
            // generate a new guid
            var guid = NewGuid.GetGuid();
            createUserDto.Id = guid.ToString();
            
            // hash password
            var hashTextHelper = new HashTextHelper();
            createUserDto.Password = hashTextHelper.Hash(createUserDto.Password);
            
            var user = await usersRepository.CreateUser(createUserDto);
            return new Response<UserDto>
            {
                Data = user.ToDto(),
                Message = "User created successfully",
            };
        }
        catch (Exception ex)
        {
            throw new BadRequestException(ex.Message);
        }
    }
    
    public async Task<ActionResult<Response<UserDto>>> UpdateUser(string id, UpdateUserDto updateUserDto)
    {
        
        // check existing user
        var existingUser = await usersRepository.GetUserById(id);
        
        if (existingUser == null)
        {
            throw new NotFoundException("User not found");
        }
        
        try
        {
            // hash password
            if (updateUserDto.Password != null)
            {
                var hashTextHelper = new HashTextHelper();
                updateUserDto.Password = hashTextHelper.Hash(updateUserDto.Password);
            }

            if (updateUserDto.Password == null)
            {
                updateUserDto.Password = existingUser.Password;
            }

            if (updateUserDto.Name == null)
            {
               updateUserDto.Name = existingUser.Name;
            }
            
            if (updateUserDto.Avatar == null)
            {
                updateUserDto.Avatar = existingUser.Avatar;
            }

            if (updateUserDto.Email == null)
            {
                updateUserDto.Email = existingUser.Email;
            }

            var user = await usersRepository.UpdateUser(id, updateUserDto);
            return new Response<UserDto>
            {
                Data = user.ToDto(),
                Message = "User updated successfully"
            };
        } 
        catch (Exception ex)
        {
            throw new BadRequestException(ex.Message);
        }
    }
    
    public async Task<ActionResult<Response<UserDto>>>DeleteUser(string id)
    {
        // check existing user
        var existingUser = await usersRepository.GetUserById(id);
        
        if (existingUser == null)
        {
            throw new NotFoundException("User not found");
        }
        
        try
        {
            var user = await usersRepository.DeleteUser(id);
            return new Response<UserDto>
            {
                Data = user.ToDto(),
                Message = "User deleted successfully"
            };
        } 
        catch (Exception ex)
        {
            throw new BadRequestException(ex.Message);
        }
    }
}