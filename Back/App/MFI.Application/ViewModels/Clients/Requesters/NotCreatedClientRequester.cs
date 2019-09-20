﻿using MFI.Application.Base;

namespace MFI.Application.ViewModels.Clients.Requesters
{
    /// <summary>
    /// View to Create client Requester.
    /// </summary>
    public class NotCreatedClientRequester : MFIResult
    {
        /// <summary>
        /// Client Requester Email.
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// Client Requester Name.
        /// </summary>
        public string Name { get; set; }
    }
}