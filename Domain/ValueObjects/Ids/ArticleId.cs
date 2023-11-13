using Domain.Common.Models;

namespace Domain.ValueObjects.Ids {
    public class ArticleId : ValueObject {
        public int Value { get; set; }

        private ArticleId(int value) =>
            Value = value;

        public static ArticleId Create(int id) => new ArticleId(id);

        protected override IEnumerable<object> GetAtomicValues() {
            yield return Value;
        }
    }
}