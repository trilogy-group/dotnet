using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Structurizr.Util
{
    public class ImageUtils
    {

        public static string GetContentType(FileInfo file)
        {
            string contentType = file.FullName.Substring(file.FullName.LastIndexOf(".") + 1).ToLower();
            if (contentType.Equals("jpg"))
            {
                contentType = "jpeg";
            }

            return "image/" + contentType;
        }

        public static string GetImageAsBase64(FileInfo file)
        {
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(file.FullName))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    return Convert.ToBase64String(imageBytes);
                }
            }
        }

        public static string GetImageAsDataUri(FileInfo file)
        {
            if (file == null)
            {
                throw new ArgumentException("File must not be null.");
            }
            else if (Directory.Exists(file.FullName))
            {
                throw new ArgumentException("The file " + file.FullName + " does not exist.");
            }
            else if (!File.Exists(file.FullName))
            {
                throw new ArgumentException(file.FullName + " is not a file.");
            }

            String contentType = ImageUtils.GetContentType(file);
            String base64Content = ImageUtils.GetImageAsBase64(file);

            return "data:" + contentType + ";base64," + base64Content;
        }

    }

}
