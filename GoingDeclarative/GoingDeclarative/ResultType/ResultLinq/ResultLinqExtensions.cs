using GoingDeclarative.ResultType;

using System;

namespace GoingDeclarative;

public static class ResultLinqExtensions
{
    public static Result<TR> Select<T, TR>(
        this Result<T> input,
        Func<T, TR> mapper)
    {
        return input.Map(mapper);
    }

    public static Result<TR> SelectMany<T, TR>(
        this Result<T> input,
        Func<T, Result<TR>> binder)
    {
        return input.Bind(binder);
    }

    public static Result<TR> SelectMany<T, TInner, TR>(
        this Result<T> input,
        Func<T, Result<TInner>> binder,
        Func<T, TInner, TR> resultSelector)
    {
        return input.Bind(value =>
        {
            Result<TInner> sndResult = binder(value);

            Result<TR> result = sndResult.Map(
                inner => resultSelector(value, inner));

            return result;
        });
    }

    public static Result<T> Where<T>(this Result<T> input,
        Func<T, bool> predicate)
    {
        return input.Bind(value =>
        {
            return predicate(value) 
                ? Result.Ok(value) 
                : Result.Err<T>(new Exception("Did not match the predicate"));
        });
    }
}
