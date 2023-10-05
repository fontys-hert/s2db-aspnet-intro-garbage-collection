using GarbageCollection.Core.Services;
using GarbageCollection.DataAccess.repositories;
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
    private readonly SchemaService _service = new(new SchemaRepository());
    public required SchemasViewModel ViewModel { get; set; }

    public void OnGet()
    {
        IEnumerable<Core.Models.Schema> schemas = _service.GetAll();

        List<SchemaViewModel> companies = new List<SchemaViewModel>();
        foreach (var schema in schemas)
        {
            companies.Add(new SchemaViewModel
            {
                CompanyName = schema.CompanyName,
                LocationCompanyActive = schema.LocationCompanyActive
            });
        }

        ViewModel = new SchemasViewModel
        {
            Companies = companies
        };
    }
}