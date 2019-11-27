using System.Threading.Tasks;

namespace HotelVision_CoreMvc.Services.Interfaces
{
    public interface ICommandHandlerAsync<TReturn>
    {
        Task<TReturn> HandleAsync();
    }
}
