using Prototype.DomainMVC.ViewModel;
using System.Threading.Tasks;

namespace Prototype.ServiceMVC.Interfaces
{
    public interface IInternalApiService
    {
        Task<ClimateTimeWeather> Index();
        Task<ClimateTimeWeather> Tips();
        Task<ClimateTimeWeather> Gallery();
    }
}
