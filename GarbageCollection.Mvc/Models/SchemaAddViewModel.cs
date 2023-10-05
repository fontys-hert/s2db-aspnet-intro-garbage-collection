namespace GarbageCollection.Mvc.Models;

public class SchemaAddViewModel
{
    public required string CompanyName { get; set; }
    public required string LocationCompanyActive { get; set; }
    
    public required List<SchemaEntryAddViewModel> Entries { get; set; }
}
