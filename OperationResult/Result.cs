namespace Almostengr.Common.OperationResult;

public sealed class Result<TEntity>
{
    private readonly List<string> _errors = new();
    public bool Succeeded => _errors.Count() == 0;
    public bool Failed => !Succeeded;
    public TEntity? Entity { get; }
    public IReadOnlyList<string> Errors => _errors.ToList();

    private Result(TEntity? entity, IEnumerable<string> errors)
    {
        _ = errors ?? throw new ArgumentNullException(nameof(errors));

        Entity = entity;
        _errors.AddRange(errors);
    }

    public static Result<TEntity> Success(TEntity entity)
    {
        return new Result<TEntity>(entity, []);
    }

    public static Result<TEntity> Failure(Exception exception)
    {
        return new Result<TEntity>(default, [exception.Message]);
    }

    public static Result<TEntity> Failure(string error)
    {
        if (string.IsNullOrWhiteSpace(error))
        {
            throw new ArgumentNullException(nameof(error));
        }

        return new Result<TEntity>(default, [error]);
    }

    public static Result<TEntity> Failure(IEnumerable<string> errors)
    {
        _ = errors ?? throw new ArgumentNullException(nameof(errors));

        return new Result<TEntity>(default, errors);
    }
}
