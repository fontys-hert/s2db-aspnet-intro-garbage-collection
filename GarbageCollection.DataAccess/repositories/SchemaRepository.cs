using System.Text.Json;
using GarbageCollection.DataAccess.dtos;

namespace GarbageCollection.DataAccess.repositories;

public class SchemaRepository
{
    private readonly string _location = "db-schema.json";

    public IEnumerable<SchemaDto> GetAll()
    {
        if (!File.Exists(_location)) return new List<SchemaDto>();
        string contents = File.ReadAllText(_location);
        return JsonSerializer.Deserialize<List<SchemaDto>>(contents) ?? new List<SchemaDto>();
    }

    public SchemaDto? GetBy(string name)
    {
        IEnumerable<SchemaDto> schemas = GetAll();

        return schemas.FirstOrDefault(s => s.CompanyName == name);
    }

    public void Add(SchemaDto schema)
    {
        List<SchemaDto> schemas = GetAll().ToList();
        
        schemas.Add(schema);

        string json = JsonSerializer.Serialize(schemas);
        File.WriteAllText(_location, json);
    }
}