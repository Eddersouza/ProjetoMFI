using MFI.Data.EF.Contexts;
using MFI.Domain.Contracts.Repositories.Base;
using System.Data;
using System.Data.Entity;

namespace MFI.Data.EF.Repositories.Base
{
    public class UnitOfWork : UnityOfWorkContract
    {
        private readonly MFIEFContext _context;
        private DbContextTransaction _dbTransaction;

        public UnitOfWork(MFIEFContext context)
        {
            this._context = context;
        }

        public void BeginTransaction()
        {
            _dbTransaction = this._context.Database.
                BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        public void Commit()
        {
            this._dbTransaction.Commit();
        }

        public void Rowback()
        {
            this._dbTransaction.Rollback();
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}