namespace MediatR.Abstractions;

public interface IResultCommand
    : ICommand, IResultRequest;

public interface IResultCommand<TResult>
    : ICommand<Result<TResult>>, IResultRequest<TResult>;

public interface IResultCommandHandler<in TCommand>
    : ICommandHandler<TCommand>
    where TCommand : IResultCommand;

public interface IResultCommandHandler<in TCommand, TResult>
    : ICommandHandler<TCommand, Result<TResult>>
    where TCommand : IResultCommand<TResult>;