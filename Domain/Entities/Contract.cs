using Domain.Common.Models;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public sealed class Contract : Entity<ContractId> {
    public decimal Salary { get; private set; }
    public DateTime SignedOnDate { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public bool JobFund { get; private set; }
    public bool Fgsp { get; private set; }
    public bool PitExemption { get; private set; }
    public ContractType ContractType { get; private set; }
    public InsuranceCodeId InsuranceCodeId { get; private set; }
    public UserId UserId { get; private set; }
    public JobPositionId JobPositionId { get; private set; }

    private Contract() { }

    private Contract(
        decimal salary,
        DateTime signedOnDate,
        DateTime startDate,
        DateTime? endDate,
        bool jobFund,
        bool fgsp,
        bool pitExemption,
        ContractType contractType,
        InsuranceCodeId insuranceCode,
        UserId userId,
        JobPositionId jobPositionId
    ) {
        Salary = salary;
        SignedOnDate = signedOnDate;
        StartDate = startDate;
        EndDate = endDate;
        JobFund = jobFund;
        Fgsp = fgsp;
        PitExemption = pitExemption;
        ContractType = contractType;
        InsuranceCodeId = insuranceCode;
        UserId = userId;
        JobPositionId = jobPositionId;
    }

    public static Contract Create(
        decimal salary,
        DateTime signedOnDate,
        DateTime startDate,
        DateTime? endDate,
        bool jobFund,
        bool fgsp,
        bool pitExemption,
        ContractType contractType,
        InsuranceCodeId insuranceCodeId,
        UserId userId,
        JobPositionId jobPositionId
    ) => new Contract(
        salary,
        signedOnDate,
        startDate,
        endDate,
        jobFund,
        fgsp,
        pitExemption,
        contractType,
        insuranceCodeId,
        userId,
        jobPositionId
    );
}