using GarbageCollection.Core.Services;
using GarbageCollection.RazorPages.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GarbageCollection.RazorPages.Pages.Schema;

public class New : PageModel
{
    private readonly SchemaService _service = new();

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

        _service.AddSchema(new Core.Models.Schema(ViewModel.CompanyName, ViewModel.LocationCompanyActive));

        return RedirectToPage("/Schema/Index");
    }
}