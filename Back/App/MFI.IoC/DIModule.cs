using MFI.Application;
using MFI.Application.Interfaces;
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
        }

        private static void RegisterRepositories(
            Container container,
            Lifestyle lifestyle)
        {
            //container.Register(typeof(BaseRepositoryContract<>), typeof(BaseRepository<>), lifestyle);
            //container.Register<FestINFMSSQLContext>(lifestyle);
        }
    }
}