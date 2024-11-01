using MediatR.Abstractions.TestWebApi.Errors;

namespace MediatR.Abstractions.TestWebApi.Queries.GetProduct;

public record GetProductBySlugQuery(string Slug) : IResultQuery<Product>;

public class GetProductBySlugQueryHandler(Database db) : IResultQueryHandler<GetProductBySlugQuery, Product>
{
    public Task<Result<Product>> Handle(
        GetProductBySlugQuery query,
        CancellationToken cancellationToken)
    {
        var product = db.Products.FirstOrDefault(p => p.Slug == query.Slug);

        if (product != null)
            return Task.FromResult(Result.Success(product));

        return Task.FromResult(Result.Failure<Product>(ProductErrors.NotFound));
    }
}