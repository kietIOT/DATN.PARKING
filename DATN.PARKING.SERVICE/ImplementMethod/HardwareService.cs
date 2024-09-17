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
        public void Servo(string gate)
        {
            try
            {
                switch (gate)
                {
                    case "GateIn":
                        
                            serialPort.Write("opengatein"); // Gửi lệnh '1' để mở servo
                        break;
                    case "GateOut":
                       
                        
                            serialPort.Write("opengateout"); // Gửi lệnh '2' để mở servo
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
