using UniRx;
using UnityEngine;
using UnityHooks;
using UnityHooks.Renderer;

namespace Examples.MemoryPuzzle.Scripts
{
    [RequireComponent(typeof(TextRenderer))]
    public class NgCountBinder : MonoBehaviour
    {
        private void Start()
        {
            var hook = Hooks.UseState(HookKeys.NgCount);
            hook.Select(x => $"x {x}")
                .Subscribe(GetComponent<TextRenderer>().Render)
                .AddTo(this);
        }
    }
}