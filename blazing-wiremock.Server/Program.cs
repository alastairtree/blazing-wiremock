// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using WireMock;
using WireMock.Net.StandAlone;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace blazing_wiremock.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var settings = new FluentMockServerSettings
            {
                AllowPartialMapping=false,
                StartAdminInterface=true,
                Port = 5555
            };
            var server = StandAloneApp.Start(settings);
            Console.WriteLine("FluentMockServer running at {0}", server.Ports.Single());

            server.Given(Request.Create().UsingGet().WithPath("/api"))
                .RespondWith(Response.Create().WithBodyAsJson(
                    new 
                    {
                        Message = "Welcome to the stub API"
                    }));

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .Build())
                .UseStartup<Startup>()
                .Build();
    }
}
