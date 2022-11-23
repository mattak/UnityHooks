using UniRx;
using UnityEngine;
using UnityHooks;

namespace Examples.SceneChange.Scripts
{
    public class SceneBinder : MonoBehaviour
    {
        [SerializeField] private SceneRenderer _sceneRenderer = default;

        private void Start()
        {
            var hook = Hooks.UseState(HookKeys.SCENE);
            hook.Subscribe(_sceneRenderer.Render).AddTo(this);
        }
    }
}