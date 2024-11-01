using MediatR.Abstractions.TestWebApi.Commands.AddProduct;
using MediatR.Abstractions.TestWebApi.Queries.GetProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.Abstractions.TestWebApi.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProductsAsync()
    {
        var result = await sender.Send(new GetProductsQuery());

        var response = result.IsSuccess
            ? new Response<List<Product>>(result.Value, result.IsSuccess)
            : new Response(result.IsSuccess, result.Error.Message);

        return Ok(response);
    }

    [HttpGet("{slug}")]
    public async Task<IActionResult> GetProductBySlugAsync(string slug)
    {
        var result = await sender.Send(new GetProductBySlugQuery(slug));

        var response = result.IsSuccess
            ? new Response<Product>(result.Value, result.IsSuccess)
            : new Response(result.IsSuccess, result.Error.Message);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddProductAsync(AddProductCommand command)
    {
        var result = await sender.Send(command);

        var response = result.IsSuccess
            ? new Response<Guid>(result.Value, result.IsSuccess)
            : new Response(result.IsSuccess, result.Error.Message);

        return Ok(response);
    }
}

public record Response(bool IsSuccess, string? Message = null);

public record Response<TData>(TData Data, bool IsSuccess, string? Message = null)
    : Response(IsSuccess, Message);