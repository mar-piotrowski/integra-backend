using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities {
    public class Stock : AggregateRoot<StockId> {
        public string Name { get; private set; }
        public bool IsMain { get; private set; }
        public string? Description { get; private set; }

        public List<StockArticles> Articles { get; private set; } = new List<StockArticles>();

        private Stock() { }

        public Stock(string name, bool isMain, string? description) {
            Name = name;
            IsMain = isMain;
            Description = description;
        }

        public void Edit(string name, bool isMain, string? description) {
            Name = name;
            IsMain = isMain;
            Description = description;
        }

        public void AddArticles(List<StockArticleChangeDto> articles) {
            foreach (var article in articles) {
                var stockArticle = Articles
                    .FirstOrDefault(stockArticle => stockArticle.ArticleId == article.ArticleId);
                if (stockArticle is not null)
                    stockArticle.Add(article.Amount);
                else Articles.Add(new StockArticles(Id, article.ArticleId, article.Amount));
            }
        }

        public void AddArticle(Article article, decimal amount) =>
            Articles.Add(new StockArticles(this, article, amount));

        public void RemoveArticles(List<StockArticleChangeDto> articles) {
            foreach (var stockArticle in Articles)
                if (articles.Exists(a => a.ArticleId == stockArticle.ArticleId))
                    Articles.Remove(stockArticle);
        }

        public void RemoveArticle(Article article) {
            var stockArticle = Articles.FirstOrDefault(stockArticle => stockArticle.Article == article);
            if (stockArticle is null)
                return;
            Articles.Remove(stockArticle);
        }

        public void OddAmountArticles(List<StockArticleChangeDto> articles) {
            foreach (var stockArticleChange in articles) {
                var article = Articles.FirstOrDefault(article => article.ArticleId == stockArticleChange.ArticleId);
                if (article is null)
                    continue;
                article.Odd(stockArticleChange.Amount);
            }
        }

        public void ChangeArticleAmount(Article article, decimal amount) =>
            Articles.FirstOrDefault(stockArticle => stockArticle.Article == article)?.ChangeAmount(amount);

        public void IsNoLongerMain() => IsMain = false;
    }
}