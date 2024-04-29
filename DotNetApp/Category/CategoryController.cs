using DotNetApp.Core.attribute;
using DotNetApp.Core.Enum;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DotNetApp.Category;

[ApiController]
[Route("api/categories")]
public class CategoryController : Controller
{
    [HttpGet]
    [Policy(resource: "category", scope: Scope.Reads)]
    [SwaggerOperation(
        Summary = "Get all categories",
        Description = "Get all categories",
        OperationId = "GetCategories"
    )]
    public IActionResult Get()
    {
        return Ok("Get all categories");
    }

    [HttpGet("{id}")]
    [Policy(resource: "category", scope: Scope.Read)]
    [SwaggerOperation(
        Summary = "Get category by id",
        Description = "Get category by id",
        OperationId = "GetCategoryById"
    )]
    public IActionResult Get(int id)
    {
        return Ok($"Get category by id: {id}");
    }

    [HttpPost]
    [Policy(resource: "category", scope: Scope.Create)]
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
    [Policy(resource: "category", scope: Scope.Update)]
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
    [Policy(resource: "category", scope: Scope.Delete)]
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