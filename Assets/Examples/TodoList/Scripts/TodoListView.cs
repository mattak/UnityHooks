using UnityEngine;

namespace Examples.TodoList.Scripts
{
    public class TodoListView : MonoBehaviour
    {
        [SerializeField] private TodoCellView _prefab = default;

        public void Render(Todo[] todos)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            foreach (var todo in todos)
            {
                var child = Instantiate(_prefab, transform, false);
                RenderChild(child, todo);
            }
        }

        private void RenderChild(TodoCellView child, Todo todo)
        {
            child.Render(todo);
            child.GetComponent<TodoCellBinder>().Bind(todo);
        }
    }
}