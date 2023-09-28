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
}