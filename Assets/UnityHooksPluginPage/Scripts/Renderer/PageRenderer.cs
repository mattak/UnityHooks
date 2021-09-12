using UnityEngine;

namespace UnityHooks.PluginPage.Renderer
{
    public class PageRenderer : MonoBehaviour
    {
        public void Push(Page page)
        {
            var hook = Hooks.UseState(PageHookKeys.PAGE_STACK);
            hook.Current.Push(page);
            hook.Update(hook.Current);
        }

        public void Pop()
        {
            var hook = Hooks.UseState(PageHookKeys.PAGE_STACK);
            if (hook.Current.Count > 1)
            {
                hook.Current.Pop();
                hook.Update(hook.Current);
            }
            else
            {
                Debug.LogWarning("Cannot pop page. It's root page");
            }
        }

        public void Replace(Page page)
        {
            var hook = Hooks.UseState(PageHookKeys.PAGE_STACK);
            if (hook.Current.Count > 0) hook.Current.Pop();
            hook.Current.Push(page);
            hook.Update(hook.Current);
        }
    }
}