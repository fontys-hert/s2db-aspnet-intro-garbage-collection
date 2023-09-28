using GarbageCollection.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GarbageCollection.RazorPages.Pages.Schema;

public class Details : PageModel
{
    private readonly SchemaService _service = new();
    public required Core.Models.Schema Model { get; set; }

    public IActionResult OnGet(string id)
    {
        Core.Models.Schema? schema = _service.GetSchemaBy(id);

        if (schema == null) return NotFound();

        Model = schema;
        return Page();
    }
}