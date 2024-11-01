namespace MediatR.Abstractions.TestWebApi.Queries.GetProduct;

public record GetProductsQuery : IResultQuery<List<Product>>;

public class GetProductsQueryHandler(Database db) : IResultQueryHandler<GetProductsQuery, List<Product>>
{
    public Task<Result<List<Product>>> Handle(
        GetProductsQuery query,
        CancellationToken cancellationToken)
    {
        var products = db.Products.ToList();

        return Task.FromResult(Result.Success(products));
    }
}