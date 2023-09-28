using GarbageCollection.Core.Models;

namespace GarbageCollection.RazorPages.ViewModels;

public class EntryDetailsViewModel
{
    public required Garbage Garbage { get; set; }
    public required DateTime PickupTime { get; set; }
}