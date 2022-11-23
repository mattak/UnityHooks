using UniRx;
using UnityEngine;
using UnityHooks;

namespace Examples.SceneChange.Scripts
{
    [RequireComponent(typeof(PageSceneRenderer))]
    public class PageSceneBinder : MonoBehaviour
    {
        private void Start()
        {
            var renderer = GetComponent<PageSceneRenderer>();
            var hook = Hooks.UseState(HookKeys.PAGE);
            hook.Where(x => x.Count > 0)
                .Select(x => x.Peek())
                .Where(it => it != null)
                .Subscribe(renderer.Render)
                .AddTo(this);
        }
    }
}