using UnityEngine;
using UnityEngine.UI;

namespace Examples.TodoList.Scripts
{
    public class TodoCellView : MonoBehaviour
    {
        [SerializeField] private Text _body = default;
        [SerializeField] private Toggle _toggle = default;
        [SerializeField] private Image _deleteLine = default;

        public void Render(Todo todo)
        {
            _body.text = todo.message;
            _toggle.isOn = todo.isDone;
            _deleteLine.enabled = todo.isDone;
        }
    }
}