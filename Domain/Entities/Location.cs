using Domain.Common.Models;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Domain.Entities {
    public class Location : ValueObject {
        public string Street { get; private set; }
        public string HouseNo { get; private set; }
        public string ApartmentNo { get; private set; }
        public string PostalCode { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public bool IsPrivate { get; private set; }
        public bool IsCompany { get; private set; }
        public UserId UserId { get; private set; }

        public Location() { }

        private Location(
            string street,
            string houseNo,
            string apartmentNo,
            string postalCode,
            string city,
            string country,
            bool isPrivate,
            bool isCompany
        ) {
            Street = street;
            HouseNo = houseNo;
            ApartmentNo = apartmentNo;
            PostalCode = postalCode;
            City = city;
            Country = country;
            IsPrivate = isPrivate;
            IsCompany = isCompany;
        }

        public static Location Create(
            string street,
            string houseNo,
            string apartmentNo,
            string postalCode,
            string city,
            string country,
            bool isPrivate,
            bool isCompany
        ) => new Location(street, houseNo, apartmentNo, postalCode, city, country, isPrivate, isCompany);

        public void Update(
            string street,
            string houseNo,
            string apartmentNo,
            string postalCode,
            string city,
            string country,
            bool isPrivate,
            bool isCompany
        ) {
            Street = street;
            HouseNo = houseNo;
            ApartmentNo = apartmentNo;
            PostalCode = postalCode;
            City = city;
            Country = country;
            IsPrivate = isPrivate;
            IsCompany = isCompany;
        }

        protected override IEnumerable<object> GetAtomicValues() {
            yield return Street;
        }
    }
}