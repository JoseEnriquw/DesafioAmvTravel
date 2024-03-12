using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Client).HasMaxLength(100).IsRequired();

            builder.HasOne(x=> x.Tour)
                .WithMany(x=> x.Bookings)
                .HasForeignKey(x => x.TourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("booking_tourId_fk");

            builder.HasData(

                new Booking
                {
                    Id = 1,
                    Client = "Cliente1",
                    BookingDate = DateTime.Now,
                    TourId = 1,
                },  
                new Booking
                {
                    Id = 2,
                    Client = "Cliente2",
                    BookingDate = DateTime.Now.AddDays(1),
                    TourId = 2,
                },
                new Booking
                {
                    Id = 3,
                    Client = "Cliente3",
                    BookingDate = DateTime.Now.AddDays(2),
                    TourId = 3,
                }, 
                new Booking
                {
                    Id = 4,
                    Client = "Cliente4",
                    BookingDate = DateTime.Now.AddDays(2),
                    TourId = 3,
                });
        }

    }
}
