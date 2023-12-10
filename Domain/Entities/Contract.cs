using Domain.Common.Models;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public sealed class Contract : Entity<ContractId> {
    public decimal Salary { get; private set; }
    public int WorkingHours1 { get; private set; }
    public int WorkingHours2 { get; private set; }
    public DateTime? SignedOnDate { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public bool JobFund { get; private set; }
    public bool Fgsp { get; private set; }
    public bool PitExemption { get; private set; }
    public ContractType ContractType { get; private set; }
    public InsuranceCodeId InsuranceCodeId { get; private set; }
    public UserId UserId { get; private set; }
    public JobPositionId JobPositionId { get; private set; }
    public bool TaxRelief { get; private set; }
    public DeductibleCostId DeductibleCostId { get; private set; }
    private Contract() { }

    private Contract(
        decimal salary,
        int workingHours1,
        int workingHours2,
        DateTime? signedOnDate,
        DateTime startDate,
        DateTime? endDate,
        bool jobFund,
        bool fgsp,
        bool pitExemption,
        ContractType contractType,
        bool taxRelief,
        InsuranceCodeId insuranceCode,
        UserId userId,
        JobPositionId jobPositionId,
        DeductibleCostId deductibleCostId 
    ) {
        Salary = salary;
        WorkingHours1 = workingHours1;
        WorkingHours2 = workingHours2;
        SignedOnDate = signedOnDate;
        StartDate = startDate;
        EndDate = endDate;
        JobFund = jobFund;
        Fgsp = fgsp;
        PitExemption = pitExemption;
        ContractType = contractType;
        TaxRelief = taxRelief;
        InsuranceCodeId = insuranceCode;
        UserId = userId;
        JobPositionId = jobPositionId;
        DeductibleCostId = deductibleCostId;
    }

    public static Contract Create(
        decimal salary,
        int workingHours1,
        int workingHours2,
        DateTime? signedOnDate,
        DateTime startDate,
        DateTime? endDate,
        bool jobFund,
        bool fgsp,
        bool pitExemption,
        ContractType contractType,
        bool taxRelief,
        InsuranceCodeId insuranceCodeId,
        UserId userId,
        JobPositionId jobPositionId,
        DeductibleCostId deductibleCostId
    ) => new Contract(
        salary,
        workingHours1,
        workingHours2,
        signedOnDate,
        startDate,
        endDate,
        jobFund,
        fgsp,
        pitExemption,
        contractType,
        taxRelief,
        insuranceCodeId,
        userId,
        jobPositionId,
        deductibleCostId
    );
}