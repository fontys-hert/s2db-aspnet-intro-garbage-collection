using System.ComponentModel.DataAnnotations;
using GarbageCollection.Core.Models;

namespace GarbageCollection.Mvc.Models;

public class SchemaEntryAddViewModel
{
    [Required] public Garbage Garbage { get; set; }
    [Required] public DateTime PickupDate { get; set; }
}