using DATN.PARKING.DLL.Models.DbTable;
using DATN.PARKING.DLL.Models.Dtos;

namespace DATN.PARKING.SERVICE.InterfaceMethod
{
    public interface IServiceParking
    {
        bool Login(string userName, string password); // đăng nhập


        #region Quản lý phương tiện (Vehicle Management)
        void RegisterVehicle(Information info); //Đăng ký thông tin phương tiện khi vào bãi.
        void UpdateVehicleInformation(int infoId, Information updatedInfo); // Cập nhật thông tin phương tiện.
        List<string> GetAllVehicleType();
        #endregion

        #region Quản lý thanh toán (Payment Management)
        void ProcessPayment(Payment payment); // Xử lý thanh toán khi phương tiện rời bãi.
        double CalculateTotalAmountForVehicle(int infoId); // Tính tổng số tiền cần thanh toán cho một phương tiện dựa trên thời gian đỗ xe và loại phương tiện.
        #endregion


        #region Quản lý khách hàng (Customer Management)
        void RegisterCustomer(Customer customer); // : Đăng ký khách hàng mới.
        void UpdateCustomer(int customerId, Customer updatedCustomer); // Cập nhật thông tin khách hàng.
        void DeleteCustomer(int customerId); // Xóa thông tin khách hàng.
        void GetCustomerDetails(int customerId); // Lấy thông tin chi tiết của khách hàng.
        List<Customer> ListAllCustomers();// Liệt kê tất cả khách hàng.
        #endregion

        #region Quản lý giá cả (Pricing Management)
        void SetPricing(Pricing pricing);//: Đặt giá cho các loại phương tiện khác nhau.
        void UpdatePricing(int pricingId, Pricing updatedPricing);//: Cập nhật giá cho một loại phương tiện.
        Pricing GetPricingDetails(string vehicleType);//: Lấy thông tin giá cho một loại phương tiện.
        #endregion


        #region Báo cáo doanh thu: Tổng doanh thu theo ngày, tháng, loại phương tiện, phương thức thanh toán.
        #endregion

        #region Báo cáo sử dụng: Thống kê lượng xe ra vào, số chỗ trống, thời gian đỗ xe trung bình.
        #endregion

        #region Báo cáo khách hàng: Thống kê khách hàng theo loại thành viên, điểm tích lũy, lượng đặt chỗ.
        #endregion
        List<ViewInformationCustomer> GetAllInfomationCustomer(DateTime ngayra, DateTime ngayvao, string cccd, string name, string biensoxe, string loaixe);
        #region 
        #endregion

        #region Báo cáo khách hàng: Thống kê khách hàng theo loại thành viên, điểm tích lũy, lượng đặt chỗ.
        #endregion
    }
}
