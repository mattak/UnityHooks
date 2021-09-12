using System.Collections.Generic;

namespace UnityHooks.PluginPage
{
    public static class PageHookKeys
    {
        public static HookKey<List<string>> SCENES = new HookKey<List<string>>(
            "PluginPage.Scenes",
            null
        );
        
        public static HookKey<Stack<Page>> PAGE_STACK = new HookKey<Stack<Page>>(
            "page_stack",
            new Stack<Page>()
        );
    }
}