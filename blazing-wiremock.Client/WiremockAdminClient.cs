using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using blazing_wiremock.Client;
using Microsoft.AspNetCore.Blazor;
using WireMock.Admin.Mappings;
using WireMock.Logging;

namespace blazingwiremock.Client
{
    public class WiremockAdminClient
    {
        private readonly HttpClient client;

        public WiremockAdminClient(HttpClient client)
        {
             client.BaseAddress = new Uri(Program.WiremockApiLocation);
           this.client = client;
        }

        public Task<IList<LogEntryModel>> GetRequestsAsync()
        {
            // TODO: this gets rejected because the server does not specifiy CORS headers. Admin API needs to allow cors.
            return client.GetJsonAsync<IList<LogEntryModel>>("__admin/requests");
        }

        public Task<IList<MappingModel>> GetMappingsAsync()
        {
            return client.GetJsonAsync<IList<MappingModel>>("/__admin/mappings");
        }
    }

    public class LogEntryModel
    {
        /// <summary>
        /// The unique identifier.
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// The request.
        /// </summary>
        public LogRequestModel Request { get; set; }

        /// <summary>
        /// The response.
        /// </summary>
        //public LogResponseModel Response { get; set; }

        /// <summary>
        /// The mapping unique identifier.
        /// </summary>
        public Guid? MappingGuid { get; set; }

        /// <summary>
        /// The mapping unique title.
        /// </summary>
        public string MappingTitle { get; set; }

        /// <summary>
        /// The request match result.
        /// </summary>
        //public LogRequestMatchModel RequestMatchResult { get; set; }
    }

    public class LogRequestModel
    {
        /// <summary>
        /// The Client IP Address.
        /// </summary>
        public string ClientIP { get; set; }

        /// <summary>
        /// The DateTime.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// The Path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        ///The absolete URL.
        /// </summary>
        public string AbsoluteUrl { get; set; }

        /// <summary>
        /// The query.
        /// </summary>
        //public IDictionary<string, WireMockList<string>> Query { get; set; }

        /// <summary>
        /// The method.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// The Headers.
        /// </summary>
        //public IDictionary<string, WireMockList<string>> Headers { get; set; }

        /// <summary>
        /// Tthe Cookies.
        /// </summary>
        public IDictionary<string, string> Cookies { get; set; }

        /// <summary>
        /// The body (as string).
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// The body (as JSON object).
        /// </summary>
        public object BodyAsJson { get; set; }

        /// <summary>
        /// The body (as bytearray).
        /// </summary>
        public byte[] BodyAsBytes { get; set; }

        /// <summary>
        /// The body encoding.
        /// </summary>
        //public EncodingModel BodyEncoding { get; set; }
    }
}
