namespace MFI.Domain.Contracts.Repositories.Base
{
    public interface UnityOfWorkContract
    {
        UserRepositoryContract User { get; }
        ClientRequesterRepositoryContract ClientRequester { get; }

        void BeginTransaction();

        void SaveChanges();

        void Commit();

        void Rowback();
    }
}