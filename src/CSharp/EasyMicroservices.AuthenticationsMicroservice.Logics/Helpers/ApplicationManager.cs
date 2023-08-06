using EasyMicroservices.AuthenticationsMicroservice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.Helpers
{
    public class ApplicationManager
    {
        public static ApplicationManager Instance { get; private set; } = new ApplicationManager();
        public IDependencyManager DependencyManager { get; set; }

    }
}
