
using QRCoder;
using System.Drawing;

namespace BE_thesis.Services
{
    public class QRCodeManager : IQRCodeManager
    {
        public async Task<Bitmap> GenerateQRCodeAsync(string qrText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }
    }
}
