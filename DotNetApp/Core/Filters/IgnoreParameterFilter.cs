namespace DotNetApp.Core.Filters;

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

public class IgnoreParameterFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var ignoredParameters = new[] { "userData" };

        foreach (var parameter in ignoredParameters)
        {
            var parameterToRemove = operation.Parameters.SingleOrDefault(p => p.Name == parameter);

            if (parameterToRemove != null)
            {
                operation.Parameters.Remove(parameterToRemove);
            }
        }
    }
}