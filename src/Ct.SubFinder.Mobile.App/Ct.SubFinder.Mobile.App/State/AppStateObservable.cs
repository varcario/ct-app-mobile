using Ct.SubFinder.Infrastructure.Interfaces;
using Ct.SubFinder.Mobile.App.State;
using System;
using System.Collections.Generic;

namespace Ct.SubFinder.Mobile.App.Core
{
    public class AppStateObservable : IAppState<AppState, AppStateEvent>
    {       
        private readonly List<IObserver<AppStateEvent>> _observers;

        public AppState State { get; private set; }
       
        public AppStateObservable(AppState state)
        {
            State = state ?? throw new ArgumentNullException("state");
            _observers = new List<IObserver<AppStateEvent>>();
        }  

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<AppStateEvent>> _observers;
            private IObserver<AppStateEvent> _observer;

            public Unsubscriber(List<IObserver<AppStateEvent>> observers, IObserver<AppStateEvent> observer)
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

        public void NotifySubscribers(AppStateEvent topic)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(topic);
            }
        }

        public IDisposable Subscribe(IObserver<AppStateEvent> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return new Unsubscriber(_observers, observer);
        }
    }
}