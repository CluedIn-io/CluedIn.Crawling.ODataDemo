using CluedIn.Core.Crawling;

namespace CluedIn.Crawling.OData.Core
{
    public class ODataCrawlJobData : CrawlJobData
    {
        public string Url { get; set; }
        public string Token { get; set; }
    }
}
