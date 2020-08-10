using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CluedIn.Core.Logging;
using CluedIn.Core.Providers;
using CluedIn.Crawling.OData.Core;
using CluedIn.Crawling.OData.Core.Models;
using Newtonsoft.Json;
using RestSharp;

namespace CluedIn.Crawling.OData.Infrastructure
{
    // TODO - This class should act as a client to retrieve the data to be crawled.
    // It should provide the appropriate methods to get the data
    // according to the type of data source (e.g. for AD, GetUsers, GetRoles, etc.)
    // It can receive a IRestClient as a dependency to talk to a RestAPI endpoint.
    // This class should not contain crawling logic (i.e. in which order things are retrieved)
    public class ODataClient
    {
        private const string BaseUri = "http://sample.com";

        private readonly ILogger log;

        private readonly IRestClient client;
        private readonly ODataCrawlJobData _oDataCrawlJobData;

        public ODataClient(ILogger log, ODataCrawlJobData odataCrawlJobData, IRestClient client) // TODO: pass on any extra dependencies
        {
            if (odataCrawlJobData == null)
            {
                throw new ArgumentNullException(nameof(odataCrawlJobData));
            }
            _oDataCrawlJobData = odataCrawlJobData ?? throw new ArgumentNullException(nameof(odataCrawlJobData));

            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            this.log = log ?? throw new ArgumentNullException(nameof(log));
            this.client = client ?? throw new ArgumentNullException(nameof(client));

            // TODO use info from odataCrawlJobData to instantiate the connection
            client.BaseUrl = new Uri(BaseUri);
            client.AddDefaultParameter("api_key", odataCrawlJobData.Url, ParameterType.QueryString);
        }

        private async Task<T> GetAsync<T>(string url)
        {
            var request = new RestRequest(url, Method.GET);

            var response = await client.ExecuteTaskAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var diagnosticMessage = $"Request to {client.BaseUrl}{url} failed, response {response.ErrorMessage} ({response.StatusCode})";
                log.Error(() => diagnosticMessage);
                throw new InvalidOperationException($"Communication to jsonplaceholder unavailable. {diagnosticMessage}");
            }

            var data = JsonConvert.DeserializeObject<T>(response.Content);

            return data;
        }

        public AccountInformation GetAccountInformation()
        {
            //TODO - return some unique information about the remote data source
            // that uniquely identifies the account
            return new AccountInformation("", "");
        }

        public IEnumerable<T> Get<T>()
        {

            DateTimeOffset lastCrawlFinishTime;
            if (_oDataCrawlJobData.LastCrawlFinishTime == DateTimeOffset.Parse("1/1/0001 12:00:00 AM +00:00"))
            {
                lastCrawlFinishTime = DateTimeOffset.Parse("01/01/1753 00:00:00");
            }
            else
            {
                lastCrawlFinishTime = _oDataCrawlJobData.LastCrawlFinishTime;
            }
            //TODO replace with values from config
            var url = "";
            var token = "";

            ResultList<T> resultList = null;

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.Timeout = new TimeSpan(0, 2, 0);
                httpClient.DefaultRequestHeaders.Add("Prefer", "odata.maxpagesize=100");
                httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
                httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = httpClient.GetAsync(url).Result;
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //TODO: add token refresh
                }
                else if (responseMessage.StatusCode != HttpStatusCode.OK)
                {
                    //TODO log error
                }


                resultList = JsonConvert.DeserializeObject<ResultList<T>>(content, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                if (resultList?.Value != null)
                {
                    foreach (var item in resultList.Value)
                        yield return item;
                }
            }
        }
    }
}
