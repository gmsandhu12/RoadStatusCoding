using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;

namespace RoadStatusCodingChallenge
{
    public class GetRoadStatus
    {
        public static HttpClient client = new HttpClient();
        public RoadStatus resultRoad = new RoadStatus();
        public string APIKey = ConfigurationManager.AppSettings["APIKey"];
        public string AppId = ConfigurationManager.AppSettings["ApplicationId"];
        public string address = "https://api.tfl.gov.uk/Road/";
        
        public virtual RoadStatus Start(string roadName)
        {
            SecureCertificateBypass();

            Task.Run(async () =>
                {
                   var response = await client.GetAsync(new Uri(getRequestString(roadName)));

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        List<RoadStatus> myRoad = JsonConvert.DeserializeObject<List<RoadStatus>>(response.Content.ReadAsStringAsync().Result);
                        resultRoad = myRoad.First();
                        resultRoad.exitCode = 0;
                    }  
                    if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        resultRoad.displayName = roadName;
                        resultRoad.exitCode = 1;
                    }

                }).GetAwaiter().GetResult();

            return resultRoad;
        }

        public string getRequestString(string roadName)
        {
            return address + roadName + "?app_id=" + AppId + "&app_key=" + APIKey;
        }

        public virtual void SecureCertificateBypass()
        {
            ServicePointManager.ServerCertificateValidationCallback +=
           (message, cert, chain, errors) => true;
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }
    }
}
