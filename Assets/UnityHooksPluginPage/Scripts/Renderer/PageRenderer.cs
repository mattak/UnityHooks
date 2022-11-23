using UnityEngine;

namespace UnityHooks.PluginPage.Renderer
{
    public class PageRenderer : MonoBehaviour
    {
        public void Push(Page page)
        {
            var hook = Hooks.UseState(PageHookKeys.PAGE_STACK);
            hook.Update(x => x.Push(page));
        }

        public void Pop()
        {
            var hook = Hooks.UseState(PageHookKeys.PAGE_STACK);
            if (hook.Value.Count > 1)
            {
                hook.Update(x => x.Pop());
            }
            else
            {
                Debug.LogWarning("Cannot pop page. It's root page");
            }
        }

        public void Replace(Page page)
        {
            var hook = Hooks.UseState(PageHookKeys.PAGE_STACK);
            if (hook.Value.Count > 0) hook.Value.Pop();
            hook.Update(x => x.Push(page));
        }
    }
}