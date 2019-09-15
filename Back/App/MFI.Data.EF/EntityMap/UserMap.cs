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

            Property(u => u.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            Property(u => u.Password)
                .HasMaxLength(User.PasswordWhithEncriptMaxLength)
                .IsRequired();

            Property(u => u.Email)
                .HasMaxLength(User.EmailMaxLength)
                .IsRequired();

            Property(e => e.CreateDate)
                .IsRequired();

            Property(e => e.CreatedByUserId)
                .HasMaxLength(36)
                .IsRequired();
        }
    }
}