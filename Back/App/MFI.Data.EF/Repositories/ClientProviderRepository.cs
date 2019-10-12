using MFI.Data.EF.Contexts;
using MFI.Data.EF.Repositories.Base;
using MFI.Domain.Contracts.Repositories;
using MFI.Domain.Entities;

namespace MFI.Data.EF.Repositories
{
    public class ClientProviderRepository
        : BaseRepository<ClientProvider>, ClientProviderRepositoryContract
    {
        public ClientProviderRepository(MFIEFContext context) : base(context)
        {
        }
    }
}