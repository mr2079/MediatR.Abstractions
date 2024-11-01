namespace MediatR.Abstractions.TestWebApi.Errors;

public static class ProductErrors
{
    public static Error NotFound = new(
        "Product.NotFound",
        "There is no product by this entered information");
}