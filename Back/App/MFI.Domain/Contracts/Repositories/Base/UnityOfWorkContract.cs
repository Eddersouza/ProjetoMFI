namespace MFI.Domain.Contracts.Repositories.Base
{
    public interface UnityOfWorkContract
    {
        ClientProviderRepositoryContract ClientProvider { get; }
        ClientRequesterRepositoryContract ClientRequester { get; }
        UserRepositoryContract User { get; }

        void BeginTransaction();

        void Commit();

        void Rowback();

        void SaveChanges();
    }
}