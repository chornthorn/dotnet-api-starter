using DotNetApp.Core.attribute;

namespace DotNetApp.Permissions;

[Service]
public class PermissionsService(PermissionsRepository permissionsRepository)
{
    public async Task<List<string>> GetPermissionsAsync()
    {
        return await permissionsRepository.GetPermissionsAsync();
    }
}