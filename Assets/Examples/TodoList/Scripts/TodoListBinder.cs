using System.Linq;
using UniRx;
using UnityEngine;
using UnityHooks;

namespace Examples.TodoList.Scripts
{
    public class TodoListBinder : MonoBehaviour
    {
        [SerializeField] private TodoListView _todoListView = default;

        private void Start()
        {
            var todosHook = Hooks.UseState(HookKeys.Todos);
            var filterHook = Hooks.UseState(HookKeys.Filter);

            Observable.CombineLatest(todosHook, filterHook, Filter)
                .Subscribe(_todoListView.Render)
                .AddTo(this);
            todosHook.Value = new[] {new Todo("sample1", false), new Todo("sample2", true)};
        }

        private Todo[] Filter(Todo[] todos, TodoFilter filter)
        {
            return todos.ToList()
                .Where(x =>
                    filter == TodoFilter.All ||
                    filter == TodoFilter.Todo && !x.isDone ||
                    filter == TodoFilter.Done && x.isDone
                )
                .ToArray();
        }
    }
}