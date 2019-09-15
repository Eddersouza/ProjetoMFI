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

        /// <summary>
        /// Id From user entity.
        /// </summary>
        public Guid UserId { get; set; }


        /// <summary>
        /// User Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User Email
        /// </summary>
        public string Email { get; set; }
        
        public virtual List<Client> Clients { get; set; }
    }
}