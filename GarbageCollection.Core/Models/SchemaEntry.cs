namespace GarbageCollection.Core.Models;

public class SchemaEntry
{
    public Garbage Garbage { get; private set; }
    public DateTime PickupTime { get; private set; }

    public SchemaEntry(Garbage garbage, DateTime pickupTime)
    {
        Garbage = garbage;
        PickupTime = pickupTime;
    }
}