using MFI.Application.Base;
using MFI.Domain.Enums;

namespace MFI.Application.Interfaces
{
    public interface UserAppContract
    {
        MFIResult Login(
           string email,
           string password,
           ClientType? type);
    }
}