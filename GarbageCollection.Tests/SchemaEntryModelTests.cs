using GarbageCollection.Core.Models;

namespace GarbageCollection.Tests;

public class SchemaEntryModelTests
{
    [Fact]
    public void Displays_vandaag_when_pickup_time_is_today()
    {
        SchemaEntry entry = new SchemaEntry(Garbage.Organic, DateTime.Today);
        
        Assert.Equal("vandaag", entry.PickupTime.ToShortDateString());
    }
    
    [Fact]
    public void Displays_morgen_when_pickup_time_is_tomorrow()
    {
    }
    
    [Fact]
    public void Displays_a_short_date_string_when_pickup_time_between_2_and_7_days_away()
    {
    }
    
    [Fact]
    public void Displays_volgende_week_when_pickup_time_is_exactly_seven_days()
    {
    }
    
    [Fact]
    public void Displays_volgende_week_when_pickup_time_is_larger_than_seven_days()
    {
    }
    
    // TODO: Create all the tests for the ToFriendlyGarbageName tests
}