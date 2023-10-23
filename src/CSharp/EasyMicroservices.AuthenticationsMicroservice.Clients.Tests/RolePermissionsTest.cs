using EasyMicroservices.AuthenticationsMicroservice.VirtualServerForTests;
using Xunit;

namespace EasyMicroservices.AuthenticationsMicroservice.Clients.Tests
{
    public class RolePermissionsTest
    {
        const int Port = 1201;
        string _routeAddress = "";
        public static HttpClient HttpClient { get; set; } = new HttpClient();
        public RolePermissionsTest()
        {
            _routeAddress = $"http://localhost:{Port}";
        }

        static bool _isInitialized = false;
        static AuthenticationVirtualTestManager AuthenticationVirtualTestManager = new();
        static SemaphoreSlim Semaphore = new SemaphoreSlim(1);
        async Task OnInitialize()
        {
            if (_isInitialized)
                return;
            try
            {
                await Semaphore.WaitAsync();
                _isInitialized = true;
                await AuthenticationVirtualTestManager.OnInitialize(Port);
            }
            finally
            {
                Semaphore.Release();
            }
        }

        [Fact]
        public async Task GetAllPermissionsByTest()
        {
            await OnInitialize();
            var microserviceClient = new Authentications.GeneratedServices.ServicePermissionClient(_routeAddress, HttpClient);
            var permissionsResponse = await AuthenticationVirtualTestManager.HandleResponse(Port, async () =>
            {
                return await microserviceClient.GetAllPermissionsByAsync(new Authentications.GeneratedServices.ServicePermissionRequestContract()
                {
                    MicroserviceName = "TestExample",
                    RoleName = "Owner"
                });
            });

            Assert.True(permissionsResponse.IsSuccess);
            Assert.True(permissionsResponse.Result.Count > 0);
            Assert.True(permissionsResponse.Result.First().MicroserviceName == "TestExample");
            Assert.True(permissionsResponse.Result.First().ServiceName == "TestService");
            Assert.True(permissionsResponse.Result.First().MethodName == "TestMethod");
        }
    }
}
