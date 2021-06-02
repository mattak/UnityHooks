using System.Collections.Generic;

namespace UnityHooks
{
    public static class Hooks
    {
        private static readonly IDictionary<string, object> _state = new Dictionary<string, object>();

        public static Hook<TValue> UseState<TValue>(string key, TValue defaultValue)
        {
            if (!_state.ContainsKey(key))
            {
                var value = new Hook<TValue>(defaultValue);
                _state[key] = value;
                return value;
            }

            return _state[key] as Hook<TValue>;
        }
    }
}