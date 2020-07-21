using CluedIn.Crawling.OData.Core;

namespace CluedIn.Crawling.OData.Infrastructure.Factories
{
    public interface IODataClientFactory
    {
        ODataClient CreateNew(ODataCrawlJobData odataCrawlJobData);
    }
}
