using Domain.Enums;

namespace Application.Features.Contract.TerminateContract;

public static class TerminateContractTypeMapper {
   public static ContractType MapContractType(this ContractTerminateType terminateType) => terminateType switch {
      ContractTerminateType.ByMutualAgreement => ContractType.TerminateByMutualAgreement,
      ContractTerminateType.ByTheEmployer => ContractType.TerminateByTheEmployer,
      ContractTerminateType.ByTheEmployerWithoutNoticePeriod => ContractType.TerminateByTheEmployerWithoutNoticePeriod,
      ContractTerminateType.ByTheEmployerWithNoticePeriod => ContractType.TerminateByTheEmployerWithNoticePeriod,
      ContractTerminateType.ByTheEmployee => ContractType.TerminateByTheEmployee,
   };
}