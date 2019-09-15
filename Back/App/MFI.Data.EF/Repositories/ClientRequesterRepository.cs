using MFI.Data.EF.Contexts;
using MFI.Data.EF.Repositories.Base;
using MFI.Domain.Contracts.Repositories;
using MFI.Domain.Entities;

namespace MFI.Data.EF.Repositories
{
    public class ClientRequesterRepository
        : BaseRepository<ClientRequester>, ClientRequesterRepositoryContract
    {
        public ClientRequesterRepository(MFIEFContext context) : base(context)
        {
        }
    }
}