using System.Threading.Tasks;

namespace WShopping.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
