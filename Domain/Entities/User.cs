using Domain.Common.Models;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Domain.Entities {
    public class User : AggregateRoot<UserId> {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string? SecondName { get; private set; }
        public Email Email { get; private set; }
        public Phone? Phone { get; private set; } = null;
        public IdentityNumber? IdentityNumber { get; private set; } = null;
        public DateTime? DateOfBirth { get; private set; } = null;
        public string? PlaceOfBirth { get; private set; } = null;
        public string? Sex { get; private set; }
        public bool IsStudent { get; private set; }
        public Credential Credential { get; private set; }

        private readonly List<Location> _locations = new List<Location>();

        private readonly List<Contract> _contracts = new List<Contract>();

        public IEnumerable<Location> Locations => _locations.AsReadOnly();

        public IEnumerable<Contract> Contracts => _contracts.AsReadOnly();

        private User() { }

        private User(
            string firstname,
            string lastname,
            Email email,
            IdentityNumber? identityNumber,
            Phone? phone,
            bool isStudent,
            string? secondName,
            DateTime? dateOfBirth,
            string? placeOfBirth,
            string? sex
        ) {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            IdentityNumber = identityNumber;
            Phone = phone;
            IsStudent = isStudent;
            SecondName = secondName;
            DateOfBirth = dateOfBirth;
            PlaceOfBirth = placeOfBirth;
            Sex = sex;
        }

        public static User Create(
            string firstname,
            string lastname,
            Email email,
            IdentityNumber? identityNumber = null,
            Phone? phone = null,
            string? secondName = "",
            bool isStudent = false,
            DateTime? dateOfBirth = null,
            string? placeOfBirth = "",
            string? sex = ""
        ) => new User(
            firstname,
            lastname,
            email,
            identityNumber,
            phone,
            isStudent,
            secondName,
            dateOfBirth,
            placeOfBirth,
            sex
        );

        public void AddContract(Contract contract) {
            _contracts.Add(contract);
        }
        
        public void AddLocation(Location location) {
            _locations.Add(location);
        }
        
        public void AddLocations(IEnumerable<Location> locations) {
           _locations.AddRange(locations); 
        }

        public void AddCredentials(Credential credential) {
            Credential = credential;
        }
    }
}