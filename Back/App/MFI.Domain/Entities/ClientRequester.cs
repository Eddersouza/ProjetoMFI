namespace MFI.Domain.Entities
{
    public class ClientRequester : Client
    {
        public ClientRequester()
        {
        }

        public ClientRequester(
            string email,
            string name,
            User user) : base(email, name, user)
        {
            this.Type = Enums.ClientType.Requester;
        }
    }
}