using GarbageCollection.Core.Models;

namespace GarbageCollection.Core.Services;

public class SchemaService
{
    private static readonly List<Schema> _schemas = new();

    private readonly Schema _rwmSchema = new("RWM", "Zuid Nederland",
        new SchemaEntry(Garbage.Paper, DateTime.Today.AddDays(1)),
        new SchemaEntry(Garbage.Organic, DateTime.Today.AddDays(3)),
        new SchemaEntry(Garbage.Pmd, DateTime.Today.AddDays(7)),
        new SchemaEntry(Garbage.Residual, DateTime.Today.AddDays(-1))
    );

    private readonly Schema _ganseWinkelSchema = new("Van Gansewinkel", "Midden Nederland",
        new SchemaEntry(Garbage.Organic, DateTime.Today.AddDays(1)),
        new SchemaEntry(Garbage.Paper, DateTime.Today.AddDays(2)),
        new SchemaEntry(Garbage.Pmd, DateTime.Today.AddDays(4)),
        new SchemaEntry(Garbage.Residual, DateTime.Today.AddDays(7))
    );

    private readonly Schema _suezSchema = new("Suez", "Noord Nederland",
        new SchemaEntry(Garbage.Pmd, DateTime.Today.AddDays(1)),
        new SchemaEntry(Garbage.Paper, DateTime.Today.AddDays(3)),
        new SchemaEntry(Garbage.Organic, DateTime.Today.AddDays(8)),
        new SchemaEntry(Garbage.Residual, DateTime.Today.AddDays(14))
    );

    public SchemaService()
    {
        if (!_schemas.Any())
        {
            _schemas.Add(_rwmSchema);
            _schemas.Add(_ganseWinkelSchema);
            _schemas.Add(_suezSchema);
        }
    }

    public IEnumerable<Schema> GetAllSchemas()
    {
        return _schemas;
    }

    public Schema? GetSchemaBy(string name)
    {
        return _schemas.FirstOrDefault(s => s.CompanyName == name);
    }

    public string? AddSchema(Schema schema)
    {
        if (_schemas.Any(s => s.CompanyName == schema.CompanyName))
        {
            return "Company already exists";
        }

        _schemas.Add(schema);
        return null;
    }
}