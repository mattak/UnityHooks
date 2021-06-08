using UniRx;
using UnityHooks;

namespace Examples.MemoryPuzzle.Scripts
{
    public static class HookKeys
    {
        public static readonly HookKey<Card[]> StageCard = new HookKey<Card[]>("stage_card", new Card[] { });
        public static readonly HookKey<int> NgCount = new HookKey<int>("ng_count", 0);
        public static readonly HookKey<bool> Reset = new HookKey<bool>("reset", false);
    }
}