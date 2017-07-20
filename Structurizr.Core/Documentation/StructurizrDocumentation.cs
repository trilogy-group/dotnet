using Newtonsoft.Json;
using System.IO;

namespace Structurizr.Documentation
{
    
    /// <summary>
    /// A simple documentation template, based upon the "software guidebook" concept in Simon Brown's
    /// <a href="https://leanpub.com/visualising-software-architecture">Software Architecture for Developers</a>
    /// book, with the following sections:
    /// 
    ///  - Context (1)
    ///  - Functional Overview (2)
    ///  - Quality Attributes (2)
    ///  - Constraints (2)
    ///  - Principles (2)
    ///  - Software Architecture (3)
    ///  - Containers (3)
    ///  - Components (3)
    ///  - Code (3)
    ///  - Data (3)
    ///  - Infrastructure Architecture (4)
    ///  - Deployment (4)
    ///  - Development Environment (4)
    ///  - Operation and Support (4)
    ///  - Decision Log (5)
    /// 
    /// The number in parentheses () represents the grouping, which is simply used to colour code
    /// section navigation buttons when rendered.
    /// </summary>
    public class StructurizrDocumentation : Documentation
    {

        public override string Type => "structurizr";

        [JsonConstructor]
        internal StructurizrDocumentation()
        {
        }

        public StructurizrDocumentation(Workspace workspace) : base(workspace)
        {
        }

        /// <summary>
        /// Adds a "Context" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddContextSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddContextSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds a "Context" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddContextSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "Context", Group1, format, content);
        }
        
        /// <summary>
        /// Adds a "Functional Overview" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddFunctionalOverviewSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddFunctionalOverviewSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds a "Functional Overview" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddFunctionalOverviewSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "Functional Overview", Group2, format, content);
        }
        
        /// <summary>
        /// Adds a "Quality Attributes" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddQualityAttributesSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddQualityAttributesSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds a "Quality Attributes" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddQualityAttributesSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "Quality Attributes", Group2, format, content);
        }
        
        /// <summary>
        /// Adds a "Constraints" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddConstraintsSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddConstraintsSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds a "Constraints" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddConstraintsSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "Constraints", Group2, format, content);
        }
        
        /// <summary>
        /// Adds a "Principles" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddPrinciplesSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddPrinciplesSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds a "Principles" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddPrinciplesSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "Principles", Group2, format, content);
        }
        
        /// <summary>
        /// Adds a "Software Architecture" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddSoftwareArchitectureSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddSoftwareArchitectureSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds a "Software Architecture" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddSoftwareArchitectureSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "Software Architecture", Group3, format, content);
        }
        
        /// <summary>
        /// Adds a "Containers" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddContainersSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddContainersSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds a "Containers" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddContainersSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "Containers", Group3, format, content);
        }
        
        /// <summary>
        /// Adds a "Components" section relating to a Container from a file.
        /// </summary>
        /// <param name="container">the Container the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddComponentsSection(Container container, Format format, params FileSystemInfo[] files)
        {
            return AddComponentsSection(container, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds a "Components" section relating to a Container.
        /// </summary>
        /// <param name="container">the Container the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddComponentsSection(Container container, Format format, string content)
        {
            return AddSection(container, "Components", Group3, format, content);
        }
        
        /// <summary>
        /// Adds a "Code" section relating to a Component from a file.
        /// </summary>
        /// <param name="component">the Component the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddCodeSection(Component component, Format format, params FileSystemInfo[] files)
        {
            return AddCodeSection(component, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds a "Code" section relating to a Component.
        /// </summary>
        /// <param name="component">the Component the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddCodeSection(Component component, Format format, string content)
        {
            return AddSection(component, "Code", Group3, format, content);
        }
        
        /// <summary>
        /// Adds a "Data" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddDataSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddDataSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds a "Data" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddDataSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "Data", Group3, format, content);
        }
        
        /// <summary>
        /// Adds an "Infrastructure Architecture" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddInfrastructureArchitectureSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddInfrastructureArchitectureSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds an "Infrastructure Architecture" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddInfrastructureArchitectureSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "Infrastructure Architecture", Group4, format, content);
        }

        /// <summary>
        /// Adds a "Deployment" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddDeploymentSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddDeploymentSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds a "Deployment" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddDeploymentSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "Deployment", Group4, format, content);
        }

        /// <summary>
        /// Adds a "Development Environment" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddDevelopmentEnvironmentSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddDevelopmentEnvironmentSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds a "Development Environment" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddDevelopmentEnvironmentSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "Development Environment", Group4, format, content);
        }

        /// <summary>
        /// Adds an "Operation and Support" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddOperationAndSupportSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddOperationAndSupportSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds an "Operation and Support" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddOperationAndSupportSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "Operation and Support", Group4, format, content);
        }

        /// <summary>
        /// Adds a "Decision Log" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddDecisionLogSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddDecisionLogSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds a "Decision Log" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddDecisionLogSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "Decision Log", Group5, format, content);
        }

    }
    
}