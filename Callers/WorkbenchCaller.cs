using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace SuitDriver.Callers
{
    class WorkbenchCaller
    {
        private RestClient client;
        public WorkbenchCaller(string baseUrl)
        {
            client = new RestClient(baseUrl);
        }

        public List<Workbench> GetWorkbenchs()
        {

            var request = new RestRequest("workbench", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("X-Laas-Machine", "Dekel");
            request.AddHeader("Accept", "application/json");

            IRestResponse<WorkbenchRoot> response = client.Execute<WorkbenchRoot>(request);
            
            return response.Data.workbench;
        }

        public Workbench GetWorkbench(string name)
        {
            string url = "workbench/" + name;
            var request = new RestRequest(url, Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("X-Laas-Machine", "Dekel");
            request.AddHeader("Accept", "application/json");

            IRestResponse<Workbench> response = client.Execute<Workbench>(request);

            return response.Data;
        }
        /*
        public void Update(int id, Product product)
        {
            var request = new RestRequest("Products/" + id, Method.PUT);
            request.AddJsonBody(product);
            client.Execute(request);
        }

        public void Delete(int id)
        {
            var request = new RestRequest("Products/" + id, Method.DELETE);
            client.Execute(request);
        }*/
    }
}
