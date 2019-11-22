using MFI.Data.EF.Contexts;
using MFI.Data.EF.Repositories.Base;
using MFI.Domain.Contracts.Repositories;
using MFI.Domain.Entities;

namespace MFI.Data.EF.Repositories
{
    public class ServiceRepository
        : BaseRepository<Service>, ServiceRepositoryContract
    {
        public ServiceRepository(MFIEFContext context) : base(context)
        {
        }
    }
}