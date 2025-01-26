using MAUIExamples.Core.Enums;
using Microsoft.AspNetCore.Components.Forms;

namespace MAUIExamples.Helper
{
    public static class FileHelper
    {
        public static readonly int MAXFILESIZE = 1024 * 800;
        public static readonly string[] SUPPORTEDIMAGEFORMATS = ["png", "jpg", "jpeg"];

        public static string ValidateFile(IBrowserFile file)
        {
            var error = string.Empty;
            if (file.Size >= MAXFILESIZE)
            {
                var sizeInMB = MAXFILESIZE / 1000;
                error = $"File is too big. Max {sizeInMB} MB";
                return error;
            }
            var fileType = GetFileType(file.ContentType);
            if (fileType == FileType.NotSupported)
            {
                error = "This file format is not supported";
                return error;
            }
            return error;
        }

        public static FileType GetFileType(string contentType)
        {
            if (contentType.Contains("application/pdf"))
            {
                return FileType.PDF;
            }
            if (SUPPORTEDIMAGEFORMATS.Any(x => contentType.EndsWith(x, StringComparison.CurrentCultureIgnoreCase)))
            {
                return FileType.Image;
            }
            return FileType.NotSupported;
        }

        public static async Task<(byte[] bytes, string imageType)> LoadBrowserFile(IBrowserFile file)
        {
            var buffers = new byte[file.Size];
            string imageType = file.ContentType;
            await file.OpenReadStream(MAXFILESIZE).ReadAsync(buffers);
            return (buffers, imageType);
        }

        public static string GetBase64URL(byte[] buffers, string imageType)
        {
            string imgUrl = $"data:{imageType};base64,{Convert.ToBase64String(buffers)}";
            return imgUrl;
        }

        public static string GetBase64URL(string filePath)
        {
            if (File.Exists(filePath))
            {
                var fileType = Path.GetExtension(filePath).Remove(0, 1);
                var imageType = ConvertLocalFile(fileType);
                byte[] bytes = File.ReadAllBytes(filePath);
                string imgUrl = $"data:{imageType};base64,{Convert.ToBase64String(bytes)}";
                return imgUrl;
            }
            throw new DirectoryNotFoundException();
        }

        public static List<string> GetFilesFromDirectory(string targetDirectory)
        {
            var fileNames = new List<string>();
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                fileNames.Add(fileName);
            }

            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                fileNames.AddRange(GetFilesFromDirectory(subdirectory));

            return fileNames;
        }

        private static string ConvertLocalFile(string fileType)
        {
            if (fileType.Contains("pdf"))
            {
                return "application/png";
            }
            else if (SUPPORTEDIMAGEFORMATS.Any(x => fileType.Contains(x, StringComparison.CurrentCultureIgnoreCase)))
            {
                return $"image/{fileType}";
            }
            else
            {
                return "";
            }
        }
    }
}
