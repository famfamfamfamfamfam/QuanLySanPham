namespace QUANLYSANPHAM
{
class Product
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Manufacturer { get; set; }
    public decimal? Price { get; set; }
    public string? Description { get; set; }

    public override string ToString()
    {
        return $"{Id};{Name};{Manufacturer};{Price};{Description}";
    }

    public static Product FromString(string str)
    {
        var parts = str.Split(';');
        return new Product
        {
            Id = parts[0],
            Name = parts[1],
            Manufacturer = parts[2],
            Price = decimal.Parse(parts[3]),
            Description = parts[4]
        };
    }
}
}