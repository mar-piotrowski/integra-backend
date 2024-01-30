using System.Net;
using Domain.Common.Models;

namespace Domain.Common.Errors {
    public static class ArticleErrors {
        public static Error NotFound =>
            new Error(HttpStatusCode.NotFound, "Article.NotFound", "Nie znaleziono artykułu");
    
        public static Error NotFoundMany =>
            new Error(HttpStatusCode.NotFound, "Article.NotFound", "Nie znaleziono artykułów");

        public static Error ArticleWithCodeExists =>
            new Error(HttpStatusCode.Conflict, "Article.CodeExists", "Artykuł z podanym kodem już istnieje");
    }
}