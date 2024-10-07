using DATN.PARKING.DLL.Models.DbTable;
using DATN.PARKING.DLL.Models.Dtos;
using System.Drawing;

namespace DATN.PARKING.SERVICE.InterfaceMethod
{
    public interface IServiceParking
    {
        bool Login(string userName, string password); // đăng nhập


        List<ParkingSlot> GetAllParkingSlot();


        Task<string> SendDataToRegonize(string imageUrl);



        bool SaveCapturedImage(Bitmap image);


    }
}
