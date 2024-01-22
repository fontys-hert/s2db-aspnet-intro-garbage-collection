using GarbageCollection.Api.ViewModels;
using GarbageCollection.Core.Models;
using GarbageCollection.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GarbageCollection.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SchemaController : ControllerBase
    {
        private readonly SchemaService _service;

        public SchemaController()
        {
            _service = new SchemaService();
        }

        [HttpGet]
        public SchemasViewModel Get()
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

            return new SchemasViewModel
            {
                Companies = companies
            };
        }
    }
}
