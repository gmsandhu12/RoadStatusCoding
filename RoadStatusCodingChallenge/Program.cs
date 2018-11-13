using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;


namespace RoadStatusCodingChallenge
{
    public class RoadProgram
    {
        public static int Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback +=
            (message, cert, chain, errors) => true;
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;


            GetRoadStatus getRoadStatus = new GetRoadStatus();
            if (args.Length == 0)
            {
                Console.WriteLine("No road name entered");
                return 1;
            }
            else
            {
                RoadStatus road = getRoadStatus.Start(args[0]);

                if (road.exitCode <= 0)
                {
                    Console.WriteLine("The status of the " + road.displayName + " is as follows");
                    Console.WriteLine("Road Status is " + road.statusSeverity);
                    Console.WriteLine("Road Status Description is " + road.statusSeverityDescription);
                }
                else
                {
                    Console.WriteLine(road.displayName + " is not a valid road");
                }
                return road.exitCode;
            }
        }

        
    }
}
