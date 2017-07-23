using System.IO;

namespace Structurizr.Documentation
{
    
    /// <summary>
    ///
    /// An implementation of the "Viewpoints and Perspectives" documentation template
    /// (http://www.viewpoints-and-perspectives.info),
    /// from the "Software Systems Architecture" book by Nick Rozanski and Eoin Woods,
    /// consisting of the following sections:
    ///
    ///  - Introduction (1)
    ///  - Glossary (1)
    ///  - System Stakeholders and Requirements (2)
    ///  - Architectural Forces (2)
    ///  - Architectural Views (3)
    ///  - System Qualities (4)
    ///  - Appendices (5)
    ///
    /// The number in parentheses () represents the grouping, which is simply used to colour code
    /// section navigation buttons when rendered.
    /// </summary>
    public class ViewpointsAndPerspectivesDocumentation : DocumentationTemplate
    {
        
        public ViewpointsAndPerspectivesDocumentation(Workspace workspace) : base(workspace)
        {
        }
        
        /// <summary>
        /// Adds an "Introduction" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddIntroductionSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddIntroductionSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds an "Introduction" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddIntroductionSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "Introduction", Group1, format, content);
        }
        
        /// <summary>
        /// Adds a "Glossary" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddGlossarySection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddGlossarySection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds a "Glossary" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddGlossarySection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "Glossary", Group1, format, content);
        }
        
        /// <summary>
        /// Adds a "System Stakeholders and Requirements" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddSystemStakeholdersAndRequirementsSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddSystemStakeholdersAndRequirementsSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds a "System Stakeholders and Requirements" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddSystemStakeholdersAndRequirementsSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "System Stakeholders and Requirements", Group2, format, content);
        }
        
        /// <summary>
        /// Adds an "Architectural Forces" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddArchitecturalForcesSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddArchitecturalForcesSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds an "Architectural Forces" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddArchitecturalForcesSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "Architectural Forces", Group2, format, content);
        }
        
        /// <summary>
        /// Adds an "Architectural Views" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddArchitecturalViewsSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddArchitecturalViewsSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds an "Architectural Views" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddArchitecturalViewsSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "Architectural Views", Group3, format, content);
        }
        
        /// <summary>
        /// Adds a "System Qualities" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddSystemQualitiesSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddSystemQualitiesSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds a "System Qualities" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddSystemQualitiesSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "System Qualities", Group4, format, content);
        }
        
        /// <summary>
        /// Adds a "Appendices" section relating to a SoftwareSystem from a file.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileSystemInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddAppendicesSection(SoftwareSystem softwareSystem, Format format, params FileSystemInfo[] files)
        {
            return AddAppendicesSection(softwareSystem, format, ReadFiles(files));
        }

        /// <summary>
        /// Adds a "Appendices" section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation relates to</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddAppendicesSection(SoftwareSystem softwareSystem, Format format, string content)
        {
            return AddSection(softwareSystem, "Appendices", Group5, format, content);
        }
        
    }
}