namespace MediatR.Abstractions;

public interface IResultRequest
    : IRequest<Result>;

public interface IResultRequest<TResult>
    : IRequest<Result<TResult>>;

public interface IResultRequestHandler<in TRequest, TResult>
    : IRequestHandler<TRequest, Result<TResult>>
    where TRequest : IResultRequest<TResult>;