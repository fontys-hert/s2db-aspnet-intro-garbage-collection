using GarbageCollection.DataAccess.dtos;

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

    public static SchemaEntry From(SchemaEntryDto dto)
    {
        return new SchemaEntry(Enum.Parse<Garbage>(dto.Garbage), dto.PickupTime);
    }
    
    public string ToFriendlyGarbageName()
    {
        return Garbage switch {
            Garbage.Organic => "GTF",
            Garbage.Paper => "Papier",
            Garbage.Pmd => "Plastic en co",
            Garbage.Residual => "Plastic en co",
            _ => throw new NotImplementedException("Unknown garbase provided")
        };
    }

    public string ToFriendlyPickupDate()
    {
        DateTime date = PickupTime.Date;
        DateTime today = DateTime.Today;
        
        if (date == today.AddDays(1))
        {
            return "Morgen";
        }
        if (date == today.AddDays(2))
        {
            return "Ovrmorgen";
        }
        if (date > today.AddDays(3))
        {
            return "Volgende week";
        }
        return date.ToShortDateString();
    }
}