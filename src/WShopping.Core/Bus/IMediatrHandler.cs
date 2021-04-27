using System.Threading.Tasks;
using WShopping.Core.Messages;

namespace WShopping.Core.Bus
{
    public interface IMediatrHandler 
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T comando) where T : Command;
    }

}
