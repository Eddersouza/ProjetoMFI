using System;

namespace MFI.Domain.Entities
{
    public class User : Entity
    {
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
    }
}