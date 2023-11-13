using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("/api/v1/companies")]
public class CompanyController : ControllerBase {
    [HttpGet]
    public ActionResult GetAll() {
        throw new NotImplementedException();
    }

    [HttpGet("{companyId:int}")]
    public ActionResult Get(int companyId) {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult Add(int companyId) {
        throw new NotImplementedException();
    }

    [HttpPut("{companyId:int}")]
    public ActionResult Update(int companyId) {
        throw new NotImplementedException();
    }

    [HttpDelete("{companyId:int}")]
    public ActionResult Delete(int companyId) {
        throw new NotImplementedException();
    }
}