
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Result1;

#region Async
[AsyncMethodBuilder(typeof(ResultMethodBuilder<>))]
#endregion


public abstract record Result<T>()
{
    public record Ok(T Value) : Result<T>;
    public record Error(Exception Exception) : Result<T>;
}

public static class Result
{
    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>.Ok(value);
    }

    public static Result<T> Err<T>(Exception exception)
    {
        return new Result<T>.Error(exception);
    }

    public static TR Match<T, TR>(
        this Result<T> input, Func<T, TR> ok, Func<Exception, TR> err)
    {
        TR result = input switch
        {
            Result<T>.Ok { Value: var value } => ok(value),
            Result<T>.Error { Exception: var exception } => err(exception),
            _ => throw new InvalidOperationException("Cannot happen!")
        };

        return result;
    }

    public static List<TR> Map<T, TR>(
        this List<T> input, Func<T, TR> ok)
    {
        List<TR> l = new();
        foreach(var item in input)
        {
            var newItem = ok(item);
            l.Add(newItem);
        }
        return l;
    }

    public static Result<TR> Map<T, TR>(
        this Result<T> input, Func<T, TR> ok)
    {
        return input.Match(
            ok: value => Result.Ok(ok(value)),
            err: exception => Result.Err<TR>(exception));
    }

    public static List<TR> Bind<T, TR>(
        this List<T> input, Func<T, List<TR>> binder)
    {
        List<TR> l = new();
        foreach (var item in input)
        {
            return binder(item);
            //var newItems = binder(item);
            //foreach(var newItem in newItems)
            //{
            //    l.Add(newItem);
            //}
        }
        return l;
    }

    public static Result<TR> Bind<T, TR>(
        this Result<T> input, Func<T, Result<TR>> binder)
    {
        return input.Match(
            ok: value => binder(value),
            err: exception => Result.Err<TR>(exception));
    }
}


public static class ResultExtensions
{
    public static Result<IEnumerable<T>> Traverse<T>(
        this IEnumerable<Result<T>> results)
    {
        var elements = new List<T>();
        foreach (var result in results)
        {
            if (result is Result<T>.Error err)
            {
                return Result.Err<IEnumerable<T>>(err.Exception);
            }
            else if (result is Result<T>.Ok ok)
            {
                elements.Add(ok.Value);
            }
        }
        return Result.Ok(elements.AsEnumerable());
    }
}