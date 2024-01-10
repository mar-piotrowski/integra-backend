using Domain.Common.Models;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

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
    public JobPosition? JobPosition { get; private set; }
    public string? RefreshToken { get; private set; }
    private readonly List<HolidayLimit> _holidayLimits = new List<HolidayLimit>();
    private readonly List<Location> _locations = new List<Location>();
    private readonly List<Contract> _contracts = new List<Contract>();
    private readonly List<Absence> _absences = new List<Absence>();
    private readonly List<JobHistory> _jobHistories = new List<JobHistory>();
    private readonly List<SchoolHistory> _schoolHistories = new List<SchoolHistory>();
    private readonly List<UserPermissions> _permissions = new List<UserPermissions>();

    public IEnumerable<SchoolHistory> SchoolHistories => _schoolHistories.AsReadOnly();

    public IEnumerable<JobHistory> JobHistories => _jobHistories.AsReadOnly();

    public IEnumerable<Location> Locations => _locations.AsReadOnly();

    public IEnumerable<Contract> Contracts => _contracts.AsReadOnly();

    public IEnumerable<Absence> Absences => _absences.AsReadOnly();

    public IEnumerable<HolidayLimit> HolidayLimits => _holidayLimits.AsReadOnly();

    public IEnumerable<UserPermissions> Permissions => _permissions.AsReadOnly();

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

    public void AddAbsence(Absence absence) {
        _absences.Add(absence);
    }

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

    public void AddJobPosition(JobPosition jobPosition) {
        JobPosition = jobPosition;
    }

    public void UpdateJobPosition(JobPosition jobPosition) {
        JobPosition = jobPosition;
    }

    public void AddPermissions(IEnumerable<Permission> permissions) =>
        _permissions.AddRange(permissions.Select(permission => new UserPermissions(Id, permission.Id)));

    public void RemovePermissions(IEnumerable<Permission> permissions) {
        foreach (var permission in permissions) {
            var permissionToRemove = _permissions.FirstOrDefault(p => p.PermissionId == permission.Id);
            if (permissionToRemove is not null)
                _permissions.Remove(permissionToRemove);
        }
    }
    
    public void AddSchool(SchoolHistory schoolHistory) => _schoolHistories.Add(schoolHistory);

    public void UpdateSchoolHistory(SchoolHistoryId schoolHistoryId, SchoolHistory schoolHistory) =>
        _schoolHistories.FirstOrDefault(entry => entry.Id == schoolHistoryId)?.Update(schoolHistory);

    public void AddJobHistory(JobHistory jobHistory) => _jobHistories.Add(jobHistory);

    public void UpdateJobHistory(JobHistoryId jobHistoryId, JobHistory jobHistory) =>
        _jobHistories.FirstOrDefault(entry => entry.Id == jobHistoryId)?.Update(jobHistory);

    public void AddRefreshToken(string refreshToken) => RefreshToken = refreshToken;
}