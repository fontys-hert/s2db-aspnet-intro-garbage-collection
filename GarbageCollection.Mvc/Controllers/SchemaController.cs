using GarbageCollection.Core.Models;
using GarbageCollection.Core.Services;
using GarbageCollection.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace GarbageCollection.Mvc.Controllers;

// Interessante documentatie:
// Alles wat je kunt doen met razor syntax: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-7.0#razor-syntax
// Wat je kunt doet met "asp-", ook wel tag helpers genoemd: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/?view=aspnetcore-7.0
//   - Bijvoorbeeld voor navigatie: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/anchor-tag-helper?view=aspnetcore-7.0
//   - Bijvoorbeeld voor forms: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/working-with-forms?view=aspnetcore-7.0#the-input-tag-helper

public class SchemaController : Controller
{
    private readonly SchemaService _service;

    public SchemaController()
    {
        _service = new SchemaService();
    }

    public IActionResult Index()
    {
        IEnumerable<Schema> schemas = _service.GetAllSchemas();

        List<string> companyNames = new List<string>();
        foreach (var schema in schemas)
        {
            companyNames.Add(schema.CompanyName);
        }

        SchemasViewModel viewModel = new SchemasViewModel
        {
            CompanyNames = companyNames
        };

        return View(viewModel);
    }

    public IActionResult Details(string id)
    {
        Schema? schema = _service.GetSchemaBy(id);

        if (schema == null) return NotFound();

        return View(schema);
    }

    public IActionResult New()
    {
        return View();
    }

    [HttpPost]
    public IActionResult New(SchemaAddViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        
        _service.AddSchema(new Schema(viewModel.CompanyName));
        return RedirectToAction("Index");
    }
}