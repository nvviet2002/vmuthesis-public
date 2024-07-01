using BE_thesis.Context;
using BE_thesis.Data;
using BE_thesis.InputModel;
using BE_thesis.Model;
using BE_thesis.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BE_thesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadController : Controller
    {
        private readonly IFileManager _fileManager;

        public DownloadController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        [HttpGet("mobile")]
        public async Task<IActionResult> Mobile()
        {
            var path = await _fileManager.GetFilePath("vmu-thesis.apk", "Downloads/Mobile");
            if(!System.IO.File.Exists(path))
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "Không tìm thấy file", null));
            }
            else
            {
                var bytes = System.IO.File.ReadAllBytes(path);
                return File(bytes, "application/octet-stream",Path.GetFileName(path));
            }
        }
    }
}
