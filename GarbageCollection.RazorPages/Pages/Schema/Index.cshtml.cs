using GarbageCollection.Core.Services;
using GarbageCollection.RazorPages.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GarbageCollection.RazorPages.Pages.Schema;

public class Index : PageModel
{
    private readonly SchemaService _service = new();
    public required SchemasViewModel Model { get; set; }

    public void OnGet()
    {
        IEnumerable<Core.Models.Schema> schemas = _service.GetAllSchemas();

        List<string> companyNames = new List<string>();
        foreach (var schema in schemas)
        {
            companyNames.Add(schema.CompanyName);
        }

        Model = new SchemasViewModel
        {
            CompanyNames = companyNames
        };
    }
}