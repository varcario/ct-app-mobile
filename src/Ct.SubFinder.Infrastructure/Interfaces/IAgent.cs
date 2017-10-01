
namespace Ct.App.Infrastructure.Interfaces
{
    public interface IAgent<STATE>
    {
        STATE SendRequest(STATE state);
    }
}
