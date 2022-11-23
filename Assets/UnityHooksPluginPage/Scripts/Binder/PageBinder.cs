using UniRx;
using UnityEngine;

namespace UnityHooks.PluginPage.Binder
{
    public class PageBinder : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void OnBeforeSceneLoadRuntimeMethod()
        {
            var obj = new GameObject("PageBinder");
            obj.AddComponent<PageBinder>();
            DontDestroyOnLoad(obj);
        }

        private void Start()
        {
            var hook = Hooks.UseState(PageHookKeys.PAGE_STACK);
            hook.Where(x => x.Count > 0)
                .Select(x => x.Peek())
                .Subscribe(this.Render)
                .AddTo(this);
        }

        private void Render(Page page)
        {
            var hook = Hooks.UseState(PageHookKeys.SCENES);
            hook.Value = page.scenes;
        }
    }
}