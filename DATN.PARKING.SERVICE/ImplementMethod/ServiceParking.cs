using DATN.PARKING.DLL;
using DATN.PARKING.DLL.Models.DbTable;
using DATN.PARKING.DLL.Models.Dtos;
using DATN.PARKING.SERVICE.InterfaceMethod;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Http;
using System.Text;

namespace DATN.PARKING.SERVICE.ImplementMethod
{
    public class ServiceParking : IServiceParking
    {
        private readonly IUnitOfWork<ParkingContext> _unitOfWork;
        private readonly IHttpClientFactory _httpClientFactory;
        private const string HttpClientName = "TTOS";
        public ServiceParking(IUnitOfWork<ParkingContext> unitOfWork, IHttpClientFactory httpClientFactory)
        {
            _unitOfWork = unitOfWork;
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public bool Login(string userName, string password)
        {
            try
            {
                return (!_unitOfWork.Context.Accounts.Any(c => c.UserName == userName.TrimEx() && c.Password == password.Trim())) ? false : true;
            }
            catch { return false; }

        }

        public async Task<string> SendDataToRegonize(string imageUrl)
        {
            try
            {
                var url = $"http://localhost:8080/";
                var client = _httpClientFactory.CreateClient(HttpClientName);

                var content = new StringContent(JsonConvert.SerializeObject(new { ImageUrl = imageUrl }), Encoding.UTF8, "application/json");

                HttpResponseMessage response;
                response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    // Đọc và trả về nội dung phản hồi dưới dạng chuỗi
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Xử lý khi API trả về lỗi
                    throw new Exception($"API trả về lỗi: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi gửi dữ liệu đến API: {ex.Message}");
            }
        }

        public bool SaveCapturedImage(Bitmap image)
        {
            try
            {
                // Đường dẫn lưu trữ ảnh
                string folderPath = @"C:\Images";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Tạo tên file dựa trên thời gian hiện tại để đảm bảo tên file không bị trùng
                string fileName = Path.Combine(folderPath, $"Image_{DateTime.Now:yyyyMMdd_HHmmss}.jpg");

                // Lưu ảnh với định dạng JPEG
                image.Save(fileName, ImageFormat.Jpeg);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ParkingSlot> GetAllParkingSlot()
        {
            try
            {
                var list = _unitOfWork.Context.ParkingSlots.ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
