using NetTopologySuite.Geometries;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Domain;
[ComplexType]
public record class Address
{
    public required string Line1 { get; set; }
    public string? Line2 { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
    public required string PostCode { get; set; }
}

public class Customer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required Address Address { get; set; }
    public List<Order> Orders { get; } = new();
}

public class Order
{
    public int Id { get; set; }
    public required string Contents { get; set; }
    public required Address ShippingAddress { get; set; }
    public required Address BillingAddress { get; set; }
    public Customer Customer { get; set; } = null!;
}

public class Pub
{
    public Pub(string name, string[] beers)
    {
        Name = name;
        Beers = beers;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string[] Beers { get; set; }
    public List<DateOnly> DaysVisited { get; private set; } = new();
}
public interface ITenantId
{
    public int Id { get;  }
}
    public class TenantId:ITenantId
{
    public int Id { get; set; }
    public TenantId(int id)
    {
        Id = id;
    }   
}


public class Rider
{
    public int Id { get; set; }
    public EquineBeast Mount { get; set; }
}

public enum EquineBeast
{
    Donkey,
    Mule,
    Horse,
    Unicorn
}


[Table("Cities")]
public class City
{
    public int CityID { get; set; }

    public string CityNameCode { get; set; }

    public Point Location { get; set; }
}

[Table("Countries")]
public class Country
{
    public int CountryID { get; set; }

    public string CountryName { get; set; }

    // Database includes both Polygon and MultiPolygon values
    public Geometry Border { get; set; }
}

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Point Position { get; set; }
}


public class NullSemanticsEntity
{
    public int Id { get; set; }
    public int Int { get; set; }
    public int? NullableInt { get; set; }
    public string String1 { get; set; }
    public string String2 { get; set; }
}

public class BBBBlog : INotifyPropertyChanging, INotifyPropertyChanged
{
    public int Id { get; 
            
        set;
    
    }
    public string Name { get; set; }
    public string Url { get; set; }

    public IList<Post> Posts { get; set; } = new List<Post>();

    public int OwnerId { get; set; }

    public event PropertyChangingEventHandler? PropertyChanging;
    public event PropertyChangedEventHandler? PropertyChanged;
}

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int? BlogId { get; set; }
    public BBBBlog Blog { get; set; }

    public int AuthorId { get; set; }
}