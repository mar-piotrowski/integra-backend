using Domain.Common.Models;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Domain.Entities {
    public class Stock : AggregateRoot<StockId> {
        public string Name { get; private set; }
        public Location? Location { get; private set; }
        private readonly List<Article> _articles = new List<Article>();
        public IReadOnlyList<Article> Articles => _articles.AsReadOnly();

        private Stock() { }

        private Stock(string name, Location? location = null) {
            Name = name;
            Location = location;
        }

        public static Stock Create(string name, Location? location = null) => new Stock(name, location);

        public void AddArticle(Article article) {
            _articles.Add(article);
        }

        public void RemoveArticle(Article article) {
            _articles.Remove(article);
        }
    }
}