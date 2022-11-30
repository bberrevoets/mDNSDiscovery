using Makaretu.Dns;

namespace mDNSDiscovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mdns = new MulticastService();
            mdns.NetworkInterfaceDiscovered += (s, e) => mdns.SendQuery("_hwenergy._tcp");
            mdns.AnswerReceived += (s, e) => { 
                // do something with e.Message
                e.RemoteEndPoint.Address.ToString();
            };
                mdns.Start();

                Console.ReadLine();
        }
    }
}