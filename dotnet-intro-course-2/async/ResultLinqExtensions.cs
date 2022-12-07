using System.Collections.Generic;
using System.Linq;
namespace Result1;

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
        var l = new List<int>();

        var r = new Result<int>.Ok(1);

        var q =
            from a in r
            select a.ToString();


        var a = 
            from element in l
            where element % 2 == 0
            select element.ToString();
            
        
        
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