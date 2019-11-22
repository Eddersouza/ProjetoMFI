namespace MFI.Data.EF.Migrations
{
    using MFI.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MFI.Data.EF.Contexts.MFIEFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MFI.Data.EF.Contexts.MFIEFContext context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            DbSet<Service> _dbsetService = context.Set<Service>();

            DateTime creationDate = DateTime.Now;

            if (!_dbsetService.Any())
            {
                _dbsetService.AddOrUpdate(
                    new Service
                    {
                        CreateDate = creationDate,
                        CreatedByUserId = "System",
                        Description = "Fotos e álbuns para sua festa.",
                        Name = "Fotos"
                    },
                    new Service
                    {
                        CreateDate = creationDate,
                        CreatedByUserId = "System",
                        Description = "Locais para fazer as festas.",
                        Name = "Locais"
                    },
                    new Service
                    {
                        CreateDate = creationDate,
                        CreatedByUserId = "System",
                        Description = "Brindes e lembranças para serem distribuidos para as crianças.",
                        Name = "Brindes e Lembranças"
                    },
                    new Service
                    {
                        CreateDate = creationDate,
                        CreatedByUserId = "System",
                        Description = "Salgados para festas.",
                        Name = "Salgados"
                    },
                    new Service
                    {
                        CreateDate = creationDate,
                        CreatedByUserId = "System",
                        Description = "Decoração de ambientes.",
                        Name = "Decoração"
                    },
                    new Service
                    {
                        CreateDate = creationDate,
                        CreatedByUserId = "System",
                        Description = "Brinquedos para festas.",
                        Name = "Brinquedos"
                    });

                context.SaveChanges();
            }
        }
    }
}
