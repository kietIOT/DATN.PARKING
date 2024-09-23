using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.AI
{
    public interface IBaseResponse : IDisposable
    {
        /// <summary>
        ///     Update Message Error
        /// </summary>
        /// <param name="error"></param>
        void UpdateMessageError(Error error);
    }
}
