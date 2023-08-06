using EasyMicroservices.AuthenticationsMicroservice.Helpers;
using EasyMicroservices.AuthenticationsMicroservice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice
{
    public class StartUp
    {
        public Task Run(IDependencyManager dependencyManager)
        {
            ApplicationManager.Instance.DependencyManager = dependencyManager;
            return Task.CompletedTask;
        }
    }
}
