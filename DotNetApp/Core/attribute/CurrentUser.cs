using DotNetApp.Core.Bindings;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApp.Core.attribute;

public class UserData
{
    public string Id { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
}

public class CurrentUserAttribute() : ModelBinderAttribute(typeof(UserDataModelBinder));