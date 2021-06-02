using UniRx;
using UnityEngine;
using UnityHooks;
using UnityHooks.Input;
using UnityHooks.Renderer;

namespace Examples.Counter.Scripts
{
    public class CountBinder : MonoBehaviour
    {
        [SerializeField] private ButtonInput _button = default;
        [SerializeField] private TextRenderer _text = default;

        private void Start()
        {
            var hook = Hooks.UseState("count", 0);

            // click
            _button.clickAsObservable
                .Select(_ => hook.Current + 1)
                .Subscribe(hook.Update)
                .AddTo(this);

            // render
            hook.Value
                .Select(x => x.ToString())
                .Subscribe(_text.Render)
                .AddTo(this);
        }
    }
}