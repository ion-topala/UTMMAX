using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UTMMAX.Domain.Entities.User;

namespace UTMMAX.Repository.Mappings;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable(DbTable.User);

        builder.Ignore(entity => entity.FullName);
    }
}