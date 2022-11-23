using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityHooks;

namespace Examples.ListView.Scripts
{
    public class ListViewBinder : MonoBehaviour
    {
        [SerializeField] private ListView _listView = default;

        private void Start()
        {
            var hook = Hooks.UseState("cells", new List<Cell>());

            BindList(hook);
            FetchCells(hook);
        }

        private void BindList(Hook<List<Cell>> hook) => hook.Subscribe(_listView.Render).AddTo(this);

        private void FetchCells(Hook<List<Cell>> hook)
        {
            var cells = new List<Cell> {new Cell("title1"), new Cell("title2")};
            hook.Value = cells;
        }
    }
}