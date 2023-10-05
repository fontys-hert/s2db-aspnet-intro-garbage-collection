using GarbageCollection.Core.Models;

namespace GarbageCollection.RazorPages.ViewModels;

public class SchemaEntryAddViewModel
{
    public required Garbage Garbage { get; set; }
    public required DateTime PickupDate { get; set; }
}