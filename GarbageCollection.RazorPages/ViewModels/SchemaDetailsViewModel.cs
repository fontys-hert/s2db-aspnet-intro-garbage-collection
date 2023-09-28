namespace GarbageCollection.RazorPages.ViewModels;

public class SchemaDetailsViewModel
{
    public required string CompanyName { get; set; }
    public required string LocationCompanyActive { get; set; }
    public required IEnumerable<EntryDetailsViewModel> Entries { get; set; }
}