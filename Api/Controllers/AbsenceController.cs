using Domain.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("/api/v1/users/{userId:int}/absences")]
public class AbsenceController : Controller {
    private readonly ISender _sender;

    public AbsenceController(ISender sender) {
        _sender = sender;
    }

    [HttpGet]
    public ActionResult GetAll() {
        throw new NotImplementedException();
    }

    [HttpGet("{absenceId:int}")]
    public ActionResult Get(int userId, int absenceId) {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult Get([FromBody] OrderCreated order) {
        _sender.Send(order);
        return Ok();
    }

    [HttpPut("{absenceId:int}")]
    public ActionResult Update(int userId, int absenceId) {
        throw new NotImplementedException();
    }

    [HttpDelete("{absenceId:int}")]
    public ActionResult Delete(int userId, int absenceId) {
        throw new NotImplementedException();
    }
}