namespace MFI.Domain.Contracts.Repositories.Base
{
    public interface UnityOfWorkContract
    {
        ClientProviderRepositoryContract ClientProvider { get; }
        ClientRequesterRepositoryContract ClientRequester { get; }
        ProviderServiceRepositoryContract ProviderService { get; }
        ServiceRepositoryContract Service { get; }
        UserRepositoryContract User { get; }

        void BeginTransaction();

        void Commit();

        void Rowback();

        void SaveChanges();
    }
}