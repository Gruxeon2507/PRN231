using Microsoft.EntityFrameworkCore;

namespace Assignment02.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<MedicalFacility> MedicalFacilities { get; set; }
        public DbSet<ServicePriceList> ServicePriceLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalFacility>(entity =>
            {
                entity.HasKey(e => e.FacilityId).HasName("PK_MedicalfacilityId");

                entity.ToTable("MedicalFacility");
            });

            modelBuilder.Entity<ServicePriceList>(entity =>
            {
                entity.HasKey(e => e.ServiceId).HasName("PK_SerivceId");

                entity.ToTable("ServicePriceList");
            });
        }
    }
}
