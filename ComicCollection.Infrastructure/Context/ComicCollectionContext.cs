using ComicCollection.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComicCollection.Infrastructure.Context;

public class ComicCollectionContext : DbContext
{
    public ComicCollectionContext(DbContextOptions<ComicCollectionContext> options)
        : base(options)
    {
    }

    public DbSet<Comic> Comics { get; set; }
}