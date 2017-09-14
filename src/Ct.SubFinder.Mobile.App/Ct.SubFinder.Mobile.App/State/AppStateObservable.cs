using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.SubFinder.Mobile.App.Core
{
    public class AppStateObservable : IObservable<AppState>
    {        
       
        private readonly List<IObserver<AppState>> _observers;

        public readonly AppState State;
       
        public AppStateObservable()
        {
            State = new AppState();
            _observers = new List<IObserver<AppState>>();
        }

        public IDisposable Subscribe(IObserver<AppState> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return new Unsubscriber(_observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<AppState>> _observers;
            private IObserver<AppState> _observer;

            public Unsubscriber(List<IObserver<AppState>> observers, IObserver<AppState> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public void ChangeState<T>(T newStateObject, Action<AppStateObservable, T> reducer)
        {
            reducer.Invoke(this, newStateObject);
            foreach (var observer in _observers)
            {
                observer.OnNext(State);
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in _observers.ToArray())
            {
                if (_observers.Contains(observer))
                {
                    observer.OnCompleted();
                }
            }

            _observers.Clear();
        }
    }
}