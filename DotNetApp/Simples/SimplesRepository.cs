using DotNetApp.Core.attribute;
using DotNetApp.Simples.Entities;

// ReSharper disable All

namespace DotNetApp.Simples;

public interface ISimplesRepository
{
    public Task<List<Simple>> FindAllAsync();
    public Task<Simple> FindByIdAsync(int id);
    public Task<Simple> CreateAsync(Simple simple);
    public Task<Simple> UpdateAsync(int id, Simple simple);
    public Task<Simple> DeleteAsync(int id);
}

[Injectable]
public class SimplesRepository : ISimplesRepository
{
    private static List<Simple> _simples =
    [
        new Simple { Id = 1, Name = "Simple 1" },
        new Simple { Id = 2, Name = "Simple 2" },
        new Simple { Id = 3, Name = "Simple 3" },
        new Simple { Id = 4, Name = "Simple 4" },
        new Simple { Id = 5, Name = "Simple 5" }
    ];

    public Task<List<Simple>> FindAllAsync()
    {
        return Task.FromResult(_simples);
    }

    public Task<Simple> FindByIdAsync(int id)
    {
        var simple = _simples.FirstOrDefault(s => s.Id == id);

        if (simple == null)
        {
            throw new Exception($"Simple with id {id} not found.");
        }

        return Task.FromResult(simple);
    }

    public Task<Simple> CreateAsync(Simple simple)
    {
        try
        {
            var maxId = _simples.Max(s => s.Id);
            simple.Id = maxId + 1;
            _simples.Add(simple);
            return Task.FromResult(simple);
        }
        catch (Exception e)
        {
            throw new Exception("Error creating simple.", e);
        }
    }

    public Task<Simple> UpdateAsync(int id, Simple simple)
    {
        var simpleToUpdate = _simples.FirstOrDefault(s => s.Id == id);

        if (simpleToUpdate == null)
        {
            throw new Exception($"Simple with id {id} not found.");
        }

        simpleToUpdate.Name = simple.Name;
        return Task.FromResult(simpleToUpdate);
    }

    public Task<Simple> DeleteAsync(int id)
    {
        var simpleToDelete = _simples.FirstOrDefault(s => s.Id == id);

        if (simpleToDelete == null)
        {
            throw new Exception($"Simple with id {id} not found.");
        }

        _simples.Remove(simpleToDelete);
        return Task.FromResult(simpleToDelete);
    }
}