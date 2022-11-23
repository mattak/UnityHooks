using UniRx;
using UnityEngine;
using UnityHooks;
using UnityHooks.Input;

namespace Examples.TodoList.Scripts
{
    public class TodoCellBinder : MonoBehaviour
    {
        [SerializeField] private ToggleInput _toggleInput = default;
        private CompositeDisposable _disposables = default;

        public void Bind(Todo todo)
        {
            Clear();
            _disposables = new CompositeDisposable();
            
            var hook = Hooks.UseState(HookKeys.Todos);
            _toggleInput.isOnAsObservable
                .Subscribe(isOn => UpdateTodo(hook, todo, isOn))
                .AddTo(_disposables);
        }

        private void OnDisable() => Clear();

        private void Clear()
        {
            if (_disposables != null)
            {
                _disposables.Clear();
                _disposables = null;
            }
        }

        private void UpdateTodo(Hook<Todo[]> hook, Todo todo, bool isDone)
        {
            var todos = hook.Value;

            for (var i = 0; i < todos.Length; i++)
            {
                if (todos[i].guid == todo.guid)
                {
                    todos[i].isDone = isDone;
                    break;
                }
            }

            hook.Value = todos;
        }
    }
}