using MFI.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MFI.Data.EF.EntityMap
{
    public class ServiceMap
        : EntityTypeConfiguration<Service>
    {
        public ServiceMap()
        {
            ToTable("Services");

            HasKey(u => u.ServiceId);

            Property(u => u.ServiceId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(u => u.Name)
                .HasMaxLength(Service.NameMaxLength)
                .IsRequired();

            Property(u => u.Description)
                .HasMaxLength(Service.DescriptionMaxLength)
                .IsRequired();

            Property(e => e.CreateDate)
                .IsRequired();

            Property(e => e.CreatedByUserId)
                .HasMaxLength(36)
                .IsRequired();
        }
    }
}