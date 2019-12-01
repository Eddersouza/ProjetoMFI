using System;

namespace MFI.Domain.Entities
{
    public class ProviderService : Entity
    {
        public Guid ClientId { get; set; }
        public decimal MinimunAmount { get; set; }
        public ClientProvider Provider { get; set; }
        public virtual Service Service { get; set; }
        public int ServiceId { get; set; }
    }
}