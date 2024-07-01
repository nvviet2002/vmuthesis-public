using System.Drawing;

namespace BE_thesis.Services
{
    public interface IQRCodeManager
    {
        public Task<Bitmap> GenerateQRCodeAsync(string qrText);
    }
}
