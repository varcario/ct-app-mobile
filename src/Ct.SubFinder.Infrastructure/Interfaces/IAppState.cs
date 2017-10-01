using System;

namespace Ct.SubFinder.Infrastructure.Interfaces
{
    public interface IAppState<STATE, TOPIC> : IObservable<TOPIC>
    {
        STATE State { get; }  
        void NotifySubscribers(TOPIC topic);
    }
}
