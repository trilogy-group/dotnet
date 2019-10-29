using System;
using System.Collections.Generic;
using System.Text;

namespace Structurizr.Client.Tests.IO
{
    public static class TestData
    {
        public static string Model1
            => @"{
  ""model"": {
    ""people"": [
      {
        ""properties"": {},
        ""location"": ""Unspecified"",
        ""name"": ""Client Employee"",
        ""description"": ""Any Employee from client who can act as Analyst/Admin/Finance role"",
        ""relationships"": [
          {
            ""properties"": {},
            ""description"": ""Provides configuration to the Plugin"",
            ""sourceId"": ""3"",
            ""destinationId"": ""292"",
            ""technology"": ""GUI"",
            ""id"": ""369"",
            ""tags"": ""Relationship,Relationship,Relationship""
          }],
        ""id"": ""3"",
        ""tags"": ""Element,Person,Element,Person,Element,Person""
      }
	 ],
    ""softwareSystems"": [
      {
        ""properties"": {},
        ""containers"": [],
        ""name"": ""Magento Plugin"",
        ""description"": ""Plugin for Magento Commerce Software for generating Customer Store Data Feed"",
        ""relationships"": [],
        ""id"": ""292"",
        ""tags"": ""Element,Software System,Element,Software System,Element,Software System,SLIFRONT""
      }
	  ],
    ""deploymentNodes"": [],
    ""views"": {
    ""systemLandscapeViews"": [],
    ""systemContextViews"": [],
    ""containerViews"": [],
    ""componentViews"": [],
    ""filteredViews"": [],
    ""configuration"": {
      ""styles"": {
        ""relationships"": [],
        ""elements"": [
          {
            ""tag"": ""Person"",
            ""background"": ""#0080ff"",
            ""color"": ""#000000"",
            ""shape"": ""Person""
          },
          {
            ""tag"": ""Software System"",
            ""background"": ""#808080"",
            ""color"": ""#000000""
          },
          {
            ""tag"": ""SLIAO"",
            ""background"": ""#804000""
          },
          {
            ""tag"": ""SLIFRONT"",
            ""background"": ""#408080""
          },
          {
            ""tag"": ""SLISEARCH"",
            ""background"": ""#808000""
          },
          {
            ""tag"": ""3rdParty"",
            ""shape"": ""Cylinder""
          },
          {
            ""tag"": ""External Software"",
            ""shape"": ""Ellipse""
          },
          {
            ""tag"": ""SHARED_LIBRARY"",
            ""background"": ""#8080ff"",
            ""color"": ""#000040"",
            ""shape"": ""Folder""
          }
        ]
      },
      ""branding"": {},
      ""terminology"": {},
      ""lastSavedView"": ""SearchBuilder"",
      ""viewSortOrder"": ""Default""
    }
  },
  ""documentation"": {
    ""sections"": [],
    ""decisions"": [],
    ""images"": []
  },
  ""id"": 46872,
  ""name"": ""SLI Systems"",
  ""description"": ""SLI Systems workspace."",
  ""lastModifiedDate"": ""2019-10-22T09:09:47Z"",
  ""lastModifiedUser"": ""abhinav.kansal@trilogy.com"",
  ""lastModifiedAgent"": ""structurizr-web/1647"",
  ""revision"": 1581,
  ""configuration"": {
    ""users"": []
  }
}
}";
    }
}
