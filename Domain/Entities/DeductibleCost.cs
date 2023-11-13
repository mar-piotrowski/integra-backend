namespace Domain.Entities {
    public class DeductibleCost {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Value { get; set; }
        public required DateTime RowDate { get; set; }
    }
}