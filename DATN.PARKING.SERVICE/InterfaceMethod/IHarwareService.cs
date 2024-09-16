using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.SERVICE.InterfaceMethod
{
    internal interface IHarwareService
    {
        void Servo(string gate,string status);

    }
}
