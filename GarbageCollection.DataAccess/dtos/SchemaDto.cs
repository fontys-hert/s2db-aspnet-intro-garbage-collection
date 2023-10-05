namespace GarbageCollection.DataAccess.dtos;

public class SchemaDto
{
    public string CompanyName { get; set; }
    public string LocationCompanyActive { get; set; }
    public IEnumerable<SchemaEntryDto> Entries { get; set; }
}