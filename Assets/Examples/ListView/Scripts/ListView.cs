using System.Collections.Generic;
using UnityEngine;

namespace Examples.ListView.Scripts
{
    public class ListView : MonoBehaviour
    {
        [SerializeField] private CellView _cellViewPrefab;

        public void Render(List<Cell> cells)
        {
            Clean();
            Spawn(cells);
        }

        private void Spawn(List<Cell> cells)
        {
            for (var i = 0; i < cells.Count; i++)
            {
                var cell = Instantiate(_cellViewPrefab, transform, false);
                cell.Render(cells[i]);
            }
        }

        private void Clean()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}