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

    public IActionResult Index() // dit is een Action
    {
        IEnumerable<Schema> schemas = _service.GetAllSchemas();

        List<SchemaViewModel> companies = new List<SchemaViewModel>();
        foreach (var schema in schemas)
        {
            companies.Add(new SchemaViewModel
            {
                CompanyName = schema.CompanyName,
                LocationCompanyActive = schema.LocationCompanyActive
            });
        }

        SchemasViewModel viewModel = new SchemasViewModel
        {
            Companies = companies
        };

        return View(viewModel);
    }

    public IActionResult Details(string id)
    {
        Schema? schema = _service.GetSchemaBy(id);

        if (schema == null) return NotFound();

        List<EntryDetailsViewModel> entryDetailsViewModels = new List<EntryDetailsViewModel>();
        foreach (var entry in schema.Entries)
        {
            entryDetailsViewModels.Add(new EntryDetailsViewModel
            {
                Garbage = entry.Garbage,
                PickupTime = entry.PickupTime
            });
        }

        SchemaDetailsViewModel viewModel = new SchemaDetailsViewModel
        {
            CompanyName = schema.CompanyName,
            LocationCompanyActive = schema.LocationCompanyActive,
            Entries = entryDetailsViewModels
        };

        return View(viewModel);
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

        _service.AddSchema(new Schema(viewModel.CompanyName, viewModel.LocationCompanyActive));
        return RedirectToAction("Index");
    }
}