using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using UnityHooks;
using UnityHooks.Input;

namespace Examples.SceneChange.Scripts
{
    public class SceneChangeButtonBinder : MonoBehaviour
    {
        [SerializeField] private ButtonInput _buttonInput = default;
        [SerializeField] private string[] _loadScenes = default;

        private void Start()
        {
            Assert.IsTrue(_loadScenes != default, $"_loadScenes is default. please attach on {gameObject.name}");
            var hook = Hooks.UseState(HookKeys.SCENE);
            _buttonInput.clickAsObservable.Select(_ => _loadScenes).Subscribe(hook).AddTo(this);
        }
    }
}