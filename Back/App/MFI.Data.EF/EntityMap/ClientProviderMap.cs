using MFI.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MFI.Data.EF.EntityMap
{
    public class ClientProviderMap
        : EntityTypeConfiguration<ClientProvider>
    {
        public ClientProviderMap()
        {
            ToTable("Clients");

            Property(c => c.Description)
                .HasMaxLength(ClientProvider.DescriptionMaxLength)
                .IsRequired();

            Property(c => c.CompanyName)
                .HasMaxLength(ClientProvider.CompanyNameMaxLength)
                .IsOptional();
        }
    }
}