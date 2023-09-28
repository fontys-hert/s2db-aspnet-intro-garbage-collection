using GarbageCollection.Core.Models;
using GarbageCollection.Core.Services;
using GarbageCollection.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace GarbageCollection.Mvc.Controllers;

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
}