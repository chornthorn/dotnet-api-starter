using DotNetApp.Core.attribute;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DotNetApp.Permissions;

[Public]
[ApiController]
[Route("api/permissions")]
public class PermissionsController(PermissionsService permissionsService)
{
    [HttpGet]
    [SwaggerOperation(Summary = "Get all permissions", Description = "Get all permissions",
        OperationId = "GetPermissions")]
    public async Task<ActionResult<List<string>>> GetPermissionsAsync()
    {
        var permissions = await permissionsService.GetPermissionsAsync();
        return permissions;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Add permission", Description = "Add permission", OperationId = "AddPermission")]
    public ActionResult<string> AddPermissionAsync()
    {
        return "Permission added";
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update permission",
        Description = "Update permission",
        OperationId = "UpdatePermission"
    )]
    public ActionResult<string> UpdatePermissionAsync(string id)
    {
        return "Permission updated";
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete permission", Description = "Delete permission",
        OperationId = "DeletePermission")]
    public ActionResult<string> DeletePermissionAsync(string id)
    {
        return "Permission deleted";
    }
}