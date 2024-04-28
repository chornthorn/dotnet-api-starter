namespace DotNetApp.Core.Enum;

public enum Scope
{
    None,
    Read,
    Reads,
    Create,
    Update,
    Delete
}

public static class ScopeExtensions
{
    private static readonly Dictionary<Scope, string> ScopeToString = new()
    {
        { Scope.None, "none" },
        { Scope.Read, "read" },
        { Scope.Reads, "reads" },
        { Scope.Create, "create" },
        { Scope.Update, "update" },
        { Scope.Delete, "delete" }
    };

    public static string AsString(this Scope scope)
    {
        return ScopeToString[scope];
    }

    public static Scope FromString(string scope)
    {
        return ScopeToString.FirstOrDefault(x => x.Value == scope).Key;
    }

    public static bool IsValidScope(string scope)
    {
        return ScopeToString.Any(x => x.Value == scope);
    }
}