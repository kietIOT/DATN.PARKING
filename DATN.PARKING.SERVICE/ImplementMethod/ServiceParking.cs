using DATN.PARKING.DLL;
using DATN.PARKING.DLL.Models.DbTable;
using DATN.PARKING.DLL.Models.Dtos;
using DATN.PARKING.SERVICE.InterfaceMethod;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

namespace DATN.PARKING.SERVICE.ImplementMethod
{
    public class ServiceParking : IServiceParking
    {
        private TcpListener _server;
        private bool _isRunning;
        private readonly IUnitOfWork<ParkingContext> _unitOfWork;
        private readonly IHttpClientFactory _httpClientFactory;
        private const string HttpClientName = "TTOS";
        public ServiceParking(IUnitOfWork<ParkingContext> unitOfWork, IHttpClientFactory httpClientFactory)
        {
            _unitOfWork = unitOfWork;
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));


        }
        public void TcpInit()
        {
            try
            {
                _server = new TcpListener(IPAddress.Any, 5000);
                _server.Start();
                _isRunning = true;
                var listenerThread = new Thread(ListenForClients);
                listenerThread.Start();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ListenForClients()
        {
            while (_isRunning)
            {
                // Chấp nhận kết nối từ ESP32
                TcpClient client = _server.AcceptTcpClient();

                // Xử lý kết nối trong một luồng khác
                var clientThread = new Thread(HandleClientComm);
                clientThread.Start(client);
            }
        }
        private void HandleClientComm(object client_obj)
        {
            TcpClient tcpClient = (TcpClient)client_obj;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    // Đọc dữ liệu từ ESP32
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    // Ngắt kết nối
                    break;
                }

                if (bytesRead == 0)
                {
                    // Kết nối đã đóng
                    break;
                }

                // Chuyển đổi dữ liệu nhận được thành chuỗi
                string receivedData = Encoding.ASCII.GetString(message, 0, bytesRead);
                Console.WriteLine("Received: " + receivedData);
            }

            tcpClient.Close();
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

        public bool SaveCapturedImage(Bitmap image, string gate)
        {
            try
            {

                // Đường dẫn lưu trữ ảnh

                string folderPath = @$"C:\Images\{gate}";
               
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

        public void AddParkingSession(ParkingSession parkingSession)
        {
            try
            {
                _unitOfWork.Context.ParkingSessions.Add(parkingSession);
                _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }
        }

        public ParkingSession GateIn(string? cccd, string? rfid, int? fingerprintData, string licensePlate)
        {
            try
            {
                var customer = _unitOfWork.Context.Customers.FirstOrDefault(c => c.CCCD == cccd || c.RFID == rfid || c.FingerprintData == fingerprintData);

                // If customer does not exist, create a new customer
                if (customer == null)
                {
                    customer = new Customer
                    {
                       
                        RegistrationDate = DateTime.Now,
                        CCCD = cccd,    // Optional, can be null
                        RFID = rfid,    // Optional, can be null
                        FingerprintData = fingerprintData  // Optional, can be null
                    };

                    _unitOfWork.Context.Customers.Add(customer);
                    _unitOfWork.SaveAsync();
                }

                // Add a vehicle to the customer if not found
                var vehicle = customer.Vehicles?.FirstOrDefault(v => v.LicensePlate == licensePlate);
                if (vehicle == null)
                {
                    vehicle = new Vehicle
                    {
                        LicensePlate = licensePlate,
                        CustomerId = customer.CustomerId
                    };
                    _unitOfWork.Context.Vehicles.Add(vehicle);
                    _unitOfWork.SaveAsync();
                }

                // Find an available parking slot
                var parkingSlot = _unitOfWork.Context.ParkingSlots.FirstOrDefault(s => s.IsOccupied == false || s.IsOccupied == null);
                if (parkingSlot == null)
                {
                    throw new Exception("No available parking slots.");
                }

                // Create a new ParkingSession
                var newSession = new ParkingSession
                {
                    VehicleId = vehicle.VehicleId,
                    ParkingSlotId = parkingSlot.SlotId,
                    EntryTime = DateTime.Now,
                    IsPaid = false
                };

                parkingSlot.IsOccupied = true;

                _unitOfWork.Context.ParkingSessions.Add(newSession);
                _unitOfWork.SaveAsync();

                return newSession;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ParkingSession GateOut(string? cccd, string? rfid, int? fingerprintData, string licensePlate)
        {
            try
            {
                var customer = _unitOfWork.Context.Customers.FirstOrDefault(c => c.CCCD == cccd || c.RFID == rfid || c.FingerprintData == fingerprintData);

                if (customer == null)
                {
                    throw new Exception("Customer not found.");
                }

                var vehicle = customer.Vehicles.FirstOrDefault();
                if (vehicle == null)
                {
                    throw new Exception("Vehicle not found.");
                }

                // Find the active parking session for the vehicle
                var session = _unitOfWork.Context.ParkingSessions
                    .FirstOrDefault(ps => ps.VehicleId == vehicle.VehicleId && ps.ExitTime == null);

                if (session == null)
                {
                    throw new Exception("No active parking session found.");
                }

                // Calculate the parking fee (e.g., 10 units per hour)
                var duration = DateTime.Now - session.EntryTime;
                session.PaymentAmount = (decimal)(duration?.TotalHours ?? 0) * 10; // Example rate
                session.IsPaid = true;
                session.ExitTime = DateTime.Now;

                // Free up the parking slot
                var parkingSlot = _unitOfWork.Context.ParkingSlots
                    .FirstOrDefault(s => s.SlotId == session.ParkingSlotId);

                if (parkingSlot != null)
                {
                    parkingSlot.IsOccupied = false;
                }

                _unitOfWork.SaveAsync();

                return session;
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }

        public Customer GetCustomerInfo(string? cccd, string? rfid, int? fingerprintData)
        {
            try
            {
                var customer = _unitOfWork.Context.Customers.FirstOrDefault(c => c.CCCD == cccd || c.RFID == rfid || c.FingerprintData == fingerprintData);
                if (customer == null)
                    return null;
                return customer;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                _unitOfWork.Context.Customers.Add(customer);
                _unitOfWork.SaveAsync();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public void AddVehicle(Vehicle vehicle)
        {
            try
            {
                _unitOfWork.Context.Vehicles.Add(vehicle);
                _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ParkingSlotAvailble(ParkingSlot parkingSlot)
        {
            try
            {
                var x = _unitOfWork.Context.ParkingSlots.FirstOrDefault(s => s.IsOccupied == false || s.IsOccupied == null);
                if (x == null) return false;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddParkingSlot(ParkingSlot parkingSlot)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Vehicle GetVehicleByPlateLicense(Customer customer, string licensePlate)
        {
            try
            {
                var vehicle = customer.Vehicles?.FirstOrDefault(v => v.LicensePlate == licensePlate);
                if (vehicle == null) return null;   
                return vehicle;
            }
            catch(Exception ex) 
                {  throw ex;}
        }
    }
}
