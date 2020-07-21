using CluedIn.Core.Crawling;
using CluedIn.Crawling;
using CluedIn.Crawling.OData;
using CluedIn.Crawling.OData.Infrastructure.Factories;
using Moq;
using Should;
using Xunit;

namespace Crawling.OData.Unit.Test
{
    public class ODataCrawlerBehaviour
    {
        private readonly ICrawlerDataGenerator _sut;

        public ODataCrawlerBehaviour()
        {
            var nameClientFactory = new Mock<IODataClientFactory>();

            _sut = new ODataCrawler(nameClientFactory.Object);
        }

        [Fact]
        public void GetDataReturnsData()
        {
            var jobData = new CrawlJobData();

            _sut.GetData(jobData)
                .ShouldNotBeNull();
        }
    }
}
