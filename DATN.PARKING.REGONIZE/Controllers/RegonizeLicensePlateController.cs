using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
namespace DATN.PARKING.AI.Controller
{
    public class RegonizeLicensePlateController : ApiController
    {
        [Route("datn-parking-ai")]
        public async Task<HttpResponseMessage> RegonizeLicensePlate([FromBody] string value)
        {
            try
            {
                var response = value;
                return this.OkResult(response);
            }
            catch
            {
                throw;
            }
        }


        [Route("gui-bien-so-xe")]
        public async Task<HttpResponseMessage> SendLicensePlate(string value)
        {

            using (HttpClient client = new HttpClient())
            {
                // Set the base address for the API

                // Create the data to send
                var postData = new
                {
                    LicensePlate = value // Use the input value as the license plate
                };

                // Convert the data to JSON format
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(postData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    // Make the POST request
                    HttpResponseMessage response = await client.PostAsync($"https://localhost:7003/RegonizeLicensePlate/send-data?data={value}", content);

                    // Check the response
                    if (response.IsSuccessStatusCode)
                    {
                        // Optionally read and process the response if needed
                        string result = await response.Content.ReadAsStringAsync();
                        return new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent(result, Encoding.UTF8, "application/json")
                        };
                    }
                    else
                    {
                        // Handle the error response
                        return new HttpResponseMessage(response.StatusCode)
                        {
                            Content = new StringContent("Error occurred while calling the API.", Encoding.UTF8, "text/plain")
                        };
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the exception as needed
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        Content = new StringContent($"Exception: {ex.Message}", Encoding.UTF8, "text/plain")
                    };
                }
            }
        }
    }
}

