using DotNetApp.Core.attribute;
using DotNetApp.Core.Context;
using DotNetApp.Entities;
using DotNetApp.Users.Dto;
using DotNetApp.Users.Mapper;
using Microsoft.EntityFrameworkCore;

namespace DotNetApp.Users;

[Injectable]
public class UsersRepository(AppDbContext dbContext)
{
    public async Task<User> GetUserById(string id)
    {
        return await dbContext.Users.FindAsync(id);
    }
    
    public async Task<List<User>> GetUsers()
    {
        return await dbContext.Users.ToListAsync();
    }
    
    public async Task<User> CreateUser(CreateUserDto createUserDto)
    {
        var user = createUserDto.FromCreateDto();
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
        return user;
    }
    
    public async Task<User> UpdateUser(string id, UpdateUserDto updateUserDto)
    {
        var user = await dbContext.Users.FindAsync(id);
        
        if (user == null)
        {
            throw new Exception("User not found");
        }
        
        user.Name = updateUserDto.Name;
        user.Email = updateUserDto.Email;
        user.Password = updateUserDto.Password;
        user.Avatar = updateUserDto.Avatar;
            
        await dbContext.SaveChangesAsync();
        return user;
    }
    
    public async Task<User> DeleteUser(string id)
    {
        var user = await dbContext.Users.FindAsync(id);
        
        if (user == null)
        {
            throw new Exception("User not found");
        }
        
        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync();
        return user;
    }
}