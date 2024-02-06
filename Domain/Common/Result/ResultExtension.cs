using Domain.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Common.Result {
    public static class ResultExtension {
        public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, Error error) {
            if (result.IsFailure)
                return result;
            return result.IsSuccess && predicate(result.Value) ? result : Result.Failure<T>(error);
        }

        public static Result<TOut> Map<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> func) =>
            result.IsSuccess ? func(result.Value) : Result.Failure<TOut>(result.Error);

        public static async Task<Result> Bind<TIn>(this Result<TIn> result, Func<TIn, Task<Result>> func) =>
            result.IsSuccess ? await func(result.Value) : Result.Failure(result.Error);

        public static async Task<Result<TOut>> Bind<TIn, TOut>(
            this Result<TIn> result,
            Func<TIn, Task<Result<TOut>>> func
        ) => result.IsSuccess ? await func(result.Value) : Result.Failure<TOut>(result.Error);

        public static async Task<T> Match<T>(this Task<Result> resultTask, Func<T> onSuccess, Func<Error, T> onFailure) {
            var result = await resultTask;
            return result.IsSuccess ? onSuccess() : onFailure(result.Error);
        }

        public static async Task<TOut> Match<TIn, TOut>(
            this Task<Result<TIn>> resultTask,
            Func<TIn, TOut> onSuccess,
            Func<Error, TOut> onFailure
        ) {
            var result = await resultTask;
            return result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Error);
        }

        public static ActionResult MapToResult(this Result result) {
            if (result.IsSuccess)
                return new OkResult();
            var error = new ObjectResult(result.Error) {
                StatusCode = (int)result.Error.Status
            };
            return error;
        }

        public static ActionResult MapToResult<T>(this Result<T> result) {
            if (result.IsSuccess)
                return new OkObjectResult(result.Value);
            var error = new ObjectResult(result.Error) {
                StatusCode = (int)result.Error.Status
            };
            return error;
        }
    }
}