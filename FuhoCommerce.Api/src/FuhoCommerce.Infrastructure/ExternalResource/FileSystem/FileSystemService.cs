using FuhoCommerce.Application.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuhoCommerce.Infrastructure.ExternalResource.FileSystem
{
    public class FileSystemService : IFileSystemService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private const string NoImage = "no-image.jpg";
        private readonly string[] permittedExtensions = { "jpg", "png", "jpeg" };

        public FileSystemService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> BulkUpload(List<IFormFile> files)
        {
            var imageList = string.Empty;
            foreach (var file in files)
            {
                var fileName = await SingleUpload(file);
                imageList += string.Join(", ", fileName);
            }
            return imageList;
        }

        public async Task<string> SingleUpload(IFormFile file)
        {
            if (file != null && await IsValid(file) && file.Length > 0)
            {
                return await ProcessUploading(file);
            }
            else
            {
                return NoImage;
            }
        }

        public async Task<string> SingleUpdate(IFormFile file, string previousImage)
        {
            if (file != null && await IsValid(file) && file.Length > 0)
            {
                return await ProcessUploading(file);
            }
            else
            {
                return previousImage;
            }
        }

        private async Task<string> ProcessUploading(IFormFile file)
        {
            var imageRoot = Path.Combine(_hostingEnvironment.WebRootPath, "images");
            if (!Directory.Exists(imageRoot))
            {
                Directory.CreateDirectory(imageRoot);
            }

            var fileName = string.Concat(Guid.NewGuid(), "_", Path.GetFileName(file.FileName));
            var filePath = Path.Combine(imageRoot, fileName);
            using var fileSteam = new FileStream(filePath, FileMode.Create);

            await file.CopyToAsync(fileSteam);

            return fileName;
        }

        private async Task<bool> IsValid(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var dotCount = file.FileName.Count(x => x == '.');
            if (!permittedExtensions.Contains(extension.ToLower()) 
                && dotCount > 1)
            {
                return false;
            }
            return true;
        }
    }
}
