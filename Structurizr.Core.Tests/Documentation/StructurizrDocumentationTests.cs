using System.IO;
using Structurizr.Documentation;
using Xunit;

namespace Structurizr.Core.Tests.Documentation
{
    public class StructurizrDocumentationTests
    {
        
        private SoftwareSystem softwareSystem;
        private Container containerA;
        private Container containerB;
        private Component componentA1;
        private Component componentA2;
        private StructurizrDocumentation documentation;

        public StructurizrDocumentationTests()
        {
            Workspace workspace = new Workspace("Name", "Description");
            softwareSystem = workspace.Model.AddSoftwareSystem("Name", "Description");
            containerA = softwareSystem.AddContainer("Container A", "Description", "Technology");
            containerB = softwareSystem.AddContainer("Container B", "Description", "Technology");
            componentA1 = containerA.AddComponent("Component A1", "Description", "Technology");
            componentA2 = containerA.AddComponent("Component A2", "Description", "Technology");
    
            documentation = new StructurizrDocumentation(workspace);
        }
    
        [Fact]
        public void Test_Construction()
        {
            Assert.True(documentation.Sections.Count == 0);
            Assert.True(documentation.Images.Count == 0);
            Assert.True(documentation.IsEmpty());
        }
    
        [Fact]
        public void Test_AddAllSectionsWithContentAsstrings()
        {
            Section section;
    
            section = documentation.AddContextSection(softwareSystem, Format.Markdown, "Context section");
            AssertSection(softwareSystem, "Context", 1, Format.Markdown, "Context section", 1, section, documentation);
    
            section = documentation.AddFunctionalOverviewSection(softwareSystem, Format.Markdown, "Functional overview section");
            AssertSection(softwareSystem, "Functional Overview", 2, Format.Markdown, "Functional overview section", 2, section, documentation);
    
            section = documentation.AddQualityAttributesSection(softwareSystem, Format.Markdown, "Quality attributes section");
            AssertSection(softwareSystem, "Quality Attributes", 2, Format.Markdown, "Quality attributes section", 3, section, documentation);
    
            section = documentation.AddConstraintsSection(softwareSystem, Format.Markdown, "Constraints section");
            AssertSection(softwareSystem, "Constraints", 2, Format.Markdown, "Constraints section", 4, section, documentation);
    
            section = documentation.AddPrinciplesSection(softwareSystem, Format.Markdown, "Principles section");
            AssertSection(softwareSystem, "Principles", 2, Format.Markdown, "Principles section", 5, section, documentation);
    
            section = documentation.AddSoftwareArchitectureSection(softwareSystem, Format.Markdown, "Software architecture section");
            AssertSection(softwareSystem, "Software Architecture", 3, Format.Markdown, "Software architecture section", 6, section, documentation);
    
            section = documentation.AddContainersSection(softwareSystem, Format.Markdown, "Containers section");
            AssertSection(softwareSystem, "Containers", 3, Format.Markdown, "Containers section", 7, section, documentation);
    
            section = documentation.AddComponentsSection(containerA, Format.Markdown, "Components section for container A");
            AssertSection(containerA, "Components", 3, Format.Markdown, "Components section for container A", 8, section, documentation);
    
            section = documentation.AddComponentsSection(containerB, Format.Markdown, "Components section for container B");
            AssertSection(containerB, "Components", 3, Format.Markdown, "Components section for container B", 9, section, documentation);
    
            section = documentation.AddCodeSection(componentA1, Format.Markdown, "Code section for component A1");
            AssertSection(componentA1, "Code", 3, Format.Markdown, "Code section for component A1", 10, section, documentation);
    
            section = documentation.AddCodeSection(componentA2, Format.Markdown, "Code section for component A2");
            AssertSection(componentA2, "Code", 3, Format.Markdown, "Code section for component A2", 11, section, documentation);
    
            section = documentation.AddDataSection(softwareSystem, Format.Markdown, "Data section");
            AssertSection(softwareSystem, "Data", 3, Format.Markdown, "Data section", 12, section, documentation);
    
            section = documentation.AddInfrastructureArchitectureSection(softwareSystem, Format.Markdown, "Infrastructure architecture section");
            AssertSection(softwareSystem, "Infrastructure Architecture", 4, Format.Markdown, "Infrastructure architecture section", 13, section, documentation);
    
            section = documentation.AddDeploymentSection(softwareSystem, Format.Markdown, "Deployment section");
            AssertSection(softwareSystem, "Deployment", 4, Format.Markdown, "Deployment section", 14, section, documentation);
    
            section = documentation.AddDevelopmentEnvironmentSection(softwareSystem, Format.Markdown, "Development environment section");
            AssertSection(softwareSystem, "Development Environment", 4, Format.Markdown, "Development environment section", 15, section, documentation);
    
            section = documentation.AddOperationAndSupportSection(softwareSystem, Format.Markdown, "Operation and support section");
            AssertSection(softwareSystem, "Operation and Support", 4, Format.Markdown, "Operation and support section", 16, section, documentation);
    
            section = documentation.AddDecisionLogSection(softwareSystem, Format.Markdown, "Decision log section");
            AssertSection(softwareSystem, "Decision Log", 5, Format.Markdown, "Decision log section", 17, section, documentation);
        }
    
        [Fact]
        public void Test_AddAllSectionsWithContentFromFiles()
        {
            Section section;
            DirectoryInfo root = new DirectoryInfo("Documentation" + Path.DirectorySeparatorChar + "structurizr");
    
            section = documentation.AddContextSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "context.md")));
            AssertSection(softwareSystem, "Context", 1, Format.Markdown, "Context section", 1, section, documentation);
    
            section = documentation.AddFunctionalOverviewSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "functional-overview.md")));
            AssertSection(softwareSystem, "Functional Overview", 2, Format.Markdown, "Functional overview section", 2, section, documentation);
    
            section = documentation.AddQualityAttributesSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "quality-attributes.md")));
            AssertSection(softwareSystem, "Quality Attributes", 2, Format.Markdown, "Quality attributes section", 3, section, documentation);
    
            section = documentation.AddConstraintsSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "constraints.md")));
            AssertSection(softwareSystem, "Constraints", 2, Format.Markdown, "Constraints section", 4, section, documentation);
    
            section = documentation.AddPrinciplesSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "principles.md")));
            AssertSection(softwareSystem, "Principles", 2, Format.Markdown, "Principles section", 5, section, documentation);
    
            section = documentation.AddSoftwareArchitectureSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "software-architecture.md")));
            AssertSection(softwareSystem, "Software Architecture", 3, Format.Markdown, "Software architecture section", 6, section, documentation);
    
            section = documentation.AddContainersSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "containers.md")));
            AssertSection(softwareSystem, "Containers", 3, Format.Markdown, "Containers section", 7, section, documentation);
    
            section = documentation.AddComponentsSection(containerA, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "components-for-containerA.md")));
            AssertSection(containerA, "Components", 3, Format.Markdown, "Components section for container A", 8, section, documentation);
    
            section = documentation.AddComponentsSection(containerB, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "components-for-containerB.md")));
            AssertSection(containerB, "Components", 3, Format.Markdown, "Components section for container B", 9, section, documentation);
    
            section = documentation.AddCodeSection(componentA1, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "code-for-componentA1.md")));
            AssertSection(componentA1, "Code", 3, Format.Markdown, "Code section for component A1", 10, section, documentation);
    
            section = documentation.AddCodeSection(componentA2, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "code-for-componentA2.md")));
            AssertSection(componentA2, "Code", 3, Format.Markdown, "Code section for component A2", 11, section, documentation);
    
            section = documentation.AddDataSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "data.md")));
            AssertSection(softwareSystem, "Data", 3, Format.Markdown, "Data section", 12, section, documentation);
    
            section = documentation.AddInfrastructureArchitectureSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "infrastructure-architecture.md")));
            AssertSection(softwareSystem, "Infrastructure Architecture", 4, Format.Markdown, "Infrastructure architecture section", 13, section, documentation);
    
            section = documentation.AddDeploymentSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "deployment.md")));
            AssertSection(softwareSystem, "Deployment", 4, Format.Markdown, "Deployment section", 14, section, documentation);
    
            section = documentation.AddDevelopmentEnvironmentSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "development-environment.md")));
            AssertSection(softwareSystem, "Development Environment", 4, Format.Markdown, "Development environment section", 15, section, documentation);
    
            section = documentation.AddOperationAndSupportSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "operation-and-support.md")));
            AssertSection(softwareSystem, "Operation and Support", 4, Format.Markdown, "Operation and support section", 16, section, documentation);
    
            section = documentation.AddDecisionLogSection(softwareSystem, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "decision-log.md")));
            AssertSection(softwareSystem, "Decision Log", 5, Format.Markdown, "Decision log section", 17, section, documentation);
        }
    
        [Fact]
        public void Test_AddCustomSectionWithContentAsAstring()
        {
            Section section = documentation.AddCustomSection(softwareSystem, "Custom Section", 3, Format.Markdown, "Custom content");
            AssertSection(softwareSystem, "Custom Section", 3, Format.Markdown, "Custom content", 1, section, documentation);
        }
    
        [Fact]
        public void Test_AddCustomSectionFromAFile()
        {
            DirectoryInfo root = new DirectoryInfo("Documentation" + Path.DirectorySeparatorChar + "structurizr");
    
            Section section = documentation.AddCustomSection(softwareSystem, "Custom Section", 3, Format.Markdown, new FileInfo(Path.Combine(root.FullName, "context.md")));
            AssertSection(softwareSystem, "Custom Section", 3, Format.Markdown, "Context section", 1, section, documentation);
        }
    
        private void AssertSection(Element element, string type, int group, Format format, string content, int order, Section section, StructurizrDocumentation documentation)
        {
            Assert.True(documentation.Sections.Contains(section));
            Assert.Equal(element, section.Element);
            Assert.Equal(element.Id, section.ElementId);
            Assert.Equal(type, section.SectionType);
            Assert.Equal(group, section.Group);
            Assert.Equal(format, section.Format);
            Assert.Equal(content, section.Content);
            Assert.Equal(order, section.Order);
        }
        
    }
}