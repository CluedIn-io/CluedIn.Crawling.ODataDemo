using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CluedIn.Core;
using CluedIn.Core.Data;
using CluedIn.Crawling.Factories;
using CluedIn.Crawling.Helpers;
using CluedIn.Crawling.OData.Core.Models;
using CluedIn.Crawling.OData.Vocabularies;

namespace CluedIn.Crawling.OData.ClueProducers
{
    public class DataProducer : BaseClueProducer<Data>
    {
        private readonly IClueFactory _factory;
        public DataProducer([NotNull] IClueFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            _factory = factory;
        }
        protected override Clue MakeClueImpl([NotNull] Data input, Guid accountId)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            var clue = _factory.Create(EntityType.Infrastructure.User, input.AccountId.ToString(), accountId);

            var data = clue.Data.EntityData;

            if (!string.IsNullOrEmpty(input.FirstName))
                data.Name = input.FirstName.ToString();

            var vocab = new DataVocabulary();

            if (!string.IsNullOrEmpty(input.CreatedByName))
            {
                data.Authors.Add(input.CreatedByName);
            }

            if (!string.IsNullOrEmpty(input.Address1AddressId))
                _factory.CreateOutgoingEntityReference(clue, EntityType.Location.Address, EntityEdgeType.Parent, input, input.Address1AddressId);

            if (!data.OutgoingEdges.Any())
                _factory.CreateEntityRootReference(clue, EntityEdgeType.PartOf);

            data.Properties[vocab.AccountId] = input.AccountId.PrintIfAvailable();
            data.Properties[vocab.AccountName] = input.AccountName.PrintIfAvailable();
            data.Properties[vocab.Address1AddressId] = input.Address1AddressId.PrintIfAvailable();
            data.Properties[vocab.Address1City] = input.Address1City.PrintIfAvailable();
            data.Properties[vocab.Address1Composite] = input.Address1Composite.PrintIfAvailable();
            data.Properties[vocab.Address1Country] = input.Address1Country.PrintIfAvailable();
            data.Properties[vocab.CreatedByName] = input.CreatedByName.PrintIfAvailable();
            data.Properties[vocab.FirstName] = input.FirstName.PrintIfAvailable();

            return clue;
        }
    }
}
