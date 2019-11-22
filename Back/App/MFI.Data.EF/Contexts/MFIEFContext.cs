using MFI.Data.EF.EntityMap;
using MFI.Utils;
using MySql.Data.Entity;
using System.Data.Entity;

namespace MFI.Data.EF.Contexts
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MFIEFContext : DbContext
    {
        public MFIEFContext()
            : base(MFISetting.ConnectionStringBase)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new ClientRequesterMap());
            modelBuilder.Configurations.Add(new ClientProviderMap());
            modelBuilder.Configurations.Add(new ServiceMap());
        }
    }
}
