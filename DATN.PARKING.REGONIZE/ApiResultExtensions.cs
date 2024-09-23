using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DATN.PARKING.AI
{
    public static class ApiResultExtensions
    {
        public static HttpResponseMessage FaileResult<T>(this ApiController controller,
                                                      Error error)
        {
            BaseResponse<T> response = new BaseResponse<T>(default);
            response.UpdateMessageError(error);
            return controller.Request.CreateResponse(HttpStatusCode.OK, response);
        }

        public static HttpResponseMessage FaileResult<T>(this ApiController controller,
                                                      List<Error> errors)
        {
            BaseResponse<T> response = new BaseResponse<T>(default);
            response.UpdateMessageError(errors);
            return controller.Request.CreateResponse(HttpStatusCode.OK, response);
        }

        public static HttpResponseMessage FaileResult<T>(this ApiController controller,
                                                     string errorCode,
                                                     string errorMessage)
        {
            BaseResponse<T> response = new BaseResponse<T>(default);
            response.UpdateMessageError(errorCode, errorMessage);
            return controller.Request.CreateResponse(HttpStatusCode.OK, response);
        }

        public static HttpResponseMessage OkResult<T>(this ApiController controller,
                                                      T result)
        {
            BaseResponse<T> response = new BaseResponse<T>(result);
            return controller.Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
