using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class DocumentArticles : Entity<DocumentProductsId> {
   public DocumentId DocumentId { get; private set; }
   public ArticleId ArticleId { get; private set; }
   public decimal Amount { get; private set; }   
   public Document Document { get; private set; }
   public Article Article { get; private set; }

   public DocumentArticles(DocumentId documentId, ArticleId articleId, decimal amount) {
      DocumentId = documentId;
      ArticleId = articleId;
      Amount = amount;
   }

   public DocumentArticles(Document document, Article article, decimal amount) {
      Document = document;
      Article = article;
      Amount = amount;
   }
}