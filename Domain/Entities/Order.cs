using Domain.Common.Models;
using Domain.Events;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Domain.Entities {
    public class Order : AggregateRoot<OrderId> {
        public string Status { get; private set; }
        public ContractorId ContractorId { get; private set; }
        private readonly List<Article> _articles;
        public IReadOnlyList<Article> Articles => _articles;

        private Order(string status, ContractorId contractorId, List<Article> articles) {
            Status = status;
            ContractorId = contractorId;
            _articles = articles;
        }

        private Order() { }

        public static Order Create(string status, ContractorId contractorId, List<Article> articles) {
            var order = new Order(status, contractorId, articles);
            order.AddDomainEvent(new OrderCreated(order));
            return order;
        }

        public void AddArticleItem(
            string name,
            string code,
            string gtin,
            string measureUnit,
            string pkwiu,
            string description
        ) {
            var article = Article.Create(name, code, gtin, measureUnit, pkwiu, description);
            _articles.Add(article);
        }

        public void DeleteArticleItem(Article article) => _articles.Remove(article);
    }
}