using EasyMicroservices.AuthenticationsMicroservice.VirtualServerForTests.TestResources;
using EasyMicroservices.Laboratory.Constants;
using EasyMicroservices.Laboratory.Engine;
using EasyMicroservices.Laboratory.Engine.Net.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.VirtualServerForTests
{
    public class AuthenticationVirtualTestManager
    {
        static Dictionary<int, ResourceManager> InitializedPorts = new Dictionary<int, ResourceManager>();
        public int CurrentPortNumber { get; set; }

        public async Task<bool> OnInitialize(int portNumber)
        {
            CurrentPortNumber = portNumber;
            if (InitializedPorts.ContainsKey(portNumber))
                return false;
            InitializedPorts[portNumber] = new ResourceManager();
            HttpHandler httpHandler = new HttpHandler(InitializedPorts[portNumber]);
            foreach (var item in AuthenticationResource.GetResources("TestExample"))
            {
                AppendService(portNumber, item.Key, item.Value);
            }
            await httpHandler.Start(portNumber);
            return true;
        }

        public void AppendService(int port, string request, string body)
        {
            if (InitializedPorts.TryGetValue(port, out ResourceManager resource))
                resource.Append(request, body);
            else
                throw new KeyNotFoundException(port.ToString());
        }

        public async Task<string> GetLastResponse(int port)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add(RequestTypeHeaderConstants.RequestTypeHeader, RequestTypeHeaderConstants.GiveMeLastFullRequestHeaderValue);
            var httpResponse = await httpClient.GetAsync($"http://localhost:{port}");
            return await httpResponse.Content.ReadAsStringAsync();
        }

        public async Task<T> HandleResponse<T>(int port, Func<Task<T>> task)
        {
            try
            {
                return await task();
            }
            catch (Exception ex)
            {
                try
                {
                    var response = await GetLastResponse(port);
                    throw new Exception(response, ex);
                }
                catch
                {

                }
                throw;
            }
        }
    }
}