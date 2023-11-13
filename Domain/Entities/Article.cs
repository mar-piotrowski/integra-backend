using Domain.Common.Models;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Domain.Entities {
    public sealed class Article : Entity<ArticleId> {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Gtin { get; private set; }
        public string MeasureUnit { get; private set; }
        public string Pkwiu { get; private set; }
        public string Description { get; private set; }
        public StockId StockId { get; private set; }

        private Article(string name, string code, string gtin, string measureUnit, string pkwiu, string description) {
            Name = name;
            Code = code;
            Gtin = gtin;
            MeasureUnit = measureUnit;
            Pkwiu = pkwiu;
            Description = description;
        }

        public static Article Create(
            string name,
            string code,
            string gtin,
            string measureUnit,
            string pkwiu,
            string description
        ) => new Article(name, code, gtin, measureUnit, pkwiu, description);
    }
}