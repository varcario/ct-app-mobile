
namespace Ct.App.Infrastructure.Interfaces
{ 
    public interface IServiceAdapter<STATE, BUSINESS_LOGIC, RESPONSE>
    {

        RESPONSE InvokeServiceAdapter(params object[] input);
    }
}
