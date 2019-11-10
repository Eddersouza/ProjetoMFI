using edrsys.Utils.Attributes;

namespace MFI.Domain.Enums
{
    public enum ClientType
    {
        [Code("Requester")]
        Requester,

        [Code("Provider")]
        Provider
    }
}