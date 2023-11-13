using Domain.Common.Models;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Domain.Entities {
    public class Contractor : Entity<ContractorId> {
        public string FullName { get; private set; }
        public string ShortName { get; private set; }
        public string Representative { get; private set; }
        public Nip Nip { get; private set; }
        public Location Location { get; private set; }
        public BankDetails BankDetails { get; private set; }

        private Contractor() { }

        private Contractor(
            string fullName,
            string shortName,
            string representative,
            Nip nip,
            Location location,
            BankDetails bankDetails
        ) {
            FullName = fullName;
            ShortName = shortName;
            Representative = representative;
            Nip = nip;
            Location = location;
            BankDetails = bankDetails;
        }

        public static Contractor Create(
            string fullName,
            string shortName,
            string representative,
            Nip nip,
            Location location,
            BankDetails bankDetails
        ) => new Contractor(fullName, shortName, representative, nip, location, bankDetails);


        public void Update(string fullName, string shortName, Location location, BankDetails bankDetails) {
            FullName = fullName;
            ShortName = shortName;
            Location.Update(
                location.Street,
                location.HouseNo,
                location.ApartmentNo,
                location.PostalCode,
                location.City,
                location.Country,
                location.IsPrivate,
                location.IsCompany
            );
            BankDetails.Update(bankDetails.Name, bankDetails.Number);
        }
    }
}