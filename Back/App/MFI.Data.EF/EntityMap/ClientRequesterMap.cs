using MFI.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MFI.Data.EF.EntityMap
{
    public class ClientRequesterMap
        : EntityTypeConfiguration<ClientRequester>
    {
        public ClientRequesterMap()
        {
            ToTable("Clients");
        }
    }
}