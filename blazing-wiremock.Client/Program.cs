using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;
using blazingwiremock.Client;
using RestEase;
using WireMock.Client;

namespace blazing_wiremock.Client
{
    public class Program
    {
        public static string WiremockApiLocation = "http://localhost:5555";

        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(services =>
            {
                // Add any custom services here
                services.AddSingleton<WiremockAdminClient>();
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}
