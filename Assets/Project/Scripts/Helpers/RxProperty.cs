using System;
using System.Collections.Generic;

namespace RedPanda.Project.Helpers
{
    /// <summary> Simple implementation on reactive property. </summary>
    public class RxProperty<T>
    {
        private T _value;
        private List<Action<T>> _subscriptions = new();

        public T Value => _value;
        
        public RxProperty(T value)
        {
            _value = value;
        }

        public void SetValue(T value)
        {
            _value = value;
            foreach (var subscription in _subscriptions)
            {
                subscription.Invoke(value);
            }
        }
        
        public void Subscribe(Action<T> onNext)
        {
            _subscriptions.Add(onNext);
        }
    }
}