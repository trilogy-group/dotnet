using System.IO;
using Structurizr.Documentation;
using Xunit;

namespace Structurizr.Core.Tests.Documentation
{
    public class ViewpointsAndPerspectivesDocumentationTests
    {

        private SoftwareSystem softwareSystem;
        private ViewpointsAndPerspectivesDocumentation documentation;

        public ViewpointsAndPerspectivesDocumentationTests()
        {
            Workspace workspace = new Workspace("Name", "Description");
            softwareSystem = workspace.Model.AddSoftwareSystem("Name", "Description");
    
            documentation = new ViewpointsAndPerspectivesDocumentation(workspace);
        }

        [Fact]
        public void Test_Construction()
        {
            Assert.True(documentation.Sections.Count == 0);
            Assert.True(documentation.Images.Count == 0);
            Assert.True(documentation.IsEmpty());
        }

        [Fact]
        public void Test_AddAllSectionsWithContentAsStrings()
        {
            Section section;
    
            section = documentation.AddIntroductionSection(softwareSystem, Format.Markdown, "Section 1");
            AssertSection(softwareSystem, "Introduction", Format.Markdown, "Section 1", 1, section, documentation);
    
            section = documentation.AddGlossarySection(softwareSystem, Format.Markdown, "Section 2");
            AssertSection(softwareSystem, "Glossary", Format.Markdown, "Section 2", 2, section, documentation);
    
            section = documentation.AddSystemStakeholdersAndRequirementsSection(softwareSystem, Format.Markdown, "Section 3");
            AssertSection(softwareSystem, "System Stakeholders and Requirements", Format.Markdown, "Section 3", 3, section, documentation);
    
            section = documentation.AddArchitecturalForcesSection(softwareSystem, Format.Markdown, "Section 4");
            AssertSection(softwareSystem, "Architectural Forces", Format.Markdown, "Section 4", 4, section, documentation);
    
            section = documentation.AddArchitecturalViewsSection(softwareSystem, Format.Markdown, "Section 5");
            AssertSection(softwareSystem, "Architectural Views", Format.Markdown, "Section 5", 5, section, documentation);
    
            section = documentation.AddSystemQualitiesSection(softwareSystem, Format.Markdown, "Section 6");
            AssertSection(softwareSystem, "System Qualities", Format.Markdown, "Section 6", 6, section, documentation);
    
            section = documentation.AddAppendicesSection(softwareSystem, Format.Markdown, "Section 7");
            AssertSection(softwareSystem, "Appendices", Format.Markdown, "Section 7", 7, section, documentation);
        }
    
        [Fact]
        public void Test_AddAllSectionsWithContentFromFiles()
        {
            Section section;
            DirectoryInfo root = new DirectoryInfo("Documentation" + Path.DirectorySeparatorChar + "viewpointsandperspectives");
    
            section = documentation.AddIntroductionSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "01-introduction.md")));
            AssertSection(softwareSystem, "Introduction", Format.Markdown, "Section 1", 1, section, documentation);
    
            section = documentation.AddGlossarySection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "02-glossary.md")));
            AssertSection(softwareSystem, "Glossary", Format.Markdown, "Section 2", 2, section, documentation);
    
            section = documentation.AddSystemStakeholdersAndRequirementsSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "03-system-stakeholders-and-requirements.md")));
            AssertSection(softwareSystem, "System Stakeholders and Requirements", Format.Markdown, "Section 3", 3, section, documentation);
    
            section = documentation.AddArchitecturalForcesSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "04-architectural-forces.md")));
            AssertSection(softwareSystem, "Architectural Forces", Format.Markdown, "Section 4", 4, section, documentation);
    
            section = documentation.AddArchitecturalViewsSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "05-architectural-views.md")));
            AssertSection(softwareSystem, "Architectural Views", Format.Markdown, "Section 5", 5, section, documentation);
    
            section = documentation.AddSystemQualitiesSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "06-system-qualities.md")));
            AssertSection(softwareSystem, "System Qualities", Format.Markdown, "Section 6", 6, section, documentation);
    
            section = documentation.AddAppendicesSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "07-appendices.md")));
            AssertSection(softwareSystem, "Appendices", Format.Markdown, "Section 7", 7, section, documentation);
        }
    
        private void AssertSection(Element element, string type, Format format, string content, int order, Section section, ViewpointsAndPerspectivesDocumentation documentation)
        {
            Assert.True(documentation.Sections.Contains(section));
            Assert.Equal(element, section.Element);
            Assert.Equal(element.Id, section.ElementId);
            Assert.Equal(type, section.SectionType);
            Assert.Equal(format, section.Format);
            Assert.Equal(content, section.Content);
            Assert.Equal(order, section.Order);
        }
       
    }
}