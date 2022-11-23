using UniRx;
using UnityEngine;
using UnityHooks.PluginPage.Renderer;

namespace UnityHooks.PluginPage.Binder
{
    public class SceneBinder : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void OnBeforeSceneLoadRuntimeMethod()
        {
            var obj = new GameObject("SceneBinder");
            obj.AddComponent<SceneBinder>();
            DontDestroyOnLoad(obj);
        }

        private void Start()
        {
            var hook = Hooks.UseState(PageHookKeys.SCENES);
            var sceneRenderer = new SceneRenderer();

            hook.Where(x => x != null)
                .Subscribe(sceneRenderer.Render)
                .AddTo(this);
        }
    }
}