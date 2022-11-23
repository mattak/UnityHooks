using UnityEngine;
using UnityHooks;

namespace Examples.SceneChange.Scripts
{
    public class PageRenderer : MonoBehaviour
    {
        public void Push(Page page)
        {
            var hook = Hooks.UseState(HookKeys.PAGE);
            hook.Value.Push(page);
            hook.ForceUpdate();
        }

        public void Pop(Page page)
        {
            var hook = Hooks.UseState(HookKeys.PAGE);
            hook.Value.Pop();
            hook.ForceUpdate();
        }

        public void Replace(Page page)
        {
            var hook = Hooks.UseState(HookKeys.PAGE);
            if (hook.Value.Count > 0) hook.Value.Pop();
            hook.Value.Push(page);
            hook.ForceUpdate();
        }
    }
}