using UniRx;
using UnityEngine;
using UnityHooks;
using UnityHooks.Input;

namespace Examples.Popup.Scripts
{
    public class PopupBinder : MonoBehaviour
    {
        [SerializeField] private InputFieldInput _inputField = default;
        [SerializeField] private ButtonInput _okButtonInput = default;

        private void Start()
        {
            var hook = Hooks.UseState("username", "default username");
            _inputField.textAsObservable.Subscribe(hook).AddTo(this);
            _okButtonInput.clickAsObservable.Subscribe(_ => PopupManager.Instance.Dismiss()).AddTo(this);
        }
    }
}