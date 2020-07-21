using CluedIn.Crawling.OData.Core;

namespace CluedIn.Crawling.OData
{
    public class ODataCrawlerJobProcessor : GenericCrawlerTemplateJobProcessor<ODataCrawlJobData>
    {
        public ODataCrawlerJobProcessor(ODataCrawlerComponent component) : base(component)
        {
        }
    }
}
