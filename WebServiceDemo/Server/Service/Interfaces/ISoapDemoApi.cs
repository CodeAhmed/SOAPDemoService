using SOAPDemoService;
using System.Threading.Tasks;

namespace WebServiceDemo.Server.Service.Interfaces
{
    public interface ISoapDemoApi
    {
        Task<Address> GetCityDetails(string zipCode);
    }
}
