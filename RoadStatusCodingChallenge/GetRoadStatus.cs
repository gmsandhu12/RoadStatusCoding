using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace RoadStatusCodingChallenge
{
    public class GetRoadStatus
    {
        public static HttpClient client = new HttpClient(); 

        public RoadStatus Start(string roadName)
        {
            RoadStatus resultRoad = new RoadStatus();
                string address = "https://api.tfl.gov.uk/Road/";
                var APIKey = ConfigurationManager.AppSettings["APIKey"];
                var AppId = ConfigurationManager.AppSettings["ApplicationId"];

                string requestparam = roadName + "?app_id=" + AppId + "&app_key=" + APIKey;

                Task.Run(async () =>
                {
                    var response = await client.GetAsync(new Uri(address + requestparam));

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
    }
}
