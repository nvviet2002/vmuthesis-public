using BE_thesis.Context;
using BE_thesis.Enum;
using System.Drawing;
using System.Drawing.Imaging;

namespace BE_thesis.Services
{
    public class FileManager: IFileManager
    {
        private readonly IWebHostEnvironment _environment;

        public FileManager(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> UploadFile(IFormFile postedFile, string fileName, string webRootDir)
        {
            try
            {
                string wwwPath = this._environment.WebRootPath;

                string path = Path.Combine(this._environment.WebRootPath, webRootDir);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string filePath = Path.Combine(path, fileName + Path.GetExtension(postedFile.FileName));
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await postedFile.CopyToAsync(stream);
                }
                return $"{webRootDir}/{fileName}{Path.GetExtension(postedFile.FileName)}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SaveQRFile(Bitmap bitmap, string fileName, string webRootDir)
        {
            try
            {
                string wwwPath = this._environment.WebRootPath;
                string contentPath = this._environment.ContentRootPath;


                string path = Path.Combine(this._environment.WebRootPath, webRootDir);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string filePath = Path.Combine(path, fileName + ".jpg");
                var memoryStream = new MemoryStream();
                bitmap.Save(memoryStream, ImageFormat.Jpeg);
                FileStream stream = new FileStream(filePath, FileMode.Create);
                memoryStream.Seek(0, SeekOrigin.Begin); //go back to start
                await memoryStream.CopyToAsync(stream);
                return $"{webRootDir}/{fileName}.jpg";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FileStream?> ReadFile(string fileName, string webRootDir)
        {
            try
            {
                string path = Path.Combine(this._environment.WebRootPath, webRootDir,fileName);
                if (File.Exists(path))
                {
                    return new FileStream(path, FileMode.Open, FileAccess.Read);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetFilePath(string fileName, string webRootDir)
        {
            string path = Path.Combine(this._environment.WebRootPath, webRootDir,fileName);
            return path;
        }

    }
}
