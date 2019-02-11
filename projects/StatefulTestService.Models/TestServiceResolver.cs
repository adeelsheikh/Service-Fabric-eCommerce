using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using System;

namespace StatefulTestService.Models
{
    public static class TestServiceResolver
    {
        public static ITestService Resolve()
        {
            return ServiceProxy.Create<ITestService>(
                new Uri("fabric:/ECommerce/StatefulTestService"),
                new ServicePartitionKey(0));
        }
    }
}
