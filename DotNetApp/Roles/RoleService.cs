using DotNetApp.Core;
using DotNetApp.Core.attribute;
using DotNetApp.Core.Exceptions;
using DotNetApp.Roles.Dto;
using DotNetApp.Roles.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApp.Roles;

[Injectable]
public class RoleService(RoleRepository roleRepository)
{
    public async Task<ActionResult<Response<List<RoleDto>>>> GetRoles()
    {
        try
        {
            var roles = await roleRepository.GetRoles();
            var rolesDto = roles.Select(role => role.ToDto()).ToList();

            return new Response<List<RoleDto>>
            {
                Data = rolesDto,
                Message = "Success",
            };
        }
        catch (Exception e)
        {
            return new Response<List<RoleDto>>
            {
                Data = null,
                Message = e.Message,
            };
        }
    }

    public async Task<ActionResult<Response<RoleDto>>> GetRole(int id)
    {
        try
        {
            var existingRole = await roleRepository.GetRole(id);
            if (existingRole == null)
            {
                throw new NotFoundException("Role not found");
            }

            var roleDto = existingRole.ToDto();
            return new Response<RoleDto>
            {
                Data = roleDto,
                Message = "Success",
            };
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }

    public async Task<ActionResult<Response<RoleDto>>> CreateRole(CreateRoleDto dto)
    {
        try
        {
            var role = dto.FromCreate();
            var createdRole = await roleRepository.CreateRole(role);
            var roleDto = createdRole.ToDto();

            return new Response<RoleDto>
            {
                Data = roleDto,
                Message = "Success",
            };
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }

    public async Task<ActionResult<Response<RoleDto>>> UpdateRole(int id, UpdateRoleDto dto)
    {
        try
        {
            var existingRole = await roleRepository.GetRole(id);
            if (existingRole == null)
            {
                throw new NotFoundException("Role not found");
            }

            var role = dto.FromUpdate();
            var updatedRole = await roleRepository.UpdateRole(id, role);
            var roleDto = updatedRole.ToDto();

            return new Response<RoleDto>
            {
                Data = roleDto,
                Message = "Success",
            };
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }

    public async Task<ActionResult<Response<RoleDto>>> DeleteRole(int id)
    {
        try
        {
            var existingRole = await roleRepository.GetRole(id);
            if (existingRole == null)
            {
                throw new NotFoundException("Role not found");
            }

            await roleRepository.DeleteRole(id);
            var roleDto = existingRole.ToDto();

            return new Response<RoleDto>
            {
                Data = roleDto,
                Message = "Success",
            };
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }
}