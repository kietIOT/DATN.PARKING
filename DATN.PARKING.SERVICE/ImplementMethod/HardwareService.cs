using DATN.PARKING.SERVICE.InterfaceMethod;
using System.IO.Ports;
namespace DATN.PARKING.SERVICE.ImplementMethod
{
    public class HardwareService : IHardwareService
    {
        private SerialPort serialPort;
        public void HardwareServiceInit(string portName, int baudRate)
        {
            try
            {
                // Khởi tạo kết nối SerialPort
                serialPort = new SerialPort(portName, baudRate);
                serialPort.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Servo(string gate, string status)
        {
            try
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
                            serialPort.Write("1"); // Gửi lệnh '3' để mở servo
                        }
                        else if (serialPort.IsOpen && status == "close")
                        {
                            serialPort.Write("2"); // Gửi lệnh '4' để đóng servo
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

    }
}
