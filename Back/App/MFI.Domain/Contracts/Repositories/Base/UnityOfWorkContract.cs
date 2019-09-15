namespace MFI.Domain.Contracts.Repositories.Base
{
    public interface UnityOfWorkContract
    {
        void BeginTransaction();

        void SaveChanges();

        void Commit();

        void Rowback();
    }
}