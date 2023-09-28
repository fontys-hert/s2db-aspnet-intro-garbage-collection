using GarbageCollection.Core.Models;

namespace GarbageCollection.Mvc.Models;

public class EntryDetailsViewModel
{
    public required Garbage Garbage { get; set; }
    public required DateTime PickupTime { get; set; }
}