using System.Collections.Generic;

using CluedIn.Core.Crawling;
using CluedIn.Crawling.OData.Core;
using CluedIn.Crawling.OData.Core.Models;
using CluedIn.Crawling.OData.Infrastructure.Factories;

namespace CluedIn.Crawling.OData
{
    public class ODataCrawler : ICrawlerDataGenerator
    {
        private readonly IODataClientFactory clientFactory;
        public ODataCrawler(IODataClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public IEnumerable<object> GetData(CrawlJobData jobData)
        {
            if (!(jobData is ODataCrawlJobData odatacrawlJobData))
            {
                yield break;
            }

            var client = clientFactory.CreateNew(odatacrawlJobData);

            //retrieve data from provider and yield objects

            //TODO add example type
            foreach (var item in client.Get<Data>())
            {
                yield return item;
            }
            
        }       
    }
}
