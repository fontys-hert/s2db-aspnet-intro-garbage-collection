using GarbageCollection.Core.Models;
using GarbageCollection.Core.Services;
using GarbageCollection.DataAccess.repositories;
using GarbageCollection.RazorPages.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GarbageCollection.RazorPages.Pages.Schema;

public class New : PageModel
{
    private readonly SchemaService _service = new(new SchemaRepository());

    [BindProperty] public required SchemaAddViewModel ViewModel { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        SchemaEntry[] entries = ViewModel.Entries.Select(e => new SchemaEntry(e.Garbage, e.PickupDate)).ToArray();
        _service.Add(new Core.Models.Schema(ViewModel.CompanyName, ViewModel.LocationCompanyActive, entries));

        return RedirectToPage("/Schema/Index");
    }
}