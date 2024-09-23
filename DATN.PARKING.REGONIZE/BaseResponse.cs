using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.AI
{

        public class BaseResponse<T> : Error, IBaseResponse
        {
            #region Properties

            /// <summary>
            ///     Data information type generic template
            /// </summary>
            public T Data { get; private set; }

            /// <summary>
            ///     Flag error
            /// </summary>
            public bool IsSuccess { get; private set; }

            #endregion

            #region C'tor

            /// <summary>
            ///     C'tor TResponse(T data)
            /// </summary>
            /// <param name="data"></param>
            public BaseResponse(T data) : base(string.Empty, string.Empty)
            {
                Data = data;
                IsSuccess = true;
            }

            /// <summary>
            ///     C'tor TResponse(T data, bool isError, string message, string errorCode)
            /// </summary>
            /// <param name="data"></param>
            /// <param name="isError"></param>
            /// <param name="message"></param>
            /// <param name="errorCode"></param>
            public BaseResponse(T data,
                                bool isSuccess,
                                string message,
                                string errorCode) : base(errorCode, message)
            {
                Data = data;
                IsSuccess = isSuccess;
            }

            #endregion

            #region public methods

            /// <summary>
            ///     Update Message Error
            /// </summary>
            /// <param name="error"></param>
            public void UpdateMessageError(Error error)
            {
                IsSuccess = false;
                Update(error);
            }

            public void UpdateMessageError(string errorCode, string errorMessage)
            {
                IsSuccess = false;
                Update(new Error(errorCode, errorMessage));
            }

            public void UpdateMessageError(List<Error> errors)
            {
                IsSuccess = false;
                Update(errors);
            }

            /// <summary>
            ///     Update data
            /// </summary>
            /// <param name="data"></param>
            public void UpdateData(T data)
            {
                Data = data;
            }

            #endregion

            #region IDispose pattern

            private bool _disposed;

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (_disposed)
                    return;

                if (disposing)
                {
                    // Free any other managed objects here.
                    Data = default(T);
                    IsSuccess = !default(bool);
                }

                _disposed = true;
            }

            #endregion
        }
    }

