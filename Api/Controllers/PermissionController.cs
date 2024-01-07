using Application.Dtos;
using Application.Features.Permission.CreatePermission;
using Application.Features.Permission.GetPermission;
using Application.Features.Permission.GetPermissions;
using Domain.Common.Result;
using Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/permissions")]
public class PermissionController : Controller {
   private readonly ISender _sender;

   public PermissionController(ISender sender) => _sender = sender;

   [HttpGet]
   public async Task<ActionResult> GetAll([FromQuery] PermissionQueryParams filters) {
       var result = await _sender.Send(new GetPermissionsQuery(filters));
       return result.MapResult();
   }

   [HttpGet("{permissionCode:int}")]
   public async Task<ActionResult> Get(int permissionCode) {
       var result = await _sender.Send(new GetPermissionQuery(PermissionCode.Create(permissionCode)));
       return result.MapResult();
   }

   [HttpPost]
   public async Task<ActionResult> Create([FromBody] CreatePermissionCommand command) {
       var result = await _sender.Send(command);
       return result.MapResult();
   }

   [HttpPut("{permissionCode:int}")]
   public async Task<ActionResult> Edit(int permissionCode) {
       throw new NotImplementedException();
   }

   [HttpDelete("{permissionCode:int}")]
   public async Task<ActionResult> Delete(int permissionCode) {
       throw new NotImplementedException();
   }
}