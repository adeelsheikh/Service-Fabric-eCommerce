using Microsoft.ServiceFabric.Services.Remoting;
using System.Threading.Tasks;

namespace StatefulTestService.Models
{
    public interface ITestService : IService
    {
        Task<string> Test();
    }
}
