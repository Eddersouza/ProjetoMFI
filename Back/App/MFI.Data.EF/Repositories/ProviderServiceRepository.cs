using MFI.Data.EF.Contexts;
using MFI.Data.EF.Repositories.Base;
using MFI.Domain.Contracts.Repositories;
using MFI.Domain.Entities;

namespace MFI.Data.EF.Repositories
{
    public class ProviderServiceRepository
        : BaseRepository<ProviderService>, ProviderServiceRepositoryContract
    {
        public ProviderServiceRepository(MFIEFContext context) : base(context)
        {
        }
    }
}