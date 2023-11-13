using Domain.Common.Models;

namespace Domain.Result {
    public class Result {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        protected Result(bool isSuccess, Error error) {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new Result(true, Error.None);

        public static Result<TValue> Success<TValue>(TValue value) => new Result<TValue>(value, true, Error.None);

        public static Result<TValue> Create<TValue>(TValue? value, Error error)
            where TValue : class
            => value is null ? Failure<TValue>(error) : Success(value);

        public static Result Failure(Error error) => new Result(false, error);

        public static Result<TValue> Failure<TValue>(Error error) => new Result<TValue>(default!, false, error);

        public static Result FirstFailureOrSuccess(params Result[] results) {
            foreach (var result in results)
                if (result.IsFailure)
                    return result;
            return Success();
        }
    }
}