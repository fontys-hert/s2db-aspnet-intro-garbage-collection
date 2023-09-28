using GarbageCollection.Core.Models;
using GarbageCollection.Core.Services;
using GarbageCollection.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace GarbageCollection.Mvc.Controllers;

public class SchemaController : Controller
{
    private readonly SchemaService _service = new SchemaService();
    
    // GET
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

    [HttpGet("{name}")]
    public IActionResult Details(string name)
    {
        Schema? schema = _service.GetSchemaBy(name);

        if (schema == null) return NotFound();

        return View(schema);
    }
}