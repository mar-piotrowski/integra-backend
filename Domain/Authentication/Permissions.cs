using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Authentication;

public static class Permissions {
    public static readonly List<Permission> WebsitePermissions = new List<Permission>() {
        new Permission(PermissionType.User, "Owner", PermissionCode.Create(748)),
        new Permission(PermissionType.User, "MgPanel", PermissionCode.Create(643)),
        new Permission(PermissionType.User, "Employee", PermissionCode.Create(943)),
        new Permission(PermissionType.User, "HrAll", PermissionCode.Create(200)),
        new Permission(PermissionType.User, "HrEmployees", PermissionCode.Create(201)),
        new Permission(PermissionType.User, "HrSchedule", PermissionCode.Create(202)),
        new Permission(PermissionType.User, "HrContracts", PermissionCode.Create(203)),
        new Permission(PermissionType.User, "HrHolidays", PermissionCode.Create(204)),
        new Permission(PermissionType.User, "HrSalaries", PermissionCode.Create(204)),
        new Permission(PermissionType.User, "DocAll", PermissionCode.Create(300)),
        new Permission(PermissionType.User, "DocContractors", PermissionCode.Create(301)),
        new Permission(PermissionType.User, "DocInvoices", PermissionCode.Create(302)),
        new Permission(PermissionType.User, "DocStocks", PermissionCode.Create(303)),
        new Permission(PermissionType.User, "StAll", PermissionCode.Create(400)),
        new Permission(PermissionType.User, "StProducts", PermissionCode.Create(401)),
    };
}