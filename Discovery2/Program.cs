using Zeroconf;

namespace Discovery2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await ProbeForNetworkPrinters();
        }
        
        public static async Task ProbeForNetworkPrinters()
        {
            IReadOnlyList<IZeroconfHost> results = await
                ZeroconfResolver.ResolveAsync("_printer._tcp.local.");
            Console.WriteLine("");
        }

        public static async Task EnumerateAllServicesFromAllHosts()
        {
            ILookup<string, string> domains = await ZeroconfResolver.BrowseDomainsAsync();            
            var responses = await ZeroconfResolver.ResolveAsync(domains.Select(g => g.Key));            
            foreach (var resp in responses)
                Console.WriteLine(resp);
        }
    }
}