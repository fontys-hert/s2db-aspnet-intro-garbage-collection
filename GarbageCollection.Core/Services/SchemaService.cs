using GarbageCollection.Core.Models;

namespace GarbageCollection.Core.Services;

public class SchemaService
{
    private readonly Schema _rwmSchema = new("RWM",
        new SchemaEntry(Garbage.Paper, DateTime.Today.AddDays(1)),
        new SchemaEntry(Garbage.Organic, DateTime.Today.AddDays(3)),
        new SchemaEntry(Garbage.Pmd, DateTime.Today.AddDays(7)),
        new SchemaEntry(Garbage.Residual, DateTime.Today.AddDays(-1))
    );

    private readonly Schema _ganseWinkelSchema = new("Van Gansewinkel",
        new SchemaEntry(Garbage.Organic, DateTime.Today.AddDays(1)),
        new SchemaEntry(Garbage.Paper, DateTime.Today.AddDays(2)),
        new SchemaEntry(Garbage.Pmd, DateTime.Today.AddDays(4)),
        new SchemaEntry(Garbage.Residual, DateTime.Today.AddDays(7))
    );

    private readonly Schema _suezSchema = new("Suez",
        new SchemaEntry(Garbage.Pmd, DateTime.Today.AddDays(1)),
        new SchemaEntry(Garbage.Paper, DateTime.Today.AddDays(3)),
        new SchemaEntry(Garbage.Organic, DateTime.Today.AddDays(8)),
        new SchemaEntry(Garbage.Residual, DateTime.Today.AddDays(14))
    );


    public IEnumerable<Schema> GetAllSchemas()
    {
        return new List<Schema>
        {
            _rwmSchema,
            _ganseWinkelSchema,
            _suezSchema
        };
    }

    public Schema? GetSchemaBy(string name)
    {
        IEnumerable<Schema> schemas = GetAllSchemas();
        return schemas.FirstOrDefault(s => s.CompanyName == name);
    }
}