using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/cards")]
public class CardController {
    [HttpGet]
    public async Task<ActionResult> GetAll() {
        throw new NotImplementedException();
    }

    [HttpGet("cardId:int")]
    public async Task<ActionResult> Get(int cardId) {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult> Create() {
        throw new NotImplementedException();
    }

    [HttpPost("start-work")]
    public async Task<ActionResult> StartWork() {
        throw new NotImplementedException();
    }

    [HttpPost("end-work")]
    public async Task<ActionResult> EndWork() {
        throw new NotImplementedException();
    }
    
    // [HttpPost]
    // public async Task<ActionResult> Active() {
    //     throw new NotImplementedException();
    // }
    //
    // [HttpPost]
    // public async Task<ActionResult> DeActive() {
    //     throw new NotImplementedException();
    // }
}