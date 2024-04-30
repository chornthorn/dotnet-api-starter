using DotNetApp.Core.attribute;
using DotNetApp.Core.Enum;
using DotNetApp.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DotNetApp.Category;

[ApiController]
[Route("api/categories")]
public class CategoryController : Controller
{
    [Public]
    [HttpGet]
    [AuthPolicy(resource: "category", scope: Scope.Reads)]
    [SwaggerOperation(
        Summary = "Get all categories",
        Description = "Get all categories",
        OperationId = "GetCategories"
    )]
    public IActionResult Get()
    {
        throw new UnauthorizedException("Bad Request Exception Test");
    }

    [Public]
    [HttpGet("{id}")]
    [AuthPolicy(resource: "category", scope: Scope.Read)]
    [SwaggerOperation(
        Summary = "Get category by id",
        Description = "Get category by id",
        OperationId = "GetCategoryById"
    )]
    public IActionResult Get(int id)
    {
        if (id == 1)
        {
            throw new UnprocessableEntityException("Unprocessable Entity Exception Test");
        }
        else
        {
            throw new NotFoundException("Category not found");
        }
    }

    [HttpPost]
    [AuthPolicy(resource: "category", scope: Scope.Create)]
    [SwaggerOperation(
        Summary = "Create a new category",
        Description = "Create a new category",
        OperationId = "CreateCategory"
    )]
    public IActionResult Post()
    {
        return Ok("Create a new category");
    }

    [HttpPut("{id}")]
    [AuthPolicy(resource: "category", scope: Scope.Update)]
    [SwaggerOperation(
        Summary = "Get all categories",
        Description = "Get all categories",
        OperationId = "GetCategories"
    )]
    public IActionResult Put(int id)
    {
        return Ok($"Update category by id: {id}");
    }

    [HttpDelete("{id}")]
    [AuthPolicy(resource: "category", scope: Scope.Delete)]
    [SwaggerOperation(
        Summary = "Delete category by id",
        Description = "Delete category by id",
        OperationId = "DeleteCategory"
    )]
    public IActionResult Delete(int id)
    {
        return Ok($"Delete category by id: {id}");
    }
}