using System.Net;
using Domain.Common.Models;

namespace Domain.Common.Errors {
    public static class StockErrors {
        public static Error StockExists => new Error(
            HttpStatusCode.Conflict,
            "Stock.Exists",
            "Magazyn o podanej nazwie istnieje"
        );
    }
}