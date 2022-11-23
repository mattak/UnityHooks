using UnityEngine;

namespace UnityHooks.PluginPage.Binder
{
    public class PageInitBinder : MonoBehaviour
    {
        [SerializeField] private Page page = default;

        private void Start()
        {
            var hook = Hooks.UseState(PageHookKeys.PAGE_STACK);
            var stack = hook.Value;
            if (stack.Count > 0) return;
            hook.Update(x => x.Push(page));
        }
    }
}