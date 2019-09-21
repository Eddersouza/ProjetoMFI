using edrsys.EventNotification;
using edrsys.EventNotification.Levels;
using edrsys.Utils.extensions;
using MFI.Domain.Enums;
using System;

namespace MFI.Domain.Entities
{
    public class Client : Entity
    {
        public const int EmailMaxLength = 100;

        public const int NameMaxLength = 80;

        public const int NameMinLength = 6;

        public const int TypeCodeMaxLength = 20;

        private static EventNotificationDescription WarningEmptyEmail =
           new EventNotificationDescription(
               "O E-mail é obrigatório.",
               new EventNotificationWarning());

        private static EventNotificationDescription WarningEmptyName =
           new EventNotificationDescription(
               "O Nome é obrigatório.",
               new EventNotificationWarning());

        private static EventNotificationDescription WarningInvalidEmailPattern =
                   new EventNotificationDescription(
               "O E-mail está em formato inválido.",
               new EventNotificationWarning());

        private static EventNotificationDescription WarningNameGreatherMaximun =
            new EventNotificationDescription(
                string.Format("O Nome tem que ter menos que {0} caracteres.", NameMaxLength),
                new EventNotificationWarning());

        private static EventNotificationDescription WarningNameLessThanMinimun =
            new EventNotificationDescription(
                string.Format("O Nome tem que ter {0} ou mais caracteres.", NameMinLength),
                new EventNotificationWarning());

        public Client()
        {
        }

        public Client(
            string email,
            string name,
            User user) : base()
        {
            this.ClientId = Guid.NewGuid();
            this.Email = email;
            this.Name = name;
            this.User = user;

            CreatedByUserId = user.UserId.ToString();
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

        public virtual User User { get; set; }

        public Guid UserId { get; set; }

        public void ValidadeToCreation()
        {
            TestCondition(this.Email.IsNullOrEmpty(), WarningEmptyEmail);
            TestCondition(!this.Email.IsEmail(), WarningInvalidEmailPattern);

            TestCondition(this.Name.IsNullOrEmpty(), WarningEmptyName);
            TestCondition(this.Name.LengthLessThan(NameMinLength), WarningNameLessThanMinimun);
            TestCondition(this.Name.LengthGreatherThan(NameMaxLength), WarningNameGreatherMaximun);
        }
    }
}