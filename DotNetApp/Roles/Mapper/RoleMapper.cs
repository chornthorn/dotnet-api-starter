using DotNetApp.Entities;
using DotNetApp.Roles.Dto;

namespace DotNetApp.Roles.Mapper;

public static class RoleMapper
{
    public static RoleDto ToDto(this Role role)
    {
        return new RoleDto
        {
            Id = role.Id,
            Name = role.Name,
            Description = role.Description,
            CreatedAt = role.CreatedAt,
            UpdatedAt = role.UpdatedAt,
            DeletedAt = role.DeletedAt
        };
    }

    // from entity to dto
    public static Role ToEntity(this RoleDto roleDto)
    {
        return new Role
        {
            Id = roleDto.Id,
            Name = roleDto.Name,
            Description = roleDto.Description
        };
    }

    // from create role dto to entity
    public static Role FromCreate(this CreateRoleDto createRoleDto)
    {
        return new Role
        {
            Name = createRoleDto.Name,
            Description = createRoleDto.Description
        };
    }

    // from update role dto to entity
    public static Role FromUpdate(this UpdateRoleDto updateRoleDto)
    {
        return new Role
        {
            Id = updateRoleDto.Id,
            Name = updateRoleDto.Name,
            Description = updateRoleDto.Description
        };
    }
}