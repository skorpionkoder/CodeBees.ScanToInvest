using System.Text;
using CodeBees.ScanToInvest.Vision.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeBees.ScanToInvest.Vision.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisionController : ControllerBase
    {
        static string basicAuthValue = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX2lkIjoiOTdmYmZkNWMtYTQ5OC00NTMxLWE3NzMtYTJhNDE1MDY4NzEzIiwidHlwZSI6ImFwaV90b2tlbiJ9.qpTz37oAJer7P35oY1cxRCuErJXr9o8LZZCc0xb6E7c";
        static string endpoint = "https://api.edenai.run/v2/image/logo_detection";

        static HttpClient client = new HttpClient();

        // GET api/<VisionController>/"https://docs.imagga.com/static/images/docs/sample/japan-605234_1280.jpg"
        [HttpPost("{path}")]
        public async Task<string> GetVisionObjectAsync(string path)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", basicAuthValue));

            var values = new Dictionary<string, string>
            {
                { "providers", "google" },
                { "response_as_dict", "true" },
                { "attributes_as_list", "false" },
                { "show_original_response", "false" },
                { "file_url", Uri.UnescapeDataString(path) }
            };

            VisionResponse ? result = null;
            HttpResponseMessage response = await client.PostAsync(endpoint, new StringContent(JsonConvert.SerializeObject(values),
                     Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<VisionResponse>();
            }
            else return response.StatusCode.ToString();

            return result != null && result.Google.Items.Any() ? result.Google.Items[0].Description : "Vision not found.";
        }

    }
}
