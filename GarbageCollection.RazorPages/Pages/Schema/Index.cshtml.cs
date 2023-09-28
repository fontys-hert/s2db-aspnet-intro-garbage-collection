using GarbageCollection.Core.Services;
using GarbageCollection.RazorPages.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GarbageCollection.RazorPages.Pages.Schema;

// Interessante documentatie:
// Alles wat je kunt doen met razor syntax: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-7.0#razor-syntax
// Wat je kunt doet met "asp-", ook wel tag helpers genoemd: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/?view=aspnetcore-7.0
//   - Bijvoorbeeld voor navigatie: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/anchor-tag-helper?view=aspnetcore-7.0
//   - Bijvoorbeeld voor forms: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/working-with-forms?view=aspnetcore-7.0#the-input-tag-helper

public class Index : PageModel
{
    private readonly SchemaService _service = new();
    public required SchemasViewModel ViewModel { get; set; }

    public void OnGet()
    {
        IEnumerable<Core.Models.Schema> schemas = _service.GetAllSchemas();

        List<string> companyNames = new List<string>();
        foreach (var schema in schemas)
        {
            companyNames.Add(schema.CompanyName);
        }

        ViewModel = new SchemasViewModel
        {
            CompanyNames = companyNames
        };
    }
}