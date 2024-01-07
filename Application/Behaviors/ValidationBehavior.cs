// using Domain.Common.Models;
// using Domain.Result;
// using FluentResults;
// using FluentValidation;
// using FluentValidation.Results;
// using MediatR;
//
// namespace Application.Behaviors;
//
// public class ValidationBehavior<TRequest, TResponse>
//     : IPipelineBehavior<TRequest, TResponse>
//     where TRequest : IRequest<TResponse>
//     where TResponse : Result, new() {
//     private readonly IValidator<TRequest>? _validator;
//
//     public ValidationBehavior(IValidator<TRequest>? validator = null) =>
//         _validator = validator;
//
//     public async Task<TResponse> Handle(
//         TRequest request,
//         RequestHandlerDelegate<TResponse> next,
//         CancellationToken cancellationToken
//     ) {
//         if (_validator is null)
//             return await next();
//         var validationResult = await ValidateAsync(request);
//         if (!validationResult.IsFailure)
//             return await next();
//         var result = new TResponse();
//         foreach (var validationResultReason in validationResult.Reasons)
//             result.Reasons.Add(validationResultReason);
//         return result;
//     }
//
//     private async Task<Result> ValidateAsync(TRequest request) {
//         var validationResult = await _validator!.ValidateAsync(request);
//         if (validationResult.IsValid)
//             return Result.Success();
//         var failures = MapValidationFailures(validationResult.Errors);
//         return Result.Failure(new ValidationError("Podano błędne dane!", failures));
//     }
//
//     private static IEnumerable<Error> MapValidationFailures(IEnumerable<ValidationFailure> failures) {
//         var mappedFailures = failures.Select(failure => new Error {
//             Code = failure.ErrorCode,
//             Description = failure.ErrorMessage
//         });
//         return mappedFailures;
//     }
// }