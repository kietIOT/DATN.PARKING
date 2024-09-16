using DATN.PARKING.SERVICE.InterfaceMethod;
using System.IO.Ports;
namespace DATN.PARKING.SERVICE.ImplementMethod
{
    public class HardwareService : IHarwareService
    {
        private SerialPort serialPort;
        public HardwareService(string portName, int baudRate = 9600)
        {
            // Khởi tạo kết nối SerialPort
            serialPort = new SerialPort(portName, baudRate);
            serialPort.Open();
        }
        public void Servo(string gate, string status)
        {
            switch (gate)
            {
                case "GateIn":
                    if (serialPort.IsOpen && status == "open")
                    {
                        serialPort.Write("1"); // Gửi lệnh '1' để mở servo
                    }
                    else if (serialPort.IsOpen && status == "close")
                    {
                        serialPort.Write("2"); // Gửi lệnh '2' để đóng servo
                    }
                    break;
                case "GateOut":
                    if (serialPort.IsOpen && status == "open")
                    {
                        serialPort.Write("3"); // Gửi lệnh '3' để mở servo
                    }
                    else if (serialPort.IsOpen && status == "close")
                    {
                        serialPort.Write("4"); // Gửi lệnh '4' để đóng servo
                    }
                    break;
                default:
                    break;
            }

        }


    }
}
