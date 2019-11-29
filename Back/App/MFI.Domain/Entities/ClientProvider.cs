using edrsys.EventNotification;
using edrsys.EventNotification.Levels;
using edrsys.Utils.extensions;
using System.Collections.Generic;

namespace MFI.Domain.Entities
{
    public class ClientProvider : Client
    {
        public const int CompanyNameMaxLength = 80;
        public const int CompanyNameMinLength = 10;
        public const int DescriptionMaxLength = 500;
        public const int DescriptionMinLength = 10;

        private static EventNotificationDescription WarningCompanyNameGreatherMaximun =
            new EventNotificationDescription(
                string.Format("A Razão Social tem que ter menos que {0} caracteres.", CompanyNameMaxLength),
                new EventNotificationWarning());

        private static EventNotificationDescription WarningCompanyNameLessThanMinimun =
            new EventNotificationDescription(
                string.Format("A Razão Social tem que ter {0} ou mais caracteres.", CompanyNameMinLength),
                new EventNotificationWarning());

        private static EventNotificationDescription WarningDescriptionEmpty =
                            new EventNotificationDescription(
                "A Descrição é obrigatória.",
                new EventNotificationWarning());

        private static EventNotificationDescription WarningDescriptionGreatherMaximun =
            new EventNotificationDescription(
                string.Format("A Descrição tem que ter menos que {0} caracteres.", DescriptionMaxLength),
                new EventNotificationWarning());

        private static EventNotificationDescription WarningDescriptionLessThanMinimun =
            new EventNotificationDescription(
                string.Format("A Descrição tem que ter {0} ou mais caracteres.", DescriptionMinLength),
                new EventNotificationWarning());

        public ClientProvider()
        {
        }

        public ClientProvider(
           string email,
           string name,
           string companyName,
           string description,
           User user) : base(email, name, user)
        {
            this.Type = Enums.ClientType.Provider;
            this.CompanyName = companyName;
            this.Description = description;
        }

        public string CompanyName { get; set; }
        public string Description { get; set; }
        public virtual IList<ProviderService> ProviderServices { get; set; }

        public override void ValidadeToCreation()
        {
            base.ValidadeToCreation();

            TestCondition(
                this.Description.IsNullOrEmpty(),
                WarningDescriptionEmpty);
            TestCondition(
                this.Description.LengthLessThan(DescriptionMinLength),
                WarningDescriptionLessThanMinimun);
            TestCondition(
                this.Description.LengthGreatherThan(DescriptionMaxLength),
                WarningDescriptionGreatherMaximun);

            if (!this.CompanyName.IsNullOrEmpty())
            {
                TestCondition(
                    this.CompanyName.LengthLessThan(CompanyNameMinLength),
                    WarningCompanyNameLessThanMinimun);
                TestCondition(
                    this.CompanyName.LengthGreatherThan(CompanyNameMaxLength),
                    WarningCompanyNameGreatherMaximun);
            }
        }
    }
}