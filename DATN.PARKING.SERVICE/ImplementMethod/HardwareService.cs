using DATN.PARKING.DLL.Models.DbTable;
using DATN.PARKING.SERVICE.InterfaceMethod;
using System.IO.Ports;
namespace DATN.PARKING.SERVICE.ImplementMethod
{
    public class HardwareService : IHardwareService
    {
        private  SerialPort serialPort;
       
        public void ServoInit(string portName, int baudRate)
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
        public void QrScanInit(string portName, int baud, ref SerialPort port, SerialDataReceivedEventHandler dataReceivedCallback)
        {
            try
            {
                port = new SerialPort(portName, baud, Parity.None, 8, StopBits.One);
                port.DataReceived += dataReceivedCallback;
                port.Open();
            }
            catch(Exception e)
            {
                throw e;
            }

        }
        public string ReadDataQrScan(SerialPort port)
        {
            try
            {
                
                if (port == null || !port.IsOpen)
                {
                    throw new Exception("Không kết nối được với cổng COM !");
                }
                string data = port.ReadLine().Trim();
                string splitData = string.Empty;
                var entity = new Vehicle();
                if (!string.IsNullOrEmpty(data))
                {
                    splitData = data.Substring(0, 12);

                }
                return splitData;
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

        public string ReadFingerSensor()
        {
            try
            {
                // Đọc dữ liệu từ Arduino
                string data = serialPort.ReadLine().Trim();
                if (!data.StartsWith("FINGERPRINT:"))
                    return "";
                return data.Substring("FINGERPRINT:".Length);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string ReadBilledAmount()
        {
            try
            {
                // Đọc dữ liệu từ Arduino
                string data = serialPort.ReadLine().Trim();
                if (!data.StartsWith("LIGHTSENSOR:"))
                    return "";
                return data.Substring("LIGHTSENSOR:".Length);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
