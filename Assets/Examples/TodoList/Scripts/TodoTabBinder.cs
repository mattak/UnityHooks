using UniRx;
using UnityEngine;
using UnityHooks;
using UnityHooks.Input;

namespace Examples.TodoList.Scripts
{
    public class TodoTabBinder : MonoBehaviour
    {
        [SerializeField] private PointerDownInput _tabInput = default;
        [SerializeField] private TodoTabRender _tabRender = default;
        [SerializeField] private TodoFilter _filter = default;

        private void Start()
        {
            var hook = Hooks.UseState(HookKeys.Filter);
            _tabInput.pointerDownAsObservable
                .Select(_ => _filter)
                .Subscribe(hook.Update)
                .AddTo(this);
            hook.Value
                .Select(x => _filter == x)
                .Subscribe(_tabRender.Render)
                .AddTo(this);
        }
    }
}