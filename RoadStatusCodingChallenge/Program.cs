using System;

namespace RoadStatusCodingChallenge
{
    public class RoadProgram
    {
        public GetRoadStatus getRoadStatus = new GetRoadStatus();

        public static int Main(string[] args)
        {         
            
            if (args.Length == 0)
            {
                Console.WriteLine("No road name entered");
                return 1;
            }
            else
            {
                RoadProgram prg = new RoadProgram();
                return prg.RoadStatusResult(args[0]);
            }
        }

        public int RoadStatusResult(string roadName)
        {           
            RoadStatus road = getRoadStatus.Start(roadName);

            if (road.exitCode == 0)
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
