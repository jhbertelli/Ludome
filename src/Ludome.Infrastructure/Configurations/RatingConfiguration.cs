using Ludome.Domain.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ludome.Infrastructure.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder
                .HasOne(x => x.CreatorUser)
                .WithMany()
                .HasForeignKey(x => x.CreatorUserId);
        }
    }
}
