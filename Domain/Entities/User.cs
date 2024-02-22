using System.Collections;
using Domain.Common.Models;
using Domain.Enums;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Entities;

public class User : AggregateRoot<UserId> {
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public string? SecondName { get; private set; }
    public Email? Email { get; private set; }
    public Phone? Phone { get; private set; }
    public PersonalIdNumber? PersonalIdNumber { get; private set; }
    public DocumentNumber? DocumentNumber { get; private set; }
    public DateTimeOffset? DateOfBirth { get; private set; } = null;
    public string? PlaceOfBirth { get; private set; }
    public string? Citizenship { get; private set; }
    public string? Nip { get; private set; }
    public Sex Sex { get; private set; } = Sex.None;
    public bool IsStudent { get; private set; }
    public Credential? Credential { get; private set; }
    public JobPosition? JobPosition { get; private set; }
    public BankAccount? BankAccount { get; private set; }
    public string? RefreshToken { get; private set; }
    public bool Active { get; private set; } = true;
    public bool CompleteDataInfo { get; private set; }
    private readonly List<Card> _cards = new List<Card>();
    private readonly List<HolidayLimit> _holidayLimits = new List<HolidayLimit>();
    private readonly List<Location> _locations = new List<Location>();
    private readonly List<Contract> _contracts = new List<Contract>();
    private readonly List<Absence> _absences = new List<Absence>();
    private readonly List<JobHistory> _jobHistories = new List<JobHistory>();
    private readonly List<SchoolHistory> _schoolHistories = new List<SchoolHistory>();
    private readonly List<UserPermissions> _permissions = new List<UserPermissions>();
    private readonly List<WorkingTime> _workingTimes = new List<WorkingTime>();
    private readonly List<UserSchedules> _schedules = new List<UserSchedules>();
    public IEnumerable<Card> Cards => _cards.AsReadOnly();
    public IEnumerable<SchoolHistory> SchoolHistories => _schoolHistories.AsReadOnly();

    public IEnumerable<JobHistory> JobHistories => _jobHistories.AsReadOnly();

    public IEnumerable<Location> Locations => _locations.AsReadOnly();

    public IEnumerable<Contract> Contracts => _contracts.AsReadOnly();

    public IEnumerable<Absence> Absences => _absences.AsReadOnly();

    public IEnumerable<HolidayLimit> HolidayLimits => _holidayLimits.AsReadOnly();

    public IEnumerable<UserPermissions> Permissions => _permissions.AsReadOnly();

    public IEnumerable<WorkingTime> WorkingTimes => _workingTimes.AsReadOnly();

    public IEnumerable<UserSchedules> Schedules => _schedules.AsReadOnly();

    private User() { }

    public User(
        string firstname,
        string lastname,
        Email? email,
        PersonalIdNumber? personalIdNumber,
        DocumentNumber? documentNumber,
        Phone? phone,
        bool isStudent,
        string? secondName,
        DateTimeOffset? dateOfBirth,
        string? placeOfBirth,
        Sex sex,
        string? citizenship,
        string? nip
    ) {
        Firstname = firstname;
        Lastname = lastname;
        Email = email;
        PersonalIdNumber = personalIdNumber;
        DocumentNumber = documentNumber;
        Phone = phone;
        IsStudent = isStudent;
        SecondName = secondName;
        DateOfBirth = dateOfBirth;
        PlaceOfBirth = placeOfBirth;
        Sex = sex;
        Citizenship = citizenship;
        Nip = nip;
    }

    public static User Register(string firstname, string lastname, Email email) =>
        new User(
            firstname,
            lastname,
            email,
            null,
            null,
            null,
            false,
            null,
            null,
            null,
            Sex.None,
            null,
            null
        );

    public void Update(
        string firstname,
        string lastname,
        Email? email,
        PersonalIdNumber? personalIdNumber = null,
        DocumentNumber? documentNumber = null,
        Phone? phone = null,
        string? secondName = "",
        bool isStudent = false,
        DateTimeOffset? dateOfBirth = null,
        string? placeOfBirth = "",
        Sex sex = Sex.None,
        string? citizenship = null,
        string? nip = null
    ) {
        Firstname = firstname;
        Lastname = lastname;
        Email = email;
        PersonalIdNumber = personalIdNumber;
        DocumentNumber = documentNumber;
        Phone = phone;
        IsStudent = isStudent;
        SecondName = secondName;
        DateOfBirth = dateOfBirth;
        PlaceOfBirth = placeOfBirth;
        Sex = sex;
        Citizenship = citizenship;
        Nip = nip;
    }

    public void AddSchedule(ScheduleSchema scheduleSchema) =>
        _schedules.Add(new UserSchedules(this, scheduleSchema));

    public void RemoveSchedule(ScheduleSchema scheduleSchema) {
        foreach (var userSchedules in _schedules.ToList())
            if (userSchedules.ScheduleSchema == scheduleSchema)
                _schedules.Remove(userSchedules);
    }

    public void AddAbsence(Absence absence) => _absences.Add(absence);

    public void AddContract(Contract contract) => _contracts.Add(contract);

    public void AddLocation(Location location) => _locations.Add(location);

    public void AddLocations(IEnumerable<Location> locations) => _locations.AddRange(locations);

    public void AddCredentials(Credential credential) => Credential = credential;

    public void AddJobPosition(JobPosition jobPosition) => JobPosition = jobPosition;

    public void UpdateJobPosition(JobPosition jobPosition) => JobPosition = jobPosition;

    public void AddPermissions(IEnumerable<Permission> permissions) =>
        _permissions.AddRange(permissions.Select(permission => new UserPermissions(Id, permission.Id)));

    public void RemovePermissions(IEnumerable<Permission> permissions) {
        foreach (var permission in permissions) {
            var permissionToRemove = _permissions.FirstOrDefault(p => p.PermissionId == permission.Id);
            if (permissionToRemove is not null)
                _permissions.Remove(permissionToRemove);
        }
    }

    public void AddBankAccount(string name, string number) => BankAccount = new BankAccount(name, name);

    public void AddSchool(SchoolHistory schoolHistory) => _schoolHistories.Add(schoolHistory);

    public void UpdateSchoolHistory(SchoolHistoryId schoolHistoryId, SchoolHistory schoolHistory) =>
        _schoolHistories.FirstOrDefault(entry => entry.Id == schoolHistoryId)?.Update(schoolHistory);

    public void AddJobHistory(JobHistory jobHistory) => _jobHistories.Add(jobHistory);

    public void UpdateJobHistory(JobHistoryId jobHistoryId, JobHistory jobHistory) =>
        _jobHistories.FirstOrDefault(entry => entry.Id == jobHistoryId)?.Update(jobHistory);

    public void AddRefreshToken(string refreshToken) => RefreshToken = refreshToken;

    public void StartWork(WorkingTime workingTime) => _workingTimes.Add(workingTime);

    public void EndWork() {
        var userWorkingTime = _workingTimes.MaxBy(date => date.CreatedDate);
        userWorkingTime?.EndWork();
    }

    public void AddCard(Card card) => _cards.Add(card);

    public void Activate() => Active = true;

    public void DeActivate() => Active = false;
}