using DATN.PARKING.DLL;
using DATN.PARKING.DLL.Models.DbTable;
using DATN.PARKING.DLL.Models.Dtos;
using DATN.PARKING.SERVICE.InterfaceMethod;

namespace DATN.PARKING.SERVICE.ImplementMethod
{
    public class ServiceParking : IServiceParking
    {
        private readonly IUnitOfWork<ParkingContext> _unitOfWork;
        private readonly IHardwareService _hardwareService;
        public ServiceParking(IUnitOfWork<ParkingContext> unitOfWork, IHardwareService hardwareService)
        {
            _unitOfWork = unitOfWork;
            _hardwareService = hardwareService;
        }

        public double CalculateTotalAmountForVehicle(int infoId)
        {
            try
            {
                var vehicleInfo = _unitOfWork.Context.Informations.FirstOrDefault(c => c.InfomationId == infoId);
                if (vehicleInfo == null)
                {
                    throw new Exception("Thông tin phương tiện không tồn tại.");
                }
                var parkingDuration = vehicleInfo.NgayRa - vehicleInfo.NgayVao;
                var totalHours = parkingDuration.TotalHours;

                var pricing = _unitOfWork.Context.Pricings.FirstOrDefault(p => p.TenPhuongTien == vehicleInfo.TenPhuongTien);
                if (pricing == null)
                {
                    throw new Exception("Không có thông tin giá cho loại phương tiện này.");
                }
                double totalAmount = 0;
                if (totalHours <= 24)
                {
                    totalAmount = (double)totalHours * pricing.PricePerHour;
                }
                else
                {
                    totalAmount = ((double)totalHours / 24) * pricing.PricePerDay;
                }


                return totalAmount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void DeleteCustomer(int customerId)
        {
            try
            {
                var entity = _unitOfWork.Context.Customers.FirstOrDefault(c => c.KhachHangId == customerId);
                if (entity != null)
                {
                    _unitOfWork.Context.Customers.Remove(entity);
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }

        public List<ViewInformationCustomer> GetAllInfomationCustomer(DateTime ngayra, DateTime ngayvao, string cccd, string name, string biensoxe, string loaixe)
        {
            try
            {
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> GetAllVehicleType()
        {
            try
            {
                return _unitOfWork.Context.Vehicles.Select(c=>c.TenPhuongTien).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GetCustomerDetails(int customerId)
        {
            throw new NotImplementedException();
        }

        public Pricing GetPricingDetails(string vehicleType)
        {
            try
            {
                var pricing = _unitOfWork.Context.Pricings.FirstOrDefault(p => p.TenPhuongTien == vehicleType);

                if (pricing == null)
                {
                    throw new Exception("Không tìm thấy thông tin giá cho loại phương tiện này.");
                }

                return pricing;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Customer> ListAllCustomers()
        {
            try
            {
                return _unitOfWork.Context.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Login(string userName, string password)
        {
            return (_unitOfWork.Context.Accounts.FirstOrDefault(c => c.UserName == userName.TrimEx() && c.Password == password.Trim()) == null) ? false : true;

        }

        public void ProcessPayment(Payment payment)
        {
            try
            {
                var vehicleInfo = _unitOfWork.Context.Informations.FirstOrDefault(info => info.PaymentId == payment.PaymentId);
                if (vehicleInfo == null)
                {
                    throw new Exception("Thông tin phương tiện không tồn tại.");
                }

                // Bước 2: Tính tổng số tiền cần thanh toán
                double totalAmount = CalculateTotalAmountForVehicle(vehicleInfo.VehicleId);

                // Bước 3: Kiểm tra số tiền khách hàng đã trả
                if (payment.TienKhachTra < totalAmount)
                {
                    throw new Exception("Số tiền khách trả không đủ.");
                }

                // Bước 4: Lưu thông tin thanh toán vào cơ sở dữ liệu
                payment.TienTra = totalAmount;
                payment.NgayThanhToan = DateTime.Now;  // Ngày thanh toán
                _unitOfWork.Context.Payments.Add(payment);

                // Cập nhật trạng thái phương tiện
                vehicleInfo.Status = "Y"; // Hoặc một trạng thái khác để đánh dấu phương tiện đã thanh toán
                _unitOfWork.Context.Informations.Update(vehicleInfo);


                // Bước 6: Lưu tất cả các thay đổi vào cơ sở dữ liệu
                _unitOfWork.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RegisterCustomer(Customer customer)
        {
            try
            {
                var existingCustomer = _unitOfWork.Context.Customers.FirstOrDefault(c => c.SoDienThoai == customer.SoDienThoai || c.Email == customer.Email);

                if (existingCustomer != null)
                {
                    throw new Exception("Khách hàng với số điện thoại hoặc email này đã tồn tại.");
                }

                // Thiết lập ngày đăng ký cho khách hàng mới
                customer.NgayDangKy = DateTime.Now;

                // Thêm khách hàng mới vào cơ sở dữ liệu
                _unitOfWork.Context.Customers.Add(customer);
                _unitOfWork.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public void RegisterVehicle(Information info)
        {
            try
            {
                // Kiểm tra xem biển số xe đã tồn tại trong bãi chưa và chưa rời khỏi bãi
                var existingVehicle = _unitOfWork.Context.Informations.FirstOrDefault(i => i.BienSoXe == info.BienSoXe && i.Status != "Y");

                if (existingVehicle != null)
                {
                    throw new Exception("Phương tiện này đã được đăng ký và chưa rời khỏi bãi.");
                }
                //var entity = _hardwareService.ReadDataQrScan();
                // Thiết lập ngày vào bãi và trạng thái của phương tiện
                info.NgayVao = DateTime.Now;
                info.Status = "Y"; // Gắn cờ rằng xe đã vào bãi

                // Đăng ký thông tin phương tiện mới vào cơ sở dữ liệu
                _unitOfWork.Context.Informations.Add(info);
                _unitOfWork.Context.SaveChanges();
            }
            catch(Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public void SetPricing(Pricing pricing)
        {
            try
            {
                var existingPricing = _unitOfWork.Context.Pricings.FirstOrDefault(p => p.VehicleId == pricing.VehicleId);
                if (existingPricing != null)
                {
                    throw new Exception("Giá cho loại phương tiện này đã tồn tại.");
                }

                // Thêm giá mới vào cơ sở dữ liệu
                _unitOfWork.Context.Pricings.Add(pricing);
                _unitOfWork.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateCustomer(int customerId, Customer updatedCustomer)
        {
            try
            {
                var existingCustomer = _unitOfWork.Context.Customers.FirstOrDefault(c => c.KhachHangId == customerId);

                if (existingCustomer == null)
                {
                    throw new Exception("Không tìm thấy thông tin khách hàng với ID này.");
                }

                // Cập nhật các thuộc tính của khách hàng
                existingCustomer.HoVaTen = updatedCustomer.HoVaTen;
                existingCustomer.DiaChi = updatedCustomer.DiaChi;
                existingCustomer.SoDienThoai = updatedCustomer.SoDienThoai;
                existingCustomer.Diem = updatedCustomer.Diem;
                existingCustomer.LoaiThanhVien = updatedCustomer.LoaiThanhVien;
                existingCustomer.Email = updatedCustomer.Email;

                // Lưu các thay đổi vào cơ sở dữ liệu
                _unitOfWork.Context.Customers.Update(existingCustomer);
                _unitOfWork.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public void UpdatePricing(int pricingId, Pricing updatedPricing)
        {
            var existingPricing = _unitOfWork.Context.Pricings.FirstOrDefault(p => p.PricingId == pricingId);

            if (existingPricing == null)
            {
                throw new Exception("Không tìm thấy thông tin giá cho ID này.");
            }

            // Cập nhật các thuộc tính của giá
            existingPricing.PricePerHour = updatedPricing.PricePerHour;
            existingPricing.PricePerDay = updatedPricing.PricePerDay;
            existingPricing.PricePerMonth = updatedPricing.PricePerMonth;

            // Lưu thay đổi vào cơ sở dữ liệu
            _unitOfWork.Context.Pricings.Update(existingPricing);
            _unitOfWork.Context.SaveChanges();
        }

        public void UpdateVehicleInformation(int infoId, Information updatedInfo)
        {
            throw new NotImplementedException();
        }
    }
}
