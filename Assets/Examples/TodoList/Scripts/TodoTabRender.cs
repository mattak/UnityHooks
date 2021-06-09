using UnityEngine;
using UnityEngine.UI;

namespace Examples.TodoList.Scripts
{
    public class TodoTabRender : MonoBehaviour
    {
        [SerializeField] private Image _backgroundImage = default;
        [SerializeField] private Text _text = default;

        public void Render(bool isOn)
        {
            var black = new Color(241f/255f, 241f/255f, 241f/255f);
            var white = new Color(53f/ 255f, 73f/ 255f, 93f/ 255f);

            _backgroundImage.color = isOn ? black : white;
            _text.color = isOn ? white : black;
        }
    }
}