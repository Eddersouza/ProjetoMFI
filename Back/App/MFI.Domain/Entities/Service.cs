using System;
using System.Collections.Generic;

namespace MFI.Domain.Entities
{
    public class Service : Entity
    {
        public const int DescriptionMaxLength = 200;
        public const int NameMaxLength = 40;

        public Service()
        {
        }

        public Service(
            string userId,
            string name,
            string description)
        {
            CreateDate = DateTime.Now;
            CreatedByUserId = userId;
            Name = name;
            Description = description;
        }

        public string Description { get; set; }
        public string Name { get; set; }
        public virtual IList<ProviderService> ProviderServices { get; set; }
        public int ServiceId { get; set; }
    }
}