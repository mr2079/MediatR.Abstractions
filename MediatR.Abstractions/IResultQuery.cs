namespace MediatR.Abstractions;

public interface IResultQuery<TResult>
    : IQuery<Result<TResult>>, IResultRequest<TResult>;

public interface IResultQueryHandler<in TQuery, TResult>
    : IQueryHandler<TQuery, Result<TResult>>
    where TQuery : IResultQuery<TResult>;