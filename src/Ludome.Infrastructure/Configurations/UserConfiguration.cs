using Ludome.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ludome.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(360);

            builder
                .Property(x => x.Nickname)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
