using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UTMMAX.Domain.Entities;

namespace UTMMAX.Repository.Mappings;

public class RefreshTokenEntityTypeConfiguration : IEntityTypeConfiguration<RefreshTokenEntity>
{
    public void Configure(EntityTypeBuilder<RefreshTokenEntity> builder)
    {
        builder.ToTable(DbTable.RefreshToken);
        
        builder.HasOne(it => it.UserEntity)
            .WithMany()
            .HasForeignKey(it => it.UserId)
            .IsRequired();

        builder.Ignore(it => it.CreatedOnUtc);
        builder.Ignore(it => it.UpdatedOnUtc);
    }
}