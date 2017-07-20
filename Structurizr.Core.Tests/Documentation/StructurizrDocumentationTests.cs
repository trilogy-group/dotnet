using System.IO;
using Xunit;

namespace Structurizr.Core.Tests
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
        public void test_construction() {
            Assert.True(documentation.Sections.Count == 0);
            Assert.True(documentation.Images.Count == 0);
            Assert.True(documentation.IsEmpty());
        }
    
        [Fact]
        public void test_addAllSectionsWithContentAsstrings() {
            Section section;
    
            section = documentation.AddContextSection(softwareSystem, DocumentationFormat.Markdown, "Context section");
            AssertSection(softwareSystem, "Context", 1, DocumentationFormat.Markdown, "Context section", 1, section, documentation);
    
            section = documentation.AddFunctionalOverviewSection(softwareSystem, DocumentationFormat.Markdown, "Functional overview section");
            AssertSection(softwareSystem, "Functional Overview", 2, DocumentationFormat.Markdown, "Functional overview section", 2, section, documentation);
    
            section = documentation.AddQualityAttributesSection(softwareSystem, DocumentationFormat.Markdown, "Quality attributes section");
            AssertSection(softwareSystem, "Quality Attributes", 2, DocumentationFormat.Markdown, "Quality attributes section", 3, section, documentation);
    
            section = documentation.AddConstraintsSection(softwareSystem, DocumentationFormat.Markdown, "Constraints section");
            AssertSection(softwareSystem, "Constraints", 2, DocumentationFormat.Markdown, "Constraints section", 4, section, documentation);
    
            section = documentation.AddPrinciplesSection(softwareSystem, DocumentationFormat.Markdown, "Principles section");
            AssertSection(softwareSystem, "Principles", 2, DocumentationFormat.Markdown, "Principles section", 5, section, documentation);
    
            section = documentation.AddSoftwareArchitectureSection(softwareSystem, DocumentationFormat.Markdown, "Software architecture section");
            AssertSection(softwareSystem, "Software Architecture", 3, DocumentationFormat.Markdown, "Software architecture section", 6, section, documentation);
    
            section = documentation.AddContainersSection(softwareSystem, DocumentationFormat.Markdown, "Containers section");
            AssertSection(softwareSystem, "Containers", 3, DocumentationFormat.Markdown, "Containers section", 7, section, documentation);
    
            section = documentation.AddComponentsSection(containerA, DocumentationFormat.Markdown, "Components section for container A");
            AssertSection(containerA, "Components", 3, DocumentationFormat.Markdown, "Components section for container A", 8, section, documentation);
    
            section = documentation.AddComponentsSection(containerB, DocumentationFormat.Markdown, "Components section for container B");
            AssertSection(containerB, "Components", 3, DocumentationFormat.Markdown, "Components section for container B", 9, section, documentation);
    
            section = documentation.AddCodeSection(componentA1, DocumentationFormat.Markdown, "Code section for component A1");
            AssertSection(componentA1, "Code", 3, DocumentationFormat.Markdown, "Code section for component A1", 10, section, documentation);
    
            section = documentation.AddCodeSection(componentA2, DocumentationFormat.Markdown, "Code section for component A2");
            AssertSection(componentA2, "Code", 3, DocumentationFormat.Markdown, "Code section for component A2", 11, section, documentation);
    
            section = documentation.AddDataSection(softwareSystem, DocumentationFormat.Markdown, "Data section");
            AssertSection(softwareSystem, "Data", 3, DocumentationFormat.Markdown, "Data section", 12, section, documentation);
    
            section = documentation.AddInfrastructureArchitectureSection(softwareSystem, DocumentationFormat.Markdown, "Infrastructure architecture section");
            AssertSection(softwareSystem, "Infrastructure Architecture", 4, DocumentationFormat.Markdown, "Infrastructure architecture section", 13, section, documentation);
    
            section = documentation.AddDeploymentSection(softwareSystem, DocumentationFormat.Markdown, "Deployment section");
            AssertSection(softwareSystem, "Deployment", 4, DocumentationFormat.Markdown, "Deployment section", 14, section, documentation);
    
            section = documentation.AddDevelopmentEnvironmentSection(softwareSystem, DocumentationFormat.Markdown, "Development environment section");
            AssertSection(softwareSystem, "Development Environment", 4, DocumentationFormat.Markdown, "Development environment section", 15, section, documentation);
    
            section = documentation.AddOperationAndSupportSection(softwareSystem, DocumentationFormat.Markdown, "Operation and support section");
            AssertSection(softwareSystem, "Operation and Support", 4, DocumentationFormat.Markdown, "Operation and support section", 16, section, documentation);
    
            section = documentation.AddDecisionLogSection(softwareSystem, DocumentationFormat.Markdown, "Decision log section");
            AssertSection(softwareSystem, "Decision Log", 5, DocumentationFormat.Markdown, "Decision log section", 17, section, documentation);
        }
    
        [Fact]
        public void test_addAllSectionsWithContentFromFiles() {
            Section section;
            DirectoryInfo root = new DirectoryInfo("Documentation" + Path.DirectorySeparatorChar + "structurizr");
    
            section = documentation.AddContextSection(softwareSystem, DocumentationFormat.Markdown, new FileInfo(Path.Combine(root.FullName, "context.md")));
            AssertSection(softwareSystem, "Context", 1, DocumentationFormat.Markdown, "Context section", 1, section, documentation);
    
            section = documentation.AddFunctionalOverviewSection(softwareSystem, DocumentationFormat.Markdown, new FileInfo(Path.Combine(root.FullName, "functional-overview.md")));
            AssertSection(softwareSystem, "Functional Overview", 2, DocumentationFormat.Markdown, "Functional overview section", 2, section, documentation);
    
            section = documentation.AddQualityAttributesSection(softwareSystem, DocumentationFormat.Markdown, new FileInfo(Path.Combine(root.FullName, "quality-attributes.md")));
            AssertSection(softwareSystem, "Quality Attributes", 2, DocumentationFormat.Markdown, "Quality attributes section", 3, section, documentation);
    
            section = documentation.AddConstraintsSection(softwareSystem, DocumentationFormat.Markdown, new FileInfo(Path.Combine(root.FullName, "constraints.md")));
            AssertSection(softwareSystem, "Constraints", 2, DocumentationFormat.Markdown, "Constraints section", 4, section, documentation);
    
            section = documentation.AddPrinciplesSection(softwareSystem, DocumentationFormat.Markdown, new FileInfo(Path.Combine(root.FullName, "principles.md")));
            AssertSection(softwareSystem, "Principles", 2, DocumentationFormat.Markdown, "Principles section", 5, section, documentation);
    
            section = documentation.AddSoftwareArchitectureSection(softwareSystem, DocumentationFormat.Markdown, new FileInfo(Path.Combine(root.FullName, "software-architecture.md")));
            AssertSection(softwareSystem, "Software Architecture", 3, DocumentationFormat.Markdown, "Software architecture section", 6, section, documentation);
    
            section = documentation.AddContainersSection(softwareSystem, DocumentationFormat.Markdown, new FileInfo(Path.Combine(root.FullName, "containers.md")));
            AssertSection(softwareSystem, "Containers", 3, DocumentationFormat.Markdown, "Containers section", 7, section, documentation);
    
            section = documentation.AddComponentsSection(containerA, DocumentationFormat.Markdown, new FileInfo(Path.Combine(root.FullName, "components-for-containerA.md")));
            AssertSection(containerA, "Components", 3, DocumentationFormat.Markdown, "Components section for container A", 8, section, documentation);
    
            section = documentation.AddComponentsSection(containerB, DocumentationFormat.Markdown, new FileInfo(Path.Combine(root.FullName, "components-for-containerB.md")));
            AssertSection(containerB, "Components", 3, DocumentationFormat.Markdown, "Components section for container B", 9, section, documentation);
    
            section = documentation.AddCodeSection(componentA1, DocumentationFormat.Markdown, new FileInfo(Path.Combine(root.FullName, "code-for-componentA1.md")));
            AssertSection(componentA1, "Code", 3, DocumentationFormat.Markdown, "Code section for component A1", 10, section, documentation);
    
            section = documentation.AddCodeSection(componentA2, DocumentationFormat.Markdown, new FileInfo(Path.Combine(root.FullName, "code-for-componentA2.md")));
            AssertSection(componentA2, "Code", 3, DocumentationFormat.Markdown, "Code section for component A2", 11, section, documentation);
    
            section = documentation.AddDataSection(softwareSystem, DocumentationFormat.Markdown, new FileInfo(Path.Combine(root.FullName, "data.md")));
            AssertSection(softwareSystem, "Data", 3, DocumentationFormat.Markdown, "Data section", 12, section, documentation);
    
            section = documentation.AddInfrastructureArchitectureSection(softwareSystem, DocumentationFormat.Markdown, new FileInfo(Path.Combine(root.FullName, "infrastructure-architecture.md")));
            AssertSection(softwareSystem, "Infrastructure Architecture", 4, DocumentationFormat.Markdown, "Infrastructure architecture section", 13, section, documentation);
    
            section = documentation.AddDeploymentSection(softwareSystem, DocumentationFormat.Markdown, new FileInfo(Path.Combine(root.FullName, "deployment.md")));
            AssertSection(softwareSystem, "Deployment", 4, DocumentationFormat.Markdown, "Deployment section", 14, section, documentation);
    
            section = documentation.AddDevelopmentEnvironmentSection(softwareSystem, DocumentationFormat.Markdown, new FileInfo(Path.Combine(root.FullName, "development-environment.md")));
            AssertSection(softwareSystem, "Development Environment", 4, DocumentationFormat.Markdown, "Development environment section", 15, section, documentation);
    
            section = documentation.AddOperationAndSupportSection(softwareSystem, DocumentationFormat.Markdown, new FileInfo(Path.Combine(root.FullName, "operation-and-support.md")));
            AssertSection(softwareSystem, "Operation and Support", 4, DocumentationFormat.Markdown, "Operation and support section", 16, section, documentation);
    
            section = documentation.AddDecisionLogSection(softwareSystem, DocumentationFormat.Markdown, new FileInfo(Path.Combine(root.FullName, "decision-log.md")));
            AssertSection(softwareSystem, "Decision Log", 5, DocumentationFormat.Markdown, "Decision log section", 17, section, documentation);
        }
    
        [Fact]
        public void test_addCustomSectionWithContentAsAstring() {
            Section section = documentation.AddCustomSection(softwareSystem, "Custom Section", 3, DocumentationFormat.Markdown, "Custom content");
            AssertSection(softwareSystem, "Custom Section", 3, DocumentationFormat.Markdown, "Custom content", 1, section, documentation);
        }
    
        [Fact]
        public void test_addCustomSectionFromAFile() {
            DirectoryInfo root = new DirectoryInfo("Documentation" + Path.DirectorySeparatorChar + "structurizr");
    
            Section section = documentation.AddCustomSection(softwareSystem, "Custom Section", 3, DocumentationFormat.Markdown, new FileInfo(Path.Combine(root.FullName, "context.md")));
            AssertSection(softwareSystem, "Custom Section", 3, DocumentationFormat.Markdown, "Context section", 1, section, documentation);
        }
    
        private void AssertSection(Element element, string type, int group, DocumentationFormat format, string content, int order, Section section, Documentation documentation) {
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