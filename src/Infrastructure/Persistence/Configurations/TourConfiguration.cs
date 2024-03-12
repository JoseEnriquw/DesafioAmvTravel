using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations
{
    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Tour> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Destiny).HasMaxLength(200).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();

            builder.HasData(
                new Tour
                {
                    Id = 1,
                    Name = "Tour A",
                    Destiny = "City A",
                    StartDate = DateTime.Now.AddDays(7),
                    EndDate = DateTime.Now.AddDays(14),
                    Price = 1000
                },
                new Tour
                {
                    Id = 2,
                    Name = "Tour B",
                    Destiny = "City B",
                    StartDate = DateTime.Now.AddDays(21),
                    EndDate = DateTime.Now.AddDays(28),
                    Price = 1200
                },
                new Tour
                {
                    Id = 3,
                    Name = "Tour C",
                    Destiny = "City C",
                    StartDate = DateTime.Now.AddDays(30),
                    EndDate = DateTime.Now.AddDays(37),
                    Price = 800.25m
                });
        }

    }
}
