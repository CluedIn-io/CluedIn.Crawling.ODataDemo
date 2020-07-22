using CluedIn.Core.Data;
using CluedIn.Core.Data.Vocabularies;

namespace CluedIn.Crawling.OData.Vocabularies
{
    public class DataVocabulary : SimpleVocabulary
    {
        public DataVocabulary()
        {
            VocabularyName = "OData data"; // TODO: Set value
            KeyPrefix = "odata.data"; // TODO: Set value
            KeySeparator = ".";
            Grouping = EntityType.Infrastructure.User; // TODO: Set value

            AddGroup("OData Data Details", group =>
            {
                AccountId = group.Add(new VocabularyKey("AccountId", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                AccountName = group.Add(new VocabularyKey("AccountName", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Address1AddressId = group.Add(new VocabularyKey("Address1AddressId", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Address1City = group.Add(new VocabularyKey("Address1City", VocabularyKeyDataType.GeographyCity, VocabularyKeyVisibility.Visible));
                Address1Composite = group.Add(new VocabularyKey("Address1Composite", VocabularyKeyDataType.GeographyLocation, VocabularyKeyVisibility.Visible));
                Address1Country = group.Add(new VocabularyKey("Address1Country", VocabularyKeyDataType.GeographyCountry, VocabularyKeyVisibility.Visible));
                CreatedByName = group.Add(new VocabularyKey("CreatedByName", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                FirstName = group.Add(new VocabularyKey("FirstName", VocabularyKeyDataType.PersonName, VocabularyKeyVisibility.Visible));
            });
            AddMapping(Address1City, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.HomeAddressCity);
            AddMapping(Address1Composite, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.HomeAddress);
            AddMapping(Address1Country, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.HomeAddressCountryName);
            AddMapping(FirstName, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.FirstName);

        }
        public VocabularyKey AccountId { get; internal set; }
        public VocabularyKey AccountName { get; internal set; }
        public VocabularyKey Address1AddressId { get; internal set; }
        public VocabularyKey Address1City { get; internal set; }
        public VocabularyKey Address1Composite { get; internal set; }
        public VocabularyKey Address1Country { get; internal set; }
        public VocabularyKey CreatedByName { get; internal set; }
        public VocabularyKey FirstName { get; internal set; }

    }
}
