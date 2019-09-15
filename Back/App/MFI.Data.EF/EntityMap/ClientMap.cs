using MFI.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MFI.Data.EF.EntityMap
{
    public class ClientMap
        : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            ToTable("Clients");

            Ignore(c => c.Type);

            HasKey(c => c.ClientId);

            Property(c => c.ClientId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            Property(c => c.Email)
                .HasMaxLength(Client.EmailMaxLength)
                .IsRequired();

            Property(c => c.Name)
                .HasMaxLength(Client.NameMaxLength)
                .IsRequired();

            Property(c => c.TypeCode)
                .HasMaxLength(Client.TypeCodeMaxLength)
                .IsRequired();

            Property(e => e.CreateDate)
                .IsRequired();

            Property(e => e.CreatedByUserId)
                .HasMaxLength(36)
                .IsRequired();

            HasRequired(client => client.User)
                .WithMany(user => user.Clients)
                .HasForeignKey(client => client.UserId);
        }
    }
}