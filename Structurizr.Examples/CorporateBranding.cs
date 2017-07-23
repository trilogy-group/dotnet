using System.IO;
using Structurizr.Api;
using Structurizr.Documentation;
using Structurizr.Util;

namespace Structurizr.Examples
{
    
    /// <summary>
    /// This is a simple example that illustrates the corporate branding features of Structurizr, including:
    ///  - A colour scheme, which is applied to model elements and documentation navigation.
    ///  - A logo, which is included in diagrams and documentation.
    ///
    /// You can see the live workspace at https://structurizr.com/share/35031
    /// </summary>
    public class CorporateBranding
    {
     
        private const long WorkspaceId = 35031;
        private const string ApiKey = "key";
        private const string ApiSecret = "secret";

        static void Main()
        {
            Workspace workspace = new Workspace("Corporate Branding", "This is a model of my software system.");
            Model model = workspace.Model;
    
            Person user = model.AddPerson("User", "A user of my software system.");
            SoftwareSystem softwareSystem = model.AddSoftwareSystem("Software System", "My software system.");
            user.Uses(softwareSystem, "Uses");
    
            ViewSet views = workspace.Views;
            SystemContextView contextView = views.CreateSystemContextView(softwareSystem, "SystemContext", "An example of a System Context diagram.");
            contextView.AddAllSoftwareSystems();
            contextView.AddAllPeople();
    
            Styles styles = views.Configuration.Styles;
            styles.Add(new ElementStyle(Tags.Person) { Shape = Shape.Person });
    
            StructurizrDocumentationTemplate template = new StructurizrDocumentationTemplate(workspace);
            template.AddContextSection(softwareSystem, Format.Markdown, "Here is some context about the software system...\n\n![](embed:SystemContext)");
            template.AddQualityAttributesSection(softwareSystem, Format.Markdown, "Here is some information about the quality attributes...");
            template.AddSoftwareArchitectureSection(softwareSystem, Format.Markdown, "Here is some information about the software architecture...");
            template.AddOperationAndSupportSection(softwareSystem, Format.Markdown, "Here is some information about how to operate and support the software...");
            template.AddDecisionLogSection(softwareSystem, Format.Markdown, "Here is some information about the decisions made...");
    
            Branding branding = views.Configuration.Branding;
            branding.Color1 = new ColorPair("#02172c", "#ffffff");
            branding.Color2 = new ColorPair("#08427b", "#ffffff");
            branding.Color3 = new ColorPair("#1168bd", "#ffffff");
            branding.Color4 = new ColorPair("#438dd5", "#ffffff");
            branding.Color5 = new ColorPair("#85bbf0", "#ffffff");
            branding.Logo = ImageUtils.GetImageAsDataUri(new FileInfo("structurizr-logo.png"));
    
            StructurizrClient structurizrClient = new StructurizrClient(ApiKey, ApiSecret);
            structurizrClient.PutWorkspace(WorkspaceId, workspace);
        }

    }
    
}