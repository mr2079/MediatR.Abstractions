namespace MediatR.Abstractions.TestWebApi.Commands.AddProduct;

public record AddProductCommand(string Title, double Price) : IResultCommand<Guid>;

public class AddProductCommandHandler(Database db) : IResultCommandHandler<AddProductCommand, Guid>
{
    public Task<Result<Guid>> Handle(
        AddProductCommand command,
        CancellationToken cancellationToken)
    {
        var product = Product.Create(command.Title, command.Price);

        db.Products.Add(product);

        return Task.FromResult(Result.Success(product.Id));
    }
}