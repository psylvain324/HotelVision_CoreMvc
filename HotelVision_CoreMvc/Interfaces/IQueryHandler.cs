using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelVision_CoreMvc.Services.Interfaces
{
    public interface IQueryHandler<T> where T : class
    {
        IEnumerable<T> Handle(T query);
        Task<IEnumerable<T>> HandleAsync(T query);
    }
}
