using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using UnityHooks;
using UnityHooks.Renderer;

namespace Examples.DragDrop.Scripts
{
    public class DropTextBinder : MonoBehaviour
    {
        [SerializeField] private TextRenderer[] _dropTexts = default;

        private void Start()
        {
            Assert.IsTrue(_dropTexts.Length == 2, "dropTexts should be 2");

            var names = _dropTexts.Select(it => it.name).ToArray();
            var hook = Hooks.UseState("selected_names", names);

            hook.Subscribe(Render)
                .AddTo(this);
        }

        private void Render(string[] dropNames)
        {
            _dropTexts[0].Render(dropNames[0]);
            _dropTexts[1].Render(dropNames[1]);
        }
    }
}