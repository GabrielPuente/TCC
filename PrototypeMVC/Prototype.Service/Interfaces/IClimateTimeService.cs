using Prototype.Domain.Entities;
using System.Threading.Tasks;

namespace Prototype.Service.Interfaces
{
    /// <summary>
    /// Contrato criado para a classe de servico de mesmo nome
    /// </summary>
    public interface IClimateTimeService
    {
        Task<ClimateTimeWeather> Get(string token);
    }
}
