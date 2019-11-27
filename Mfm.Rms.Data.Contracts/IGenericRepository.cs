using System.Threading.Tasks;

namespace Mfm.Rms.Data.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task Create(T entity);
    }
}
