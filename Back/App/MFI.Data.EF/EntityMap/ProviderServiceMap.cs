using MFI.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MFI.Data.EF.EntityMap
{
    public class ProviderServiceMap : EntityTypeConfiguration<ProviderService>
    {
        public ProviderServiceMap()
        {
            ToTable("ProviderServices");

            HasKey(serviceProvider => new { serviceProvider.ClientId, serviceProvider.ServiceId });

            Property(serviceProvider => serviceProvider.ClientId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(serviceProvider => serviceProvider.ServiceId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();

            Property(serviceProvider => serviceProvider.CreateDate)
              .IsRequired();

            Property(serviceProvider => serviceProvider.CreatedByUserId)
                .HasMaxLength(36)
                .IsRequired();

            HasRequired(serviceProvider => serviceProvider.Service)
                .WithMany(service => service.ProviderServices)
                .HasForeignKey(serviceProvider => serviceProvider.ServiceId);

            HasRequired(serviceProvider => serviceProvider.Provider)
                .WithMany(provider => provider.ProviderServices)
                .HasForeignKey(serviceProvider => serviceProvider.ClientId);

            Property(serviceProvider => serviceProvider.MinimunAmount).IsRequired();

        }
    }
}