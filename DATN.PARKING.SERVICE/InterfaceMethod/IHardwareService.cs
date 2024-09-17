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
        void ServoInit(string portName, int baudRate);


        void QrScanInit(string portName, int baud, ref SerialPort _serIn, ref SerialPort _serOut, SerialDataReceivedEventHandler dataReceivedCallback);
        void QrScanGateIn(SerialPort _serIn);
        void ReadSerialOut(SerialPort _serOut);
        void ReadSerialIn(SerialPort _serIn);
    }
}
