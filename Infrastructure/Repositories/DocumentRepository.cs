using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DocumentRepository : Repository<Document, DocumentId>, IDocumentRepository {
    public DocumentRepository(DatabaseContext dbContext) : base(dbContext) { }

    public IEnumerable<Document> FindAll(List<DocumentType> documentTypes) {
        IQueryable<Document> queryable = DbContext.Set<Document>()
            .Include(c => c.Contractor).ThenInclude(b => b.BankAccount)
            .Include(c => c.Contractor).ThenInclude(l => l.Location)
            .Include(a => a.Articles).ThenInclude(a => a.Article)
            .Include(s => s.SourceStock)
            .Include(s => s.TargetStock);
        if (documentTypes.Count != 0)
            queryable = queryable.Where(document => documentTypes.Contains(document.Type));
        return queryable.ToList();
    }

    public override Document? FindById(DocumentId id) =>
        DbContext.Set<Document>()
            .Include(c => c.Contractor).ThenInclude(b => b.BankAccount)
            .Include(c => c.Contractor).ThenInclude(l => l.Location)
            .Include(a => a.Articles).ThenInclude(a => a.Article)
            .Include(s => s.SourceStock)
            .Include(s => s.TargetStock)
            .FirstOrDefault(d => d.Id == id);

    public Document? FindByNumber(string number) =>
        DbContext.Set<Document>().FirstOrDefault(d => d.Number == number);
}