using BE_thesis.Data;
using BE_thesis.Enum;
using BE_thesis.Filters;
using BE_thesis.InputModel;
using BE_thesis.Services;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.X9;
using System.Configuration;
using System.Security.Policy;

namespace BE_thesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;

        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet("vnpay")]
        [Authorize(Roles = $"{nameof(UserRole.Admin)},{nameof(UserRole.Manager)},{nameof(UserRole.Staff)}")]
        [Authorization]
        public async Task<IActionResult> VnPay(double amount)
        {
        //Get Config Info
            string vnp_Returnurl = _configuration.GetValue<string?>("VNPay:ReturnUrl") ; //URL nhan ket qua tra ve 
            string vnp_Url = _configuration.GetValue<string?>("VNPay:Url"); //URL thanh toan cua VNPAY 
            string vnp_TmnCode = _configuration.GetValue<string?>("VNPay:TmnCode"); //Ma  định danh merchant kết nối (Terminal Id)
            string vnp_HashSecret = _configuration.GetValue<string?>("VNPay:HashSecret"); //Secret Key
            //Get payment input
            var orderId = DateTime.UtcNow.Ticks; // Giả lập mã giao dịch hệ thống merchant gửi sang VNPAY
            var orderAmount = (int)amount; // Giả lập số tiền thanh toán hệ thống merchant gửi sang VNPAY 100,000 VND
            //var orderStatus = "0"; //0: Trạng thái thanh toán "chờ thanh toán" hoặc "Pending" khởi tạo giao dịch chưa có IPN
            var orderCreatedAt = DateTime.UtcNow;
            //Save order to db

            //Build URL for VNPAY
            VnPayLibrary vnpay = new VnPayLibrary();

            vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", (orderAmount * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000
            vnpay.AddRequestData("vnp_CreateDate", orderCreatedAt.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", HttpContext.Connection.RemoteIpAddress.ToString());
            vnpay.AddRequestData("vnp_Locale", "vn");
            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + orderId);
            vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_TxnRef", orderId.ToString()); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày

            //Add Params of 2.1.0 Version
            //Billing

            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
            //return Redirect(paymentUrl);

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success",
                new {Url = paymentUrl }));

        }

        [HttpGet("vnpay/returned-url")]
        public async Task<IActionResult> VnPayReturnedUrl([FromQuery]ApiPaymentReturnedUrlInput input)
        {
            if(input.Vnp_ResponseCode.Equals("00") && input.Vnp_TransactionStatus.Equals("00"))
            {
                return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Giao dịch thành công", input));
            }
            else
            {
                if (input.Vnp_ResponseCode.Equals("07"))
                {
                    return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Trừ tiền thành công. Giao dịch bị nghi ngờ (liên quan tới lừa đảo, giao dịch bất thường).", input));
                }
                else if (input.Vnp_ResponseCode.Equals("09"))
                {
                    return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Giao dịch không thành công do: Thẻ/Tài khoản của khách hàng chưa đăng ký dịch vụ InternetBanking tại ngân hàng.", input));
                }
                else if (input.Vnp_ResponseCode.Equals("10"))
                {
                    return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Giao dịch không thành công do: Khách hàng xác thực thông tin thẻ/tài khoản không đúng quá 3 lần", input));
                }
                else if (input.Vnp_ResponseCode.Equals("11"))
                {
                    return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, " Giao dịch không thành công do: Đã hết hạn chờ thanh toán. Xin quý khách vui lòng thực hiện lại giao dịch.", input));
                }
                else if (input.Vnp_ResponseCode.Equals("12"))
                {
                    return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Giao dịch không thành công do: Thẻ/Tài khoản của khách hàng bị khóa.", input));
                }
                else if (input.Vnp_ResponseCode.Equals("13"))
                {
                    return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Giao dịch không thành công do Quý khách nhập sai mật khẩu xác thực giao dịch (OTP). Xin quý khách vui lòng thực hiện lại giao dịch.", input));
                }
                else if (input.Vnp_ResponseCode.Equals("24"))
                {
                    return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Giao dịch không thành công do: Khách hàng hủy giao dịch", input));
                }
                else if (input.Vnp_ResponseCode.Equals("51"))
                {
                    return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Giao dịch không thành công do: Tài khoản của quý khách không đủ số dư để thực hiện giao dịch.", input));
                }
                else if (input.Vnp_ResponseCode.Equals("65"))
                {
                    return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Giao dịch không thành công do: Tài khoản của Quý khách đã vượt quá hạn mức giao dịch trong ngày.", input));
                }
                else if (input.Vnp_ResponseCode.Equals("75"))
                {
                    return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Ngân hàng thanh toán đang bảo trì.", input));
                }
                else if (input.Vnp_ResponseCode.Equals("79"))
                {
                    return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Giao dịch không thành công do: KH nhập sai mật khẩu thanh toán quá số lần quy định. Xin quý khách vui lòng thực hiện lại giao dịch", input));
                }
                else
                {
                    return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Lỗi không xác định", input));
                }
            }
        }

    }
}
