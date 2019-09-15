using MFI.Domain.Entities;
using MFI.Utils;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MFI.Data.EF.EntityMap
{
    public class UserMap
        : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("Users");

            HasKey(u => u.UserId);

            this.Property(c => c.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            this.Property(u => u.Password)
                .HasMaxLength(User.PasswordWhithEncriptMaxLength)
                .IsRequired();

            this.Property(u => u.Email)
                .HasMaxLength(User.EmailMaxLength)
                .IsRequired();

            this.Property(e => e.CreateDate)
                .IsRequired();

            this.Property(e => e.CreatedByUserId)
                .HasMaxLength(36)
                .IsRequired();
        }
    }
}