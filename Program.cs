using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;
using System.IO;
using RestSharp;
using SuitDriver.Callers;

namespace SuitDriver
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            //DriversRequestCaller caller = new DriversRequestCaller("http://localhost:8088");
            /*List<Workbench> machine = caller.GetWorkbenchs();
            Workbench stam = caller.GetWorkbench("ABRM-RESCR");*/
            //
            //List<DriverRequest> requests = caller.GetRequestsByAccession("dekel_c", "11531");
            //DateTime dt = new DateTime ();
            //caller.ResultTest("dekel_c", "11531", "stam", "sababa", DateTime.Now);
            //NetworkLine line = new NetworkLine("127.0.0.1",3001);
            /*string read = "";
            while (read != "A")
                read = line.ReadUpTo('A');*/


            /*char t = '\0';
            while (t != 'A')
                t = line.ReadByte();*/


            /* string read = "";
             while (read != "A")
             {
                 read = line.ReadByLength(20);
                 Console.Write(read);
             }*/

            //line.Send("stam netStream netStreamnetStream");
            LogicDevice device = new LogicDevice("127.0.0.1", 3001);

            while (true)
                device.ReadMessage();
        }

    }


        
}
