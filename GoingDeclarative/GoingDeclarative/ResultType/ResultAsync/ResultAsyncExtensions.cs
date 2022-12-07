using GoingDeclarative.ResultType;

using System;
using System.Runtime.CompilerServices;

namespace GoingDeclarative;

public static class ResultAsyncExtensions
{
    public static ResultAwaiter<T> GetAwaiter<T>(this Result<T> result)
    {
        return new ResultAwaiter<T>(result);
    }
}

public class ResultAwaiter<T> : INotifyCompletion
{
    private readonly Result<T> _result;
    public ResultAwaiter(Result<T> result) => _result = result;
    public bool IsCompleted { get; }
    public T GetResult()
    {
        T result = _result.Match(
            ok: (T value) => value,
            err: (Exception ex) => throw ex);

        return result;
    }

    public void OnCompleted(Action continuation) => continuation();
}

public class ResultMethodBuilder<T>
{
    #region Default implementations

    public static ResultMethodBuilder<T> Create() => new();

    public void SetStateMachine(IAsyncStateMachine stateMachine) { }

    public void Start<TStateMachine>(ref TStateMachine stateMachine)
        where TStateMachine : IAsyncStateMachine
        => stateMachine.MoveNext();

    public void AwaitOnCompleted<TAwaiter, TStateMachine>(
      ref TAwaiter awaiter,
      ref TStateMachine stateMachine)
      where TAwaiter : INotifyCompletion
      where TStateMachine : IAsyncStateMachine =>
      awaiter.OnCompleted(stateMachine.MoveNext);

    public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(
        ref TAwaiter awaiter,
        ref TStateMachine stateMachine)
        where TAwaiter : ICriticalNotifyCompletion
        where TStateMachine : IAsyncStateMachine =>
        awaiter.UnsafeOnCompleted(stateMachine.MoveNext);

    #endregion

    public void SetException(Exception exception)
    {
        Task = Result.Err<T>(exception);
    }
    public void SetResult(T result)
    {
        Task = Result.Ok(result);
    }

    // Task is the name expected by the AsyncMethodBuilder
    public Result<T> Task { get; private set; }
}