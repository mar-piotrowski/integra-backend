using Application.Features.Document.Edit;
using Domain.Common.Result;

namespace Application.Features.Document.Create.Documents;

public interface IDocument {
   public Result<Domain.Entities.Document> Create(CreateDocumentCommand command);
   public Result<Domain.Entities.Document> Edit(EditDocumentCommand command);
}