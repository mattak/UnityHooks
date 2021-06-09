using UnityHooks;

namespace Examples.TodoList.Scripts
{
    public static class HookKeys
    {
        public static readonly HookKey<Todo[]> Todos = new HookKey<Todo[]>("todos", new Todo[0]);
        public static readonly HookKey<TodoFilter> Filter = new HookKey<TodoFilter>("todo_filter", TodoFilter.All);
        public static readonly HookKey<string> EditMessage = new HookKey<string>("edit_message", "");
    }
}