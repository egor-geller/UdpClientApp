using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpClientApp;

class Program
{
    static void Main(string[] args)
    {
        const int listenPort = 9876;

        using UdpClient udpClient = new(listenPort);
        IPEndPoint remoteEp = new(IPAddress.Any, 0);

        Console.WriteLine($"Listening for UDP messages on port {listenPort}...");

        while (true)
        {
            try
            {
                byte[] data = udpClient.Receive(ref remoteEp);
                string message = Encoding.UTF8.GetString(data);

                Console.WriteLine($"[{remoteEp}] {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error receiving UDP message: {ex.Message}");
            }
        }
    }
}