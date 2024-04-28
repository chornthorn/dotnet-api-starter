using DotNetApp.Core;
using DotNetApp.Core.attribute;
using DotNetApp.Core.Enum;
using DotNetApp.Simples.Dto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DotNetApp.Simples;

[ApiController]
[Route("api/simples")]
[RequiredAuth]
[SwaggerTag("Simples CRUD operations")]
public class SimplesController(SimplesService simplesService) : Controller
{
    [HttpGet]
    [Policy(resource: "simples", scope: Scope.Reads)]
    [SwaggerOperation(
        Summary = "Get all simples",
        Description = "Get all simples",
        OperationId = "Simples.GetAll"
    )]
    [ProducesResponseType(typeof(Response<List<SimpleDto>>), StatusCodes.Status200OK)]
    public async Task<ActionResult<Response<List<SimpleDto>>>> GetAllAsync()
    {
        return await simplesService.FindAllAsync();
    }

    [HttpGet("{id}")]
    [Policy(resource: "simples", scope: Scope.Read)]
    [SwaggerOperation(
        Summary = "Get simple by id",
        Description = "Get simple by id",
        OperationId = "Simples.GetById"
    )]
    public async Task<ActionResult<Response<SimpleDto>>> GetByIdAsync([FromRoute] int id)
    {
        return await simplesService.FindByIdAsync(id);
    }

    [HttpPost]
    [Policy(resource: "simples", scope: Scope.Create)]
    [SwaggerOperation(
        Summary = "Create simple",
        Description = "Create simple",
        OperationId = "Simples.Create"
    )]
    public async Task<ActionResult<Response<SimpleDto>>> CreateAsync([FromBody] CreateSimpleDto dto)
    {
        return await simplesService.CreateAsync(dto);
    }

    [HttpPut("{id}")]
    [Policy(resource: "simples", scope: Scope.Update)]
    [SwaggerOperation(
        Summary = "Update simple",
        Description = "Update simple",
        OperationId = "Simples.Update"
    )]
    public async Task<ActionResult<Response<SimpleDto>>> UpdateAsync([FromRoute] int id, [FromBody] UpdateSimpleDto dto)
    {
        return await simplesService.UpdateAsync(id, dto);
    }

    [HttpDelete("{id}")]
    [Policy(resource: "simples", scope: Scope.Delete)]
    [SwaggerOperation(
        Summary = "Delete simple",
        Description = "Delete simple",
        OperationId = "Simples.Delete"
    )]
    public async Task<ActionResult<Response<SimpleDto>>> DeleteAsync([FromRoute] int id)
    {
        return await simplesService.DeleteAsync(id);
    }
}