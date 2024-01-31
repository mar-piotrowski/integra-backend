using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class DocumentArticles : Entity<DocumentProductsId> {
   public DocumentId DocumentId { get; private set; }
   public ArticleId ArticleId { get; private set; }
   public Document Document { get; private set; }
   public Article Article { get; private set; }

   public DocumentArticles(DocumentId documentId, ArticleId articleId) {
      DocumentId = documentId;
      ArticleId = articleId;
   }

   public DocumentArticles(Document document, Article article) {
      Document = document;
      Article = article;
   }
}