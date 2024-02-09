using Application.Features.Document.Create;
using Application.Features.Document.Edit;
using Domain.Common.Result;

namespace Application.Features.Document.Documents;

public interface IDocument {
   public Result<Domain.Entities.Document> Create(CreateDocumentCommand command);
   public Result<Domain.Entities.Document> Edit(Domain.Entities.Document document, EditDocumentCommand command);
}