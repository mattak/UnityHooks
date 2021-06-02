using UnityEngine;
using UnityEngine.UI;

namespace Examples.DragDrop.Scripts
{
    public class DragIcon : MonoBehaviour
    {
        [SerializeField] private Text _text = default;

        public string Name
        {
            get => _text.text;
            set => _text.text = value;
        }
    }
}