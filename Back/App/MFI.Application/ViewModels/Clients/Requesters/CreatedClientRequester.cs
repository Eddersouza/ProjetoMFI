using MFI.Application.Base;

namespace MFI.Application.ViewModels.Clients.Requesters
{
    /// <summary>
    /// View to Create client Requester.
    /// </summary>
    public class CreatedClientRequester : MFIResult
    {
        /// <summary>
        /// Client Requester Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Client Requester Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Client Requester Name.
        /// </summary>
        public string Name { get; set; }
    }
}