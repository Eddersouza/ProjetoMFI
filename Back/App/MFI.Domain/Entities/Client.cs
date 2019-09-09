using edrsys.Utils.extensions;
using MFI.Domain.Enums;
using System;

namespace MFI.Domain.Entities
{
    public class Client : Entity
    {
        public Client()
        {
        }

        public Client(
            string email,
            string name,
            User user) : base()
        {
            this.ClientId = new Guid();
            this.Email = email;
            this.Name = name;
            this.User = user;

            CreatedByUserId = ClientId.ToString();
        }

        public Guid ClientId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public ClientType Type
        {
            get { return TypeCode.GetEnumByCode<ClientType>(ClientType.Requester); }
            set { TypeCode = value.GetCode(); }
        }

        public string TypeCode { get; set; }
        public User User { get; set; }
    }
}