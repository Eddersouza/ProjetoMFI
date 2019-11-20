using edrsys.Utils.Helpers;
using MFI.Domain.Enums;

namespace MFI.Domain.Entities
{
    public class SystemUser
    {
        public SystemUser()
        {
            this.Roles = new string[] { };
        }

        public SystemUser(
              string userId,
              string userName,
              string userEmail,
              string[] roles)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.UserEmail = userEmail;
            this.Roles = roles;
        }

        public ClientType ClientType { get; set; }
        public string[] Roles { get; set; }
        public string UserEmail { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        public override string ToString()
        {
            return EntityHelper.ToJSON(this);
        }
    }
}