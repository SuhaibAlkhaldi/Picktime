namespace Picktime.DTOs.Auth
{
    public class ClientInfo
    {
        public ClientInfo()
        {
            ClientIPAddress = null;
            ClientPort = -1;
        }
        public ClientInfo(string clientIPAddress, int clientPort)
        {
            ClientIPAddress = clientIPAddress;
            ClientPort = clientPort;
        }
        public string ClientIPAddress { get; set; }
        public int ClientPort { get; set; }
    }
}
