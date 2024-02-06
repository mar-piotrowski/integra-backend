using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DocumentRepository : Repository<Document, DocumentId>, IDocumentRepository {
    public DocumentRepository(DatabaseContext dbContext) : base(dbContext) { }

    public override IEnumerable<Document> FindAll() =>
        DbContext.Set<Document>()
            .Include(c => c.Contractor).ThenInclude(b => b.BankAccount)
            .Include(c => c.Contractor).ThenInclude(l => l.Location)
            .Include(a => a.Articles).ThenInclude(a => a.Article)
            .Include(s => s.SourceStock)
            .Include(s => s.TargetStock)
            .ToList();

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