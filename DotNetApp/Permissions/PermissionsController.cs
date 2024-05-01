using DotNetApp.Core.attribute;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApp.Permissions;

[Public]
[ApiController]
[Route("api/permissions")]
public class PermissionsController(PermissionsService permissionsService)
{
    [HttpGet]
    public async Task<ActionResult<List<string>>> GetPermissionsAsync()
    {
        var permissions = await permissionsService.GetPermissionsAsync();
        return permissions;
    }
}