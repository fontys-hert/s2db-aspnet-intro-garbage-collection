using GarbageCollection.DataAccess.dtos;

namespace GarbageCollection.Core.Models;

public class Schema
{
    private readonly List<SchemaEntry> _entries;

    public string CompanyName { get; private set; }
    public string LocationCompanyActive { get; private set; }

    public IReadOnlyList<SchemaEntry> Entries => _entries.AsReadOnly();

    public Schema(string companyName, string locationCompanyActive, params SchemaEntry[] entries)
    {
        CompanyName = companyName;
        LocationCompanyActive = locationCompanyActive;
        _entries = entries.ToList();
    }

    public static Schema From(SchemaDto dto)
    {
        return new Schema(dto.CompanyName, dto.LocationCompanyActive, dto.Entries.Select(SchemaEntry.From).ToArray());
    }
}