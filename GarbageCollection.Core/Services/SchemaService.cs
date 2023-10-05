using GarbageCollection.Core.Models;
using GarbageCollection.DataAccess.dtos;
using GarbageCollection.DataAccess.repositories;

namespace GarbageCollection.Core.Services;

public class SchemaService
{
    private readonly SchemaRepository _repository;

    public SchemaService(SchemaRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Schema> GetAll()
    {
        IEnumerable<SchemaDto> schemaDtos = _repository.GetAll();
        List<Schema> schemas = schemaDtos.Select(Schema.From).ToList();
        return schemas;
    }

    public Schema? GetBy(string name)
    {
        SchemaDto? dto = _repository.GetBy(name);
        if (dto == null) return null;
        return Schema.From(dto);
    }

    public string? Add(Schema schema)
    {
        if (GetBy(schema.CompanyName) != null)
        {
            return "Company already exists";
        }

        SchemaDto dto = new SchemaDto
        {
            CompanyName = schema.CompanyName,
            LocationCompanyActive = schema.LocationCompanyActive,
            Entries = schema.Entries.Select(e => new SchemaEntryDto
            {
                Garbage = e.Garbage.ToString(),
                PickupTime = e.PickupTime
            }).ToList()
        };

        _repository.Add(dto);
        
        return null;
    }
}