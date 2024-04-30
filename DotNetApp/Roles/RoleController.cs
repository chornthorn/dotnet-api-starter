using DotNetApp.Core;
using DotNetApp.Core.attribute;
using DotNetApp.Roles.Dto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DotNetApp.Roles;

[Public]
[ApiController]
[Route("api/roles")]
public class RoleController(RoleService roleService) : Controller
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all roles",
        Description = "Get all roles",
        OperationId = "GetRoles"
    )]
    public async Task<ActionResult<Response<List<RoleDto>>>> GetRoles()
    {
        return await roleService.GetRoles();
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get role by id",
        Description = "Get role by id",
        OperationId = "GetRole"
    )]
    public async Task<ActionResult<Response<RoleDto>>> GetRole(int id)
    {
        return await roleService.GetRole(id);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create role",
        Description = "Create role",
        OperationId = "CreateRole"
    )]
    public async Task<ActionResult<Response<RoleDto>>> CreateRole([FromBody] CreateRoleDto dto)
    {
        return await roleService.CreateRole(dto);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update role",
        Description = "Update role",
        OperationId = "UpdateRole"
    )]
    public async Task<ActionResult<Response<RoleDto>>> UpdateRole(int id, [FromBody] UpdateRoleDto dto)
    {
        return await roleService.UpdateRole(id, dto);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete role",
        Description = "Delete role",
        OperationId = "DeleteRole"
    )]
    public async Task<ActionResult<Response<RoleDto>>> DeleteRole(int id)
    {
        return await roleService.DeleteRole(id);
    }
}