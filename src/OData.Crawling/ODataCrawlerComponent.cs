using CluedIn.Core;
using CluedIn.Crawling.OData.Core;

using ComponentHost;

namespace CluedIn.Crawling.OData
{
    [Component(ODataConstants.CrawlerComponentName, "Crawlers", ComponentType.Service, Components.Server, Components.ContentExtractors, Isolation = ComponentIsolation.NotIsolated)]
    public class ODataCrawlerComponent : CrawlerComponentBase
    {
        public ODataCrawlerComponent([NotNull] ComponentInfo componentInfo)
            : base(componentInfo)
        {
        }
    }
}

