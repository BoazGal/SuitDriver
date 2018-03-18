using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace SuitDriver.Callers
{
    class DriversRequestCaller
    {
        private RestClient client;
        public DriversRequestCaller(string baseUrl)
        {
            client = new RestClient(baseUrl);
        }

        public List<DriverRequest> GetRequests(string machine)
        {
            var request = new RestRequest("driver-requests", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("X-Laas-Machine", machine);
            request.AddHeader("Accept", "application/json");

            request.AddParameter("orderBy", "TRAY_AND_TIME");
            request.AddParameter("status", "FROM_SERVER");

            IRestResponse<DrRequestRoot> response2 = client.Execute<DrRequestRoot>(request);
            List<DriverRequest> driverRequests = response2.Data.drRequest;
            return driverRequests;
            
        }

        public List<DriverRequest> GetRequestsByAccession(string machine, string accession, int withDemog = 0)
        {
            var request = new RestRequest("driver-requests/{id}/action/host-query", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("X-Laas-Machine", machine);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddUrlSegment("id", accession); // replaces matching token in request.Resource
            request.AddQueryParameter("withDemog", withDemog.ToString ());



            IRestResponse<DrRequestRoot> response2 = client.Execute<DrRequestRoot>(request);
            List<DriverRequest> driverRequests = response2.Data.drRequest;
            return driverRequests;

        }
        
        public bool ResultTest (string machine, string accession, string test, string value,
                                DateTime dt  , string logicalMachine = "",
                                string interpretation = "" , string linkTest = "")
        {
            var request = new RestRequest("driver-results", Method.POST);

            DriverResult result = new DriverResult();
            result.accession = accession;
            result.tests = new List<Test> ();


            Test testResult = new Test();
            testResult.alias = test;
            testResult.result = value;

            testResult.resultDate = new ResultDate();
            testResult.resultDate.formattedDate = dt.ToString("d");

            testResult.resultDate.formattedTime = dt.ToString("HH:mm"); ;
            testResult.interpretation = interpretation;
            testResult.linkedTest = linkTest;
            testResult.performingMachine = logicalMachine;
            result.tests.Add(testResult);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("X-Laas-Machine", machine);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(result);
            


            IRestResponse<DriverResultRoot> response2 = client.Execute<DriverResultRoot>(request);
            

            return true;

        }
    }


}

