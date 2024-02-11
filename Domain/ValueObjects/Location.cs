using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.ValueObjects {
    public class Location : ValueObject {
        public string Street { get; private set; }
        public string HouseNo { get; private set; }
        public string ApartmentNo { get; private set; }
        public string PostalCode { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string Province { get; private set; }
        public string Commune { get; private set; }
        public string District { get; private set; }
        public bool IsPrivate { get; private set; }
        public bool IsCompany { get; private set; }
        public UserId? UserId { get; private set; }

        public Location() { }

        private Location(
            string street,
            string houseNo,
            string apartmentNo,
            string postalCode,
            string city,
            string country,
            string province,
            string commune,
            string? district,
            bool isPrivate,
            bool isCompany
        ) {
            Street = street;
            HouseNo = houseNo;
            ApartmentNo = apartmentNo;
            PostalCode = postalCode;
            City = city;
            Country = country;
            Province = province;
            Commune = commune;
            District = district;
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
            string province,
            string commune,
            string? district,
            bool isPrivate,
            bool isCompany
        ) => new Location(
            street,
            houseNo,
            apartmentNo,
            postalCode,
            city,
            country,
            province, 
            commune,
            district,
            isPrivate,
            isCompany
        );

        public void Update(
            string street,
            string houseNo,
            string apartmentNo,
            string postalCode,
            string city,
            string country,
            string province,
            string commune,
            string? district,
            bool isPrivate,
            bool isCompany
        ) {
            Street = street;
            HouseNo = houseNo;
            ApartmentNo = apartmentNo;
            PostalCode = postalCode;
            City = city;
            Country = country;
            Province = province;
            Commune = commune;
            District = district;
            IsPrivate = isPrivate;
            IsCompany = isCompany;
        }

        protected override IEnumerable<object> GetAtomicValues() {
            yield return Street;
            yield return HouseNo;
            yield return ApartmentNo;
            yield return PostalCode;
            yield return City;
            yield return Country;
            yield return Province;
            yield return Commune;
            yield return District;
            yield return IsPrivate;
            yield return IsCompany;
        }
    }
}