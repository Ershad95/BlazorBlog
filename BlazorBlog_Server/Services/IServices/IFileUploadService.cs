using Microsoft.AspNetCore.Components.Forms;

namespace BlazorBlog_Server.Services.IServices
{
    public interface IFileUploadService
    {
        Task<string> UploadFile(IBrowserFile file);
        bool DeleteFile(string fileName);
    }
}
