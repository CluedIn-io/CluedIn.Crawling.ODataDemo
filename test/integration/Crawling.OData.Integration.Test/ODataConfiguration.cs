using System.Collections.Generic;
using CluedIn.Crawling.OData.Core;

namespace CluedIn.Crawling.OData.Integration.Test
{
  public static class ODataConfiguration
  {
    public static Dictionary<string, object> Create()
    {
      return new Dictionary<string, object>
            {
                { ODataConstants.KeyName.ApiKey, "demo" }
            };
    }
  }
}
