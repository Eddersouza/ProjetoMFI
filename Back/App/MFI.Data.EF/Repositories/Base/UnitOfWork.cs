using MFI.Data.EF.Contexts;
using MFI.Domain.Contracts.Repositories;
using MFI.Domain.Contracts.Repositories.Base;
using System.Data;
using System.Data.Entity;

namespace MFI.Data.EF.Repositories.Base
{
    public class UnitOfWork : UnityOfWorkContract
    {
        private readonly ClientProviderRepositoryContract _clientProviderRepository;
        private readonly ClientRequesterRepositoryContract _clientRequesterRepository;
        private readonly MFIEFContext _context;
        private readonly ServiceRepositoryContract _serviceRepository;
        private readonly UserRepositoryContract _userRepository;
        private DbContextTransaction _dbTransaction;

        public UnitOfWork(
            MFIEFContext context,
            UserRepositoryContract userRepository,
            ClientRequesterRepositoryContract clientRequesterRepository,
            ClientProviderRepositoryContract clientProviderRepository,
            ServiceRepositoryContract serviceRepository)
        {
            this._context = context;
            this._userRepository = userRepository;
            this._clientRequesterRepository = clientRequesterRepository;
            this._clientProviderRepository = clientProviderRepository;
            _serviceRepository = serviceRepository;
        }

        public ClientProviderRepositoryContract ClientProvider => _clientProviderRepository;
        public ClientRequesterRepositoryContract ClientRequester => _clientRequesterRepository;
        public ServiceRepositoryContract Service => _serviceRepository;
        public UserRepositoryContract User => _userRepository;

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