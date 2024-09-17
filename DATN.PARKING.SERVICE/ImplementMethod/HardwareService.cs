using DATN.PARKING.SERVICE.InterfaceMethod;
using System;
using System.IO.Ports;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace DATN.PARKING.SERVICE.ImplementMethod
{
    public class HardwareService : IHardwareService
    {
        private SerialPort serialPort;
     


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
        public void QrScanInit(string portName, int baud, ref SerialPort _serIn, ref SerialPort _serOut, SerialDataReceivedEventHandler dataReceivedCallback)
        {
            _serOut = new SerialPort(portName, baud, Parity.None, 8, StopBits.One);
            _serIn = new SerialPort(portName, baud, Parity.None, 8, StopBits.One);
            _serIn.DataReceived += dataReceivedCallback;
            _serIn.Open();

        }
        public void QrScanGateIn(SerialPort _serIn)
        {
            try
            { 
                if (_serIn != null && _serIn.IsOpen)
                {
                    string data = _serIn.ReadLine().Trim();

                    if (!string.IsNullOrEmpty(data))
                    {
                        string splitData = data.Substring(0, 12);
                        string currTime = DateTime.Now.ToString("HH:mm:ss");
                        string dateTime = DateTime.Today.ToString("yyyy-MM-dd");

                        Console.WriteLine($"Xe vào - Thời gian: {currTime} | CCCD: {splitData} | Biển số xe: ");

                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void ReadSerialOut(SerialPort _serOut)
        {
            while (true)
            {
                try
                {
                    if (_serOut.IsOpen)
                    {
                        string data = _serOut.ReadLine();
                        if (!string.IsNullOrEmpty(data))
                        {
                            // Handle data from serial port Out
                            // Example: Call functions like WriteOut, update_OBJECT_1_labels, etc.
                        }
                    }
                }
                catch (TimeoutException) { }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading from serial port Out: {ex.Message}");
                }
            }
        }
        public void QrScanGateOut(string data, string licensePlate)
        {
            throw new NotImplementedException();
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

      
       
        public void ReadSerialIn(SerialPort _serIn)
        {
            while (true)
            {
                try
                {
                    if (_serIn.IsOpen)
                    {
                        string data2 = _serIn.ReadLine();
                        if (!string.IsNullOrEmpty(data2))
                        {
                            // Handle data from serial port In
                            // Example: Call functions like WriteIn, update_OBJECT_1_labels, etc.
                        }
                    }
                }
                catch (TimeoutException) { }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading from serial port In: {ex.Message}");
                }
            }
        }
    }
}
