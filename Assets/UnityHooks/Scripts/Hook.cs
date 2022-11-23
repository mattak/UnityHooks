using System;
using UniRx;

namespace UnityHooks
{
    public class Hook<TValue> : IObservable<TValue>, IObserver<TValue>
    {
        // public Action<TValue> Update { get; }
        // public IObservable<TValue> Value => _value;
        // public TValue Current => _value.Value;

        public TValue Value
        {
            get => _value.Value;
            set => _value.SetValueAndForceNotify(value);
        }

        private ReactiveProperty<TValue> _value;

        public Hook(TValue defaultValue)
        {
            _value = new ReactiveProperty<TValue>(defaultValue);
            // Update = value => _value.SetValueAndForceNotify(value);
        }

        public IDisposable Subscribe(IObserver<TValue> observer)
        {
            return this._value.Subscribe(observer);
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(TValue value)
        {
            _value.Value = value;
        }

        public void Update(Action<TValue> action)
        {
            action(_value.Value);
            _value.SetValueAndForceNotify(_value.Value);
        }

        public void ForceUpdate()
        {
            _value.SetValueAndForceNotify(_value.Value);
        }
    }
}