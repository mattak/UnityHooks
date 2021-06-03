using UnityEngine;
using UnityEngine.UI;

namespace Examples.ListView.Scripts
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private Text _titleText = default;

        public void Render(Cell cell)
        {
            _titleText.text = cell.Title;
        }
    }
}