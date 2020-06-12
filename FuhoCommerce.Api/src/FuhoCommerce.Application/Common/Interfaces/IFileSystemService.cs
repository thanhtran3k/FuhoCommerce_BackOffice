using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.Common.Interfaces
{
    public interface IFileSystemService
    {
        Task<string> SingleUpload(IFormFile file);
        Task<string> BulkUpload(List<IFormFile> files);
        Task<string> SingleUpdate(IFormFile file, string previousImage);
    }
}
