using System.Drawing;

namespace BE_thesis.Services
{
    public interface IFileManager
    {
        public Task<string> UploadFile(IFormFile postedFile, string fileName, string webRootDir);

        public Task<string> SaveQRFile(Bitmap bitmap, string fileName, string webRootDir);

        public Task<FileStream?> ReadFile(string fileName, string webRootDir);
        public Task<string> GetFilePath(string fileName, string webRootDir);
    }
}
