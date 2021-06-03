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
            var hook = Hooks.UseState("scenes", new[] {"Base", "Multi1"});
            hook.Value.Subscribe(_sceneRenderer.Render).AddTo(this);
        }
    }
}