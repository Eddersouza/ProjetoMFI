using edrsys.Utils.Attributes;

namespace MFI.Domain.Enums
{
    /// <summary>
    /// Possible Client Types.
    /// </summary>
    public enum ClientType
    {
        /// <summary>
        /// Service Requester.
        /// </summary>
        [Code("Requester")]
        Requester,

        /// <summary>
        /// Provider Requester.
        /// </summary>
        [Code("Provider")]
        Provider
    }
}