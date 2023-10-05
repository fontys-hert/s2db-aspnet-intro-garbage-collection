using GarbageCollection.Core.Models;

namespace GarbageCollection.Mvc.Models;

public class EntryDetailsViewModel
{
    public required string Garbage { get; set; }
    public required string PickupTime { get; set; }
    
}