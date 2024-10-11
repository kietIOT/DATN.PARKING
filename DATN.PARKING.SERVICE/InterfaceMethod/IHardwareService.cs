using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.SERVICE.InterfaceMethod
{
    public interface IHardwareService
    {
        void Servo(string gate);
        void AruduinoInit(string portName, int baudRate);


        void QrScanInit(string portName, int baud, ref SerialPort port, SerialDataReceivedEventHandler dataReceivedCallback);
        string ReadDataQrScan(SerialPort _serIn);


         string ReadFingerSensor();


         string ReadBilledAmount();
    }
}
