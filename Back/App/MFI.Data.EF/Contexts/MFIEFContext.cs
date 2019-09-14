﻿using MFI.Data.EF.EntityMap;
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
        }
    }
}
