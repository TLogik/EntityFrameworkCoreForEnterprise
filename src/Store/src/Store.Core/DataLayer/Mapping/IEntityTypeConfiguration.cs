using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Core.DataLayer.Mapping
{
    // todo: Remove this interface for EF Core 2
    public interface IEntityTypeConfiguration<TEntity> where TEntity : class, new()
    {
        void Configure(EntityTypeBuilder<TEntity> builder);
    }
}
