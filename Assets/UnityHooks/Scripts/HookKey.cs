namespace UnityHooks
{
    public class HookKey<TValue>
    {
        public string Key { get; }
        public TValue DefaultValue { get; }

        public HookKey(string key, TValue defaultValue)
        {
            this.Key = key;
            this.DefaultValue = defaultValue;
        }
    }
}