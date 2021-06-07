using System.Collections.Generic;
using UnityHooks;

namespace Examples.SceneChange.Scripts
{
    public static class HookKeys
    {
        public static readonly HookKey<string[]> SCENE = new HookKey<string[]>("scene", new[] {"Base", "Multi1"});

        public static readonly HookKey<Stack<Page>> PAGE = new HookKey<Stack<Page>>("page", new Stack<Page>());
    }
}