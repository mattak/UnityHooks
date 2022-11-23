using UniRx;
using UnityEngine;
using UnityHooks;
using UnityHooks.Input;
using UnityHooks.Renderer;

namespace Examples.Popup.Scripts
{
    public class PopupBackgroundSceneBinder : MonoBehaviour
    {
        [SerializeField] private ButtonInput _buttonInput = default;
        [SerializeField] private PopupBinder _popupPrefab = default;
        [SerializeField] private TextRenderer _text = default;

        private void Start()
        {
            var manager = PopupManager.Instance;
            var hook = Hooks.UseState("username", "default username");

            _buttonInput.clickAsObservable.Subscribe(_ => manager.Show(_popupPrefab)).AddTo(this);
            hook.Subscribe(this._text.Render).AddTo(this);
        }
    }
}