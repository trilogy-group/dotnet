using System.IO;
using Structurizr.Documentation;
using Xunit;

namespace Structurizr.Core.Tests.Documentation
{

    public class Arc42DocumentationTests
    {
    
        private SoftwareSystem softwareSystem;
        private Arc42Documentation documentation;

        public Arc42DocumentationTests()
        {
            Workspace workspace = new Workspace("Name", "Description");
            softwareSystem = workspace.Model.AddSoftwareSystem("Name", "Description");
    
            documentation = new Arc42Documentation(workspace);
        }

        [Fact]
        public void Test_Construction()
        {
            Assert.True(documentation.Sections.Count == 0);
            Assert.True(documentation.Images.Count == 0);
            Assert.True(documentation.IsEmpty());
        }

        [Fact]
        public void test_addAllSectionsWithContentAsStrings()
        {
            Section section;
    
            section = documentation.AddIntroductionAndGoalsSection(softwareSystem, Format.Markdown, "Section 1");
            AssertSection(softwareSystem, "Introduction and Goals", Format.Markdown, "Section 1", 1, section, documentation);
    
            section = documentation.AddConstraintsSection(softwareSystem, Format.Markdown, "Section 2");
            AssertSection(softwareSystem, "Constraints", Format.Markdown, "Section 2", 2, section, documentation);
    
            section = documentation.AddContextAndScopeSection(softwareSystem, Format.Markdown, "Section 3");
            AssertSection(softwareSystem, "Context and Scope", Format.Markdown, "Section 3", 3, section, documentation);
    
            section = documentation.AddSolutionStrategySection(softwareSystem, Format.Markdown, "Section 4");
            AssertSection(softwareSystem, "Solution Strategy", Format.Markdown, "Section 4", 4, section, documentation);
    
            section = documentation.AddBuildingBlockViewSection(softwareSystem, Format.Markdown, "Section 5");
            AssertSection(softwareSystem, "Building Block View", Format.Markdown, "Section 5", 5, section, documentation);
    
            section = documentation.AddRuntimeViewSection(softwareSystem, Format.Markdown, "Section 6");
            AssertSection(softwareSystem, "Runtime View", Format.Markdown, "Section 6", 6, section, documentation);
    
            section = documentation.AddDeploymentViewSection(softwareSystem, Format.Markdown, "Section 7");
            AssertSection(softwareSystem, "Deployment View", Format.Markdown, "Section 7", 7, section, documentation);
    
            section = documentation.AddCrosscuttingConceptsSection(softwareSystem, Format.Markdown, "Section 8");
            AssertSection(softwareSystem, "Crosscutting Concepts", Format.Markdown, "Section 8", 8, section, documentation);
    
            section = documentation.AddArchitecturalDecisionsSection(softwareSystem, Format.Markdown, "Section 9");
            AssertSection(softwareSystem, "Architectural Decisions", Format.Markdown, "Section 9", 9, section, documentation);
    
            section = documentation.AddQualityRequirementsSection(softwareSystem, Format.Markdown, "Section 10");
            AssertSection(softwareSystem, "Quality Requirements", Format.Markdown, "Section 10", 10, section, documentation);
    
            section = documentation.AddRisksAndTechnicalDebtSection(softwareSystem, Format.Markdown, "Section 11");
            AssertSection(softwareSystem, "Risks and Technical Debt", Format.Markdown, "Section 11", 11, section, documentation);
    
            section = documentation.AddGlossarySection(softwareSystem, Format.Markdown, "Section 12");
            AssertSection(softwareSystem, "Glossary", Format.Markdown, "Section 12", 12, section, documentation);
        }

        [Fact]
        public void test_addAllSectionsWithContentFromFiles()
        {
            Section section;
            DirectoryInfo root = new DirectoryInfo("Documentation" + Path.DirectorySeparatorChar + "arc42");
    
            section = documentation.AddIntroductionAndGoalsSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "introduction-and-goals.md")));
            AssertSection(softwareSystem, "Introduction and Goals", Format.Markdown, "Section 1", 1, section, documentation);
    
            section = documentation.AddConstraintsSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "constraints.md")));
            AssertSection(softwareSystem, "Constraints", Format.Markdown, "Section 2", 2, section, documentation);
    
            section = documentation.AddContextAndScopeSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "context-and-scope.md")));
            AssertSection(softwareSystem, "Context and Scope", Format.Markdown, "Section 3", 3, section, documentation);
    
            section = documentation.AddSolutionStrategySection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "solution-strategy.md")));
            AssertSection(softwareSystem, "Solution Strategy", Format.Markdown, "Section 4", 4, section, documentation);
    
            section = documentation.AddBuildingBlockViewSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "building-block-view.md")));
            AssertSection(softwareSystem, "Building Block View", Format.Markdown, "Section 5", 5, section, documentation);
    
            section = documentation.AddRuntimeViewSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "runtime-view.md")));
            AssertSection(softwareSystem, "Runtime View", Format.Markdown, "Section 6", 6, section, documentation);
    
            section = documentation.AddDeploymentViewSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "deployment-view.md")));
            AssertSection(softwareSystem, "Deployment View", Format.Markdown, "Section 7", 7, section, documentation);
    
            section = documentation.AddCrosscuttingConceptsSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "crosscutting-concepts.md")));
            AssertSection(softwareSystem, "Crosscutting Concepts", Format.Markdown, "Section 8", 8, section, documentation);
    
            section = documentation.AddArchitecturalDecisionsSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "architectural-decisions.md")));
            AssertSection(softwareSystem, "Architectural Decisions", Format.Markdown, "Section 9", 9, section, documentation);
    
            section = documentation.AddQualityRequirementsSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "quality-requirements.md")));
            AssertSection(softwareSystem, "Quality Requirements", Format.Markdown, "Section 10", 10, section, documentation);
    
            section = documentation.AddRisksAndTechnicalDebtSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "risks-and-technical-debt.md")));
            AssertSection(softwareSystem, "Risks and Technical Debt", Format.Markdown, "Section 11", 11, section, documentation);
    
            section = documentation.AddGlossarySection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "glossary.md")));
            AssertSection(softwareSystem, "Glossary", Format.Markdown, "Section 12", 12, section, documentation);
        }

        private void AssertSection(Element element, string type, Format format, string content, int order, Section section, Arc42Documentation documentation)
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