using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.SERVICE.InterfaceMethod
{
    public interface IHardwareService
    {
        void Servo(string gate);
        void HardwareServiceInit(string portName, int baudRate);
    }
}
