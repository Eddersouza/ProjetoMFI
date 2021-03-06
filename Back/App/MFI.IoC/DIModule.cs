﻿using MFI.Application;
using MFI.Application.Interfaces;
using MFI.Data.EF.Contexts;
using MFI.Data.EF.Repositories;
using MFI.Data.EF.Repositories.Base;
using MFI.Domain.Contracts.Repositories;
using MFI.Domain.Contracts.Repositories.Base;
using SimpleInjector;

namespace MFI.IoC
{
    public class DIModule
    {
        public static void InitializeIoc(
            Container container,
            Lifestyle lifestyle)
        {
            RegisterApps(container, lifestyle);
            RegisterRepositories(container, lifestyle);

            container.Verify();
        }

        private static void RegisterApps(
            Container container,
            Lifestyle lifestyle)
        {
            container.Register<ClientRequesterAppContract, ClientRequesterApp>(lifestyle); 
            container.Register<ClientProviderAppContract, ClientProviderApp>(lifestyle);
            container.Register<ProviderServiceAppContract, ProviderServiceApp>(lifestyle);
            container.Register<ServiceAppContract, ServiceApp>(lifestyle);
            container.Register<UserAppContract, UserApp>(lifestyle);
        }

        private static void RegisterRepositories(
            Container container,
            Lifestyle lifestyle)
        {
            container.Register<ClientProviderRepositoryContract, ClientProviderRepository>(lifestyle);
            container.Register<ClientRequesterRepositoryContract, ClientRequesterRepository>(lifestyle);
            container.Register<ProviderServiceRepositoryContract, ProviderServiceRepository>(lifestyle);
            container.Register<ServiceRepositoryContract, ServiceRepository>(lifestyle);
            container.Register<UserRepositoryContract, UserRepository>(lifestyle);
            container.Register<UnityOfWorkContract, UnitOfWork>(lifestyle);
            container.Register(typeof(BaseRepositoryContract<>), typeof(BaseRepository<>), lifestyle);
            container.Register<MFIEFContext>(lifestyle);
        }
    }
}