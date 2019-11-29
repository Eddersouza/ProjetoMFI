using System;

namespace MFI.Domain.Entities
{
    public class ProviderService
    {
        public decimal MinimunAmount { get; set; }
        public virtual Service Service { get; set; }
        public int ServiceId { get; set; }

        public ClientProvider Provider { get; set; }

        public Guid ClientId { get; set; }

    }
}