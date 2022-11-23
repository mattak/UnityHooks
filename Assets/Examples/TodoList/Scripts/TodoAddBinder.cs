using System;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityHooks;
using UnityHooks.Input;

namespace Examples.TodoList.Scripts
{
    public class TodoAddBinder : MonoBehaviour
    {
        [SerializeField] private ButtonInput _addButtonInput = default;
        [SerializeField] private InputFieldInput _bodyInput = default;

        private void Start()
        {
            var editMessage = Hooks.UseState(HookKeys.EditMessage);

            _bodyInput.textAsObservable.Subscribe(editMessage).AddTo(this);

            _addButtonInput.clickAsObservable
                .Select(_ => editMessage.Value)
                .Subscribe(AddTodo)
                .AddTo(this);
        }

        private void AddTodo(string message)
        {
            var hook = Hooks.UseState(HookKeys.Todos);
            var todo = new Todo(message);
            var todos = hook.Value.ToList();
            todos.Add(todo);
            hook.Value = todos.ToArray();
        }
    }
}