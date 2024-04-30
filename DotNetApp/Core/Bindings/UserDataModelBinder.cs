using DotNetApp.Core.attribute;

namespace DotNetApp.Core.Bindings;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

public class UserDataModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var httpContext = bindingContext.HttpContext;
        var userData = httpContext.Items["UserData"] as UserData;

        if (userData == null)
        {
            return Task.CompletedTask;
        }

        bindingContext.Result = ModelBindingResult.Success(userData);
        return Task.CompletedTask;
    }
}