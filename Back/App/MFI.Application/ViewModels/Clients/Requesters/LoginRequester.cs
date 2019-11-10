using MFI.Application.Base;
using MFI.Domain.Entities;

namespace MFI.Application.ViewModels.Clients.Requesters
{
    public class LoginRequester : MFIResult
    {
        public SystemUser User { get; set; }
    }
}