using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net;
using System.IO;
using System.Text.Json.Serialization;

namespace CheckMate.Common
{
    public class HttpHandler
    {

        static readonly HttpClient client = new HttpClient();
        //static string url = "https://192.168.1.140:5001";
        public string url { get; set; } = "http://checkmate.daughertyduo.com";

        //tail ex. "/api/person/{id}
        public  async Task<string> Get(string tail = "")
        {
            string respString = string.Empty;

            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(url + tail);
            hwr.Method = HttpMethod.Get.ToString();

            using (HttpWebResponse response = (HttpWebResponse)hwr.GetResponse())
            {
                if(response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Error Code: " + response.StatusCode.ToString());
                }

                using(Stream responseStream = response.GetResponseStream())
                {
                    if(responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            respString = reader.ReadToEnd();
                        }
                    }
                }
            }
            return respString;
        }
        

public async Task<string> Post(Object obj, string tail = "")
        {

            try
            {
                string responseBody = await client.GetStringAsync(url + tail);
                return responseBody;
                
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return "Exception: " + e.Message.ToString(); 
            }
        }
    }
}
