using UnityEngine;
using UnityHooks;

namespace Examples.SceneChange.Scripts
{
    public class PageRenderer : MonoBehaviour
    {
        public void Push(Page page)
        {
            var hook = Hooks.UseState(HookKeys.PAGE);
            hook.Current.Push(page);
            hook.Update(hook.Current);
        }

        public void Pop(Page page)
        {
            var hook = Hooks.UseState(HookKeys.PAGE);
            hook.Current.Pop();
            hook.Update(hook.Current);
        }

        public void Replace(Page page)
        {
            var hook = Hooks.UseState(HookKeys.PAGE);
            if (hook.Current.Count > 0) hook.Current.Pop();
            hook.Current.Push(page);
            hook.Update(hook.Current);
        }
    }
}