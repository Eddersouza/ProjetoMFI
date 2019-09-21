using edrsys.EventNotification;
using edrsys.EventNotification.Levels;
using edrsys.Utils.extensions;
using System;
using System.Collections.Generic;

namespace MFI.Domain.Entities
{
    public class User : Entity
    {
        /// <summary>
        /// Max length to Email.
        /// </summary>
        public const int EmailMaxLength = 100;

        /// <summary>
        /// Max length to Passowrd with encript.
        /// </summary>
        public const int PasswordWhithEncriptMaxLength = 36;

        /// <summary>
        /// Max length to Passowrd without encript.
        /// </summary>
        public const int PasswordWhithoutEncriptMaxLength = 12;

        /// <summary>
        /// Min length to Passowrd without encript.
        /// </summary>
        public const int PasswordWhithoutEncriptMinLength = 6;

        private static EventNotificationDescription WarningEmptyEmail =
            new EventNotificationDescription(
                "O E-mail é obrigatório.",
                new EventNotificationWarning());

        private static EventNotificationDescription WarningEmptyPassword =
            new EventNotificationDescription(
                "A Senha é obrigatória.",
                new EventNotificationWarning());

        private static EventNotificationDescription WarningInvalidEmailPattern =
            new EventNotificationDescription(
                "O E-mail está em formato inválido.",
                new EventNotificationWarning());

        private static EventNotificationDescription WarningPasswordWithoutEncriptGreatherMaximun =
                                    new EventNotificationDescription(
                string.Format("A Senha tem que ter menos que {0} caracteres.", PasswordWhithoutEncriptMaxLength),
                new EventNotificationWarning());

        private static EventNotificationDescription WarningPasswordWithoutEncriptLessThanMinimun =
            new EventNotificationDescription(
                string.Format("A Senha tem que ter mais que {0} caracteres.", PasswordWhithoutEncriptMinLength),
                new EventNotificationWarning());

        /// <summary>
        /// Create Empty user Entity.
        /// </summary>
        public User() : base()
        {
        }

        /// <summary>
        /// Create new User.
        /// </summary>
        /// <param name="email">Email to user.</param>
        /// <param name="password">Password To User.</param>
        public User(
            string email,
            string password) : this()
        {
            this.UserId = Guid.NewGuid();
            this.Email = email;
            this.Password = password;

            CreatedByUserId = UserId.ToString();
        }

        public virtual List<Client> Clients { get; set; }

        /// <summary>
        /// User Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Id From user entity.
        /// </summary>
        public Guid UserId { get; set; }

        public void EncriptPassword()
        {
            if (!string.IsNullOrEmpty(this.Password))
                this.Password = this.Password.Encrypt(string.Format(this.UserId.ToString()));
        }

        public void ValidadeToCreation()
        {
            TestCondition(string.IsNullOrEmpty(this.Email), WarningEmptyEmail);
            TestCondition(!this.Email.IsEmail(), WarningInvalidEmailPattern);

            TestCondition(string.IsNullOrEmpty(this.Password), WarningEmptyPassword);
            TestCondition(
                (this.Password ?? string.Empty).Length < PasswordWhithoutEncriptMinLength,
                WarningPasswordWithoutEncriptLessThanMinimun);
            TestCondition(
                (this.Password ?? string.Empty).Length >
                PasswordWhithoutEncriptMaxLength,
                WarningPasswordWithoutEncriptGreatherMaximun);
        }
    }
}