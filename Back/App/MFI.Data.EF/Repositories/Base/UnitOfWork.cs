using MFI.Data.EF.Contexts;
using MFI.Domain.Contracts.Repositories;
using MFI.Domain.Contracts.Repositories.Base;
using System.Data;
using System.Data.Entity;

namespace MFI.Data.EF.Repositories.Base
{
    public class UnitOfWork : UnityOfWorkContract
    {
        private readonly MFIEFContext _context;
        private DbContextTransaction _dbTransaction;

        private readonly UserRepositoryContract _userRepository;
        private readonly ClientRequesterRepositoryContract _clientRequesterRepository;

        public UnitOfWork(
            MFIEFContext context,
            UserRepositoryContract userRepository,
            ClientRequesterRepositoryContract clientRequesterRepository)
        {
            this._context = context;
            this._userRepository = userRepository;
            this._clientRequesterRepository = clientRequesterRepository;
        }

        public UserRepositoryContract User => _userRepository;

        public ClientRequesterRepositoryContract ClientRequester => _clientRequesterRepository;

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