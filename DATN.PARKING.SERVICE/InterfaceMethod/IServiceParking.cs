using DATN.PARKING.DLL.Models.DbTable;
using DATN.PARKING.DLL.Models.Dtos;
using System.Drawing;
using System.Net.Sockets;

namespace DATN.PARKING.SERVICE.InterfaceMethod
{
    public interface IServiceParking
    {
       
        bool Login(string userName, string password); // đăng nhập


        List<ParkingSlot> GetAllParkingSlot();


        Task<string> SendDataToRegonize(string imageUrl);

        ParkingSession GateIn(string? cccd, string? rfid, int? fingerprintData, string licensePlate);
        ParkingSession GateOut(string? cccd, string? rfid, int? fingerprintData, string licensePlate);

        bool SaveCapturedImage(Bitmap image,string gate);

        void AddParkingSession(ParkingSession parkingSession);
        void TcpInit();
    }
}
