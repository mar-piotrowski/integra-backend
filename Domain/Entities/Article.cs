using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities {
    public sealed class Article : Entity<ArticleId> {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Gtin { get; private set; }
        public string MeasureUnit { get; private set; }
        public string Pkwiu { get; private set; }
        public decimal BuyPriceWithoutTax { get; private set; }
        public decimal BuyPriceWithTax { get; private set; }
        public decimal SellPriceWithoutTax { get; private set; }
        public decimal SellPriceWithTax { get; private set; }
        public int TaxId { get; private set; }
        public string Description { get; private set; }

        private Article(
            string name,
            string code,
            string gtin,
            string measureUnit,
            string pkwiu,
            decimal buyPriceWithoutTax,
            decimal buyPriceWithTax,
            decimal sellPriceWithoutTax,
            decimal sellPriceWithTax,
            int taxId,
            string description
        ) {
            Name = name;
            Code = code;
            Gtin = gtin;
            MeasureUnit = measureUnit;
            Pkwiu = pkwiu;
            BuyPriceWithoutTax = buyPriceWithoutTax;
            BuyPriceWithTax = buyPriceWithTax;
            SellPriceWithoutTax = sellPriceWithoutTax;
            SellPriceWithTax = sellPriceWithTax;
            TaxId = taxId;
            Description = description;
        }

        public static Article Create(
            string name,
            string code,
            string gtin,
            string measureUnit,
            string pkwiu,
            decimal buyPriceWithoutTax,
            decimal buyPriceWithTax,
            decimal sellPriceWithoutTax,
            decimal sellPriceWithTax,
            int taxId,
            string description
        ) => new Article(
            name,
            code,
            gtin,
            measureUnit,
            pkwiu,
            buyPriceWithoutTax,
            buyPriceWithTax,
            sellPriceWithoutTax,
            sellPriceWithTax,
            taxId,
            description
        );
    }
}