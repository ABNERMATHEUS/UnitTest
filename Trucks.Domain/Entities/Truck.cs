namespace Trucks.Domain.Entities;

public class Truck : BaseEntity
{
    private Truck()
    {
    }
    public Truck(string name, string model, int year, string chassis, string color)
        : base()
    {
        Name = name;
        Model = model;
        Year = year;
        Chassis = chassis;
        Color = color;
    }

    public string Name { get; private set; }
    public string Model { get; private set; }
    public int Year { get; private set; }
    public string Chassis { get; private set; }
    public string Color { get; private set; }
}
