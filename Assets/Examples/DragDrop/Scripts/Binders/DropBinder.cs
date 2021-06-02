using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using UnityHooks;
using UnityHooks.Input;

namespace Examples.DragDrop.Scripts
{
    public class DropBinder : MonoBehaviour
    {
        [SerializeField] private DropInput[] _dropInputs = default;

        private void Start()
        {
            Assert.IsTrue(_dropInputs.Length == 2, "dropInputs should be 2");

            var hook = Hooks.UseState("selected_names", new[] {"?", "?"});

            for (var i = 0; i < _dropInputs.Length; i++)
            {
                var index = i;
                var dropInput = _dropInputs[index];

                dropInput.dropAsObservable
                    .Select(x => x.pointerDrag.GetComponent<DragIcon>().Name)
                    .Subscribe(dropName => SelectDropName(hook, index, dropName))
                    .AddTo(this);
            }
        }

        private void SelectDropName(Hook<string[]> hook, int index, string dropName)
        {
            var current = hook.Current;
            var otherIndex = (index + 1) % 2;
            if (current[otherIndex] == dropName)
            {
                // swap
                var newIndexs = new string[2];
                newIndexs[index] = current[otherIndex];
                newIndexs[otherIndex] = current[index];
                hook.Update(newIndexs);
            }
            else
            {
                current[index] = dropName;
                hook.Update(current);
            }
        }
    }
}