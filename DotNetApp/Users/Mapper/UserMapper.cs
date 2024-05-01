using DotNetApp.Entities;
using DotNetApp.Users.Dto;

namespace DotNetApp.Users.Mapper;

public static class UserMapper
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }

    public static User ToEntity(this UserDto userDto)
    {
        return new User
        {
            Name = userDto.Name,
            Email = userDto.Email,
            Password = userDto.Password,
            Avatar = userDto.Avatar
        };
    }
    
    // convert to entity from CreateDto
    public static User FromCreateDto(this CreateUserDto createUserDto)
    {
        return new User
        {
            Id = createUserDto.Id,
            Name = createUserDto.Name,
            Email = createUserDto.Email,
            Password = createUserDto.Password,
            Avatar = createUserDto.Avatar
        };
    }
    
    // convert to entity from UpdateDto
    public static User FromUpdateDto(this UpdateUserDto updateUserDto)
    {
        return new User
        {
            Name = updateUserDto.Name,
            Password = updateUserDto.Password,
            Email = updateUserDto.Email,
            Avatar = updateUserDto.Avatar
        };
    }
}