using System.Net;

namespace Domain.Common.Models {
    public sealed class Error  {
        public readonly HttpStatusCode Status;
        public string Code { get; }
        public string Message { get; }

        public Error(HttpStatusCode status, string code, string message) {
            Status = status;
            Code = code;
            Message = message;
        }

        public static implicit operator string(Error error) => error?.Code ?? string.Empty;

        // protected override IEnumerable<object> GetAtomicValues() {
        //     yield return Code;
        //     yield return Message;
        // }

        internal static Error None => new Error(0, string.Empty, string.Empty);
    }
}