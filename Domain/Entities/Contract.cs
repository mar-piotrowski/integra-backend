using Domain.Common.Models;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class Contract : Entity<ContractId> {
    public ContractStatus Status { get; private set; } = ContractStatus.None;
    public decimal SalaryWithTax { get; private set; }
    public decimal SalaryWithoutTax { get; private set; }
    public int WorkingHours1 { get; private set; }
    public int WorkingHours2 { get; private set; }
    public DateTime SignedOnDate { get; private set; }
    public DateTime? StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public bool JobFund { get; private set; }
    public bool PensionFund { get; private set; }
    public bool VoluntaryContribution { get; private set; }
    public bool ProfitableFund { get; private set; }
    public bool Fgsp { get; private set; }
    public bool PitExemption { get; private set; }
    public ContractType ContractType { get; private set; }
    public InsuranceCodeId? InsuranceCodeId { get; private set; }
    public UserId UserId { get; private set; }
    public JobPositionId? JobPositionId { get; private set; }
    public bool TaxRelief { get; private set; }
    public DeductibleCostId? DeductibleCostId { get; private set; }
    public User User { get; private set; }

    public List<ContractChange> ContractChanges { get; private set; } = new List<ContractChange>();
    public List<ContractChange> ContractBase { get; private set; } = new List<ContractChange>();
    
    private Contract() { }

    private Contract(
        decimal salaryWithTax,
        decimal salaryWithoutTax,
        int workingHours1,
        int workingHours2,
        DateTime signedOnDate,
        DateTime? startDate,
        DateTime? endDate,
        bool jobFund,
        bool voluntaryContribution,
        bool pensionFund,
        bool profitableFund,
        bool fgsp,
        bool pitExemption,
        ContractType contractType,
        bool taxRelief,
        InsuranceCodeId? insuranceCode,
        UserId userId,
        JobPositionId? jobPositionId,
        DeductibleCostId? deductibleCostId
    ) {
        SalaryWithTax = salaryWithTax;
        SalaryWithoutTax = salaryWithoutTax;
        WorkingHours1 = workingHours1;
        WorkingHours2 = workingHours2;
        SignedOnDate = signedOnDate;
        StartDate = startDate;
        EndDate = endDate;
        JobFund = jobFund;
        VoluntaryContribution = voluntaryContribution;
        PensionFund = pensionFund;
        ProfitableFund = profitableFund;
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
        decimal salaryWithTax,
        decimal salaryWithoutTax,
        int workingHours1,
        int workingHours2,
        DateTime signedOnDate,
        DateTime? startDate,
        DateTime? endDate,
        bool jobFund,
        bool voluntaryContribution,
        bool pensionFund,
        bool profitableFund,
        bool fgsp,
        bool pitExemption,
        ContractType contractType,
        bool taxRelief,
        InsuranceCodeId? insuranceCodeId,
        UserId userId,
        JobPositionId? jobPositionId,
        DeductibleCostId? deductibleCostId
    ) => new Contract(
        salaryWithTax,
        salaryWithoutTax,
        workingHours1,
        workingHours2,
        signedOnDate,
        startDate,
        endDate,
        jobFund,
        voluntaryContribution,
        pensionFund,
        profitableFund,
        fgsp,
        pitExemption,
        contractType,
        taxRelief,
        insuranceCodeId,
        userId,
        jobPositionId,
        deductibleCostId
    );

    public void Update(Contract contractChanges) {
        ContractChanges.Add(new ContractChange(Id, contractChanges.Id));
    }

    public void Active() => Status = ContractStatus.Active;

    public void DeActive() => Status = ContractStatus.NotActive;
}