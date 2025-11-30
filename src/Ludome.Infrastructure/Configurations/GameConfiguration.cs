using Ludome.Domain.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ludome.Infrastructure.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .HasMany(g => g.Ratings)
                .WithOne();

            builder
                .HasMany(g => g.Developers)
                .WithMany(d => d.Games);

            builder
                .HasMany(g => g.Publishers)
                .WithMany(p => p.Games);

            builder
                .HasMany(g => g.Categories)
                .WithMany();
        }
    }
}
