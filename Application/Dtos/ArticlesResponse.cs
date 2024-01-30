namespace Application.Dtos;

public record ArticlesResponse(decimal TotalProducts, List<ArticleDto> Articles);
