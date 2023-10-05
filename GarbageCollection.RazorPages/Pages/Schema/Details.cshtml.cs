using GarbageCollection.Core.Services;
using GarbageCollection.DataAccess.repositories;
using GarbageCollection.RazorPages.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GarbageCollection.RazorPages.Pages.Schema;

// Interessante documentatie:
// Alles wat je kunt doen met razor syntax: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-7.0#razor-syntax
// Wat je kunt doet met "asp-", ook wel tag helpers genoemd: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/?view=aspnetcore-7.0
//   - Bijvoorbeeld voor navigatie: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/anchor-tag-helper?view=aspnetcore-7.0
//   - Bijvoorbeeld voor forms: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/working-with-forms?view=aspnetcore-7.0#the-input-tag-helper

public class Details : PageModel
{
    private readonly SchemaService _service = new(new SchemaRepository());
    public required SchemaDetailsViewModel ViewModel { get; set; }

    public IActionResult OnGet(string id)
    {
        Core.Models.Schema? schema = _service.GetBy(id);

        if (schema == null) return NotFound();
        
        List<EntryDetailsViewModel> entryDetailsViewModels = new List<EntryDetailsViewModel>();
        foreach (var entry in schema.Entries)
        {
            entryDetailsViewModels.Add(new EntryDetailsViewModel
            {
                Garbage = entry.ToFriendlyGarbageName(),
                PickupTime = entry.ToFriendlyPickupDate()
            });
        }

        ViewModel = new SchemaDetailsViewModel
        {
            CompanyName = schema.CompanyName,
            LocationCompanyActive = schema.LocationCompanyActive,
            Entries = entryDetailsViewModels
        };

        return Page();
    }
}