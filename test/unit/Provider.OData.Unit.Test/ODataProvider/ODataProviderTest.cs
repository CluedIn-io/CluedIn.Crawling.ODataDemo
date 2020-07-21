using Castle.Windsor;
using CluedIn.Core;
using CluedIn.Core.Providers;
using CluedIn.Crawling.OData.Infrastructure.Factories;
using Moq;

namespace CluedIn.Provider.OData.Unit.Test.ODataProvider
{
    public abstract class ODataProviderTest
    {
        protected readonly ProviderBase Sut;

        protected Mock<IODataClientFactory> NameClientFactory;
        protected Mock<IWindsorContainer> Container;

        protected ODataProviderTest()
        {
            Container = new Mock<IWindsorContainer>();
            NameClientFactory = new Mock<IODataClientFactory>();
            var applicationContext = new ApplicationContext(Container.Object);
            Sut = new OData.ODataProvider(applicationContext, NameClientFactory.Object);
        }
    }
}
