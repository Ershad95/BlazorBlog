using BlazorBlog_Server.Services.IServices;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorBlog_Server.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileUploadService(IWebHostEnvironment _webHostEnvironment)
        {
            this.webHostEnvironment = _webHostEnvironment;   
        }

   
        public bool DeleteFile(string fileName)
        {
            try
            {
                var path = $"{webHostEnvironment.WebRootPath}\\images\\{fileName}";
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
              
                throw e;
            }
        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(file.Name);
                string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
                
                var folderDirectory = $"{webHostEnvironment.WebRootPath}\\images";
                var path = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);

                var memoryStream = new MemoryStream();
                await file.OpenReadStream().CopyToAsync(memoryStream);

                if (!Directory.Exists(folderDirectory))
                {
                    Directory.CreateDirectory(folderDirectory);
                }

                await using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    memoryStream.WriteTo(fs);
                }

                return fileName;

            }
            catch (Exception e)
            {
               
                throw e;
            }
        }
    }
}
