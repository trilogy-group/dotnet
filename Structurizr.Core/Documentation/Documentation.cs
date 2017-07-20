using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Structurizr.Util;
using Newtonsoft.Json;

namespace Structurizr
{

    /// <summary>
    /// Represents the documentation within a workspace - a collection of
    /// content in Markdown or AsciiDoc format, optionally with attached images.
    ///
    /// See https://structurizr.com/help/documentation on the Structurizr website for more details.
    /// </summary>
    [DataContract]
    public abstract class Documentation
    {

        protected const int Group1 = 1;
        protected const int Group2 = 2;
        protected const int Group3 = 3;
        protected const int Group4 = 4;
        protected const int Group5 = 5;
        
        public Model Model { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public abstract string Type { get; }

        [DataMember(Name = "sections", EmitDefaultValue = false)]
        public HashSet<Section> Sections { get; private set; }

        [DataMember(Name = "images", EmitDefaultValue = false)]
        public HashSet<Image> Images { get; private set; }

        [JsonConstructor]
        internal Documentation()
        {
            Sections = new HashSet<Section>();
            Images = new HashSet<Image>();
        }

        public Documentation(Workspace workspace) : this()
        {
            if (workspace == null)
            {
                throw new ArgumentException("A workspace must be specified.");
            }
            
            workspace.Documentation = this;
            Model = workspace.Model;
        }

        public void Hydrate()
        {
            foreach (Section section in Sections)
            {
                section.Element = Model.GetElement(section.ElementId);
            }

        }
        
        protected string ReadFiles(params FileSystemInfo[] files)
        {
            if (files == null || files.Length == 0)
            {
                throw new ArgumentException("One or more files must be specified.");
            }

            StringBuilder content = new StringBuilder();
            foreach (FileSystemInfo file in files)
            {
                if (file == null)
                {
                    throw new ArgumentException("One or more files must be specified.");
                }

                if (!File.Exists(file.FullName) && !Directory.Exists(file.FullName))
                {
                    throw new ArgumentException(file.FullName + " does not exist.");
                }

                if (content.Length > 0)
                {
                    content.Append(Environment.NewLine);
                }

                if (File.Exists(file.FullName))
                {
                    string contentInFile = File.ReadAllText(file.FullName, Encoding.UTF8);
                    content.Append(contentInFile);
                }
                else if (Directory.Exists(file.FullName))
                {
                    DirectoryInfo directory = new DirectoryInfo(file.FullName);
                    FileSystemInfo[] children = directory.GetFileSystemInfos();
                    Array.Sort(children, (f1, f2) => f1.Name.CompareTo(f2.Name));
                    content.Append(ReadFiles(children));
                }
            }

            return content.ToString();
        }

        /// <summary>
        /// Adds a custom section from a file, that isn't related to any element in the model.
        /// </summary>
        /// <param name="name">the name of the section</param>
        /// <param name="group">the group of the section (an integer between 1 and 5)</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddCustomSection(string name, int group, DocumentationFormat format, params FileInfo[] files)
        {
            return AddCustomSection(name, group, format, ReadFiles(files));
        }
    
        /// <summary>
        /// Adds a custom section, that isn't related to any element in the model.
        /// </summary>
        /// <param name="name">the name of the section</param>
        /// <param name="group">the group of the section (an integer between 1 and 5)</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation section</returns>
        public Section AddCustomSection(string name, int group, DocumentationFormat format, string content)
        {
            return AddSection(null, name, group, format, content);
        }
    
        /// <summary>
        /// Adds a custom section relating to a SoftwareSystem from one or more files.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation content relates to</param>
        /// <param name="name">the name of the section</param>
        /// <param name="group">the group of the section (an integer between 1 and 5)</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="files">one or more FileInfo objects that point to the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddCustomSection(SoftwareSystem softwareSystem, string name, int group, DocumentationFormat format, params FileInfo[] files)
        {
            return AddCustomSection(softwareSystem, name, group, format, ReadFiles(files));
        }
    
        /**
         * 
         *
         * @param softwareSystem    the {@link SoftwareSystem} the documentation content relates to
         * @param name              the name of the section
         * @param group             the group of the section (an integer between 1 and 5)
         * @param format    the {@link Format} of the documentation content
         * @param content   a String containing the documentation content
         * @return  a documentation {@link Section}
         */
        /// <summary>
        /// Adds a custom section relating to a SoftwareSystem.
        /// </summary>
        /// <param name="softwareSystem">the SoftwareSystem the documentation content relates to</param>
        /// <param name="name">the name of the section</param>
        /// <param name="group">the group of the section (an integer between 1 and 5)</param>
        /// <param name="format">the format of the documentation content</param>
        /// <param name="content">a string containing the documentation content</param>
        /// <returns>a documentation Section</returns>
        public Section AddCustomSection(SoftwareSystem softwareSystem, string name, int group, DocumentationFormat format, String content)
        {
            return AddSection(softwareSystem, name, group, format, content);
        }
    
        protected Section AddSection(Element element, string type, int group, DocumentationFormat format, string content)
        {
            if (group < 1)
            {
                group = 1;
            }
            else if (group > 5)
            {
                group = 5;
            }
    
            Section section = new Section(element, type, CalculateOrder(), group, format, content);
            if (!Sections.Contains(section))
            {
                Sections.Add(section);
                return section;
            }
            else
            {
                throw new ArgumentException("A section of type " + type +
                        (element != null ? " for " + element.Name : "")
                        + " already exists.");
            }
        }
    
        private int CalculateOrder()
        {
            return Sections.Count+1;
        }
    
        /// <summary>
        /// Adds png/jpg/jpeg/gif images in the given directory to the workspace.
        /// </summary>
        /// <param name="directory">a DirectoryInfo representing the directory containing image files</param>
        public void AddImages(DirectoryInfo directory)
        {
            if (directory == null)
            {
                throw new ArgumentException("Directory path must not be null.");
            }
            
            if (File.Exists(directory.FullName))
            {
                throw new ArgumentException(directory.FullName + " is not a directory.");
            }
            
            if (Directory.Exists(directory.FullName))
            {
                AddImagesFromPath("", directory);
            }
            else
            {
                throw new ArgumentException(directory.FullName + " does not exist.");
            }
        }

        private void AddImagesFromPath(string root, DirectoryInfo directory)
        {
            AddImagesFromPath(root, directory, "*.png");
            AddImagesFromPath(root, directory, "*.jpg");
            AddImagesFromPath(root, directory, "*.jpeg");
            AddImagesFromPath(root, directory, "*.gif");

            foreach (string directoryName in Directory.EnumerateDirectories(directory.FullName))
            {
                AddImagesFromPath(new FileInfo(directoryName).Name + "/", new DirectoryInfo(directoryName));
            }
        }

        private void AddImagesFromPath(string root, DirectoryInfo directory, string fileExtension)
        {
            foreach (string fileName in Directory.EnumerateFiles(directory.FullName, fileExtension, SearchOption.TopDirectoryOnly))
            {
                Image image = AddImage(new FileInfo(fileName));

                if (!String.IsNullOrEmpty(root))
                {
                    image.Name = root + image.Name;
                }
            }
        }

        /// <summary>
        /// Adds an image from the given file to the workspace.
        /// </summary>
        /// <param name="file">a FileInfo representing the image file on disk</param>
        /// <returns>an Image object representing the image added</returns>
        public Image AddImage(FileInfo file)
        {
            string contentType = ImageUtils.GetContentType(file);
            string base64String = ImageUtils.GetImageAsBase64(file);

            Image image = new Image(file.Name, base64String, contentType);
            Images.Add(image);

            return image;
        }

        public bool IsEmpty() {
            return Sections.Count == 0 && Images.Count == 0;
        }

    }


}

