using System;
using UniRx;

namespace UnityHooks
{
    public class Hook<TValue>
    {
        public Action<TValue> Update { get; }
        public IObservable<TValue> Value => _value;
        public TValue Current => _value.Value;

        private ReactiveProperty<TValue> _value;

        public Hook(TValue defaultValue)
        {
            _value = new ReactiveProperty<TValue>(defaultValue);
            Update = value => _value.SetValueAndForceNotify(value);
        }
    }
}