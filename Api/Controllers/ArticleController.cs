using Application.Dtos;
using Application.Features.Article.Command;
using Application.Features.Article.Queries;
using Domain.Result;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/articles")]
[ApiController]
[Authorize]
public class ArticleController : ControllerBase {
    private readonly ISender _sender;

    public ArticleController(ISender sender) {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll() {
        var command = new GetArticlesQuery();
        var result = await _sender.Send(command);
        return result.MapResult();
    }

    [HttpGet("{articleId:int}")]
    public async Task<ActionResult> Get([FromRoute] int stockId, int articleId) {
        var command = new GetArticleQuery(ArticleId.Create(articleId), StockId.Create(stockId));
        var result = await _sender.Send(command);
        return result.MapResult();
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateArticleCommand command) {
        var result = await _sender.Send(command);
        return result.MapResult();
    }

    [HttpPut("{articleId:int}")]
    public async Task<ActionResult> Update(int articleId, [FromBody] UpdateArticleRequest article) {
        var command = new UpdateArticleCommand(
            ArticleId.Create(articleId),
            article.Name,
            article.Code,
            article.Gtin,
            article.MeasureUnit,
            article.Pkwiu,
            article.Description,
            article.StockId
        );
        var result = await _sender.Send(command);
        return result.MapResult();
    }

    [HttpDelete("{articleId:int}")]
    public ActionResult Delete(int stockId, int articleId) {
        throw new NotImplementedException();
    }
}