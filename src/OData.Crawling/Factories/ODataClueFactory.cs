using System;
using CluedIn.Core;
using CluedIn.Core.Data;
using CluedIn.Crawling.Factories;
using CluedIn.Crawling.OData.Core;
using RuleConstants = CluedIn.Core.Constants.Validation.Rules;

namespace CluedIn.Crawling.OData.Factories
{
    public class ODataClueFactory : ClueFactory
    {
        public ODataClueFactory()
            : base(ODataConstants.CodeOrigin, ODataConstants.ProviderRootCodeValue)
        {
        }

        protected override Clue ConfigureProviderRoot([NotNull] Clue clue)
        {
            if (clue == null)
            {
                throw new ArgumentNullException(nameof(clue));
            }

            var data = clue.Data.EntityData;
            data.Name = ODataConstants.CrawlerName;
            data.Uri = new Uri(ODataConstants.Uri);
            data.Description = ODataConstants.CrawlerDescription;

            clue.ValidationRuleSuppressions.AddRange(new[] {RuleConstants.PROPERTIES_001_MustExist,});

            clue.ValidationRuleSuppressions.AddRange(new[]
            {
                RuleConstants.METADATA_002_Uri_MustBeSet, RuleConstants.PROPERTIES_002_Unknown_VocabularyKey_Used
            });

            return clue;
        }
    }
}
