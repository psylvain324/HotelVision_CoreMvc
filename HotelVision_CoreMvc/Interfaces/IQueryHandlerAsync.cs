using System.Threading.Tasks;

namespace HotelVision_CoreMvc.Services.Interfaces
{
    public interface IQueryHandlerAsync<TReturn> : IQueryRoot
    {
        Task<TReturn> HandleAsync();
    }
}
