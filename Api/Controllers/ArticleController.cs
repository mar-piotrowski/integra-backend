using Application.Dtos;
using Application.Features.Article.CreateArticle;
using Application.Features.Article.DeleteArticle;
using Application.Features.Article.GetArtcle;
using Application.Features.Article.GetArticles;
using Application.Features.Article.UpdateArticle;
using Domain.Common.Result;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/articles")]
[ApiController]
public class ArticleController : ControllerBase {
    private readonly ISender _sender;

    public ArticleController(ISender sender) => _sender = sender;

    [HttpGet]
    public async Task<ActionResult> GetAll() {
        var command = new GetArticlesQuery();
        var result = await _sender.Send(command);
        return result.MapToResult();
    }

    [HttpGet("{articleId:int}")]
    public async Task<ActionResult> Get([FromRoute] int stockId, int articleId) {
        var command = new GetArticleQuery(ArticleId.Create(articleId), new StockId(stockId));
        var result = await _sender.Send(command);
        return result.MapToResult();
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateArticleCommand command) {
        var result = await _sender.Send(command);
        return result.MapToResult();
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
            article.BuyPriceWithoutTax,
            article.BuyPriceWithTax,
            article.SellPriceWithoutTax,
            article.SellPriceWithTax,
            article.Tax,
            article.Description
        );
        var result = await _sender.Send(command);
        return result.MapToResult();
    }

    [HttpDelete("{articleId:int}")]
    public async Task<ActionResult> Delete(int articleId) {
        var result = await _sender.Send(new DeleteArticleCommand(ArticleId.Create(articleId)));
        return result.MapToResult();
    }
}