namespace MediatR.Abstractions.TestWebApi;

public class Database
{
    public List<Product> Products = [];

    public Database()
    {
        var p1 = Product.Create("Apple iphone 13 pro max", 1199.99);
        var p2 = Product.Create("Apple iphone 14 pro", 1299.99);
        var p3 = Product.Create("Samsung Galaxy S24 ultra", 1099.99);
        var p4 = Product.Create("Xiaomi Redmi note 14 pro plus", 799.99);
        Products.Add(p1);
        Products.Add(p2);
        Products.Add(p3);
        Products.Add(p4);
    }
}

public class Product
{
    private Product(Guid id, string title, string slug, double price)
    {
        Id = id;
        Title = title;
        Slug = slug;
        Price = price;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public double Price { get; private set; }

    public static Product Create(string title, double price) =>
        new(
            Guid.NewGuid(),
            title,
            title.ToSlug(),
            price);
}

public static class StringExtensions
{
    public static string ToSlug(this string input) =>
        input.TrimStart().TrimEnd().Replace(" ", "-").Trim();
}