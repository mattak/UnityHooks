using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using UnityHooks.Input;

namespace Examples.DragDrop.Scripts
{
    public class DragBinder : MonoBehaviour
    {
        [SerializeField] private DragInput[] _dragInputs = default;
        [SerializeField] private DragIconSpawner _spawner = default;

        private void Start()
        {
            Assert.IsTrue(_dragInputs.Length == 3, "dragInputs should be 2");

            for (var i = 0; i < _dragInputs.Length; i++)
            {
                var dragInput = _dragInputs[i];

                dragInput.beginDragAsObservable.Subscribe(_spawner.Spawn).AddTo(this);
                dragInput.dragAsObservable.Subscribe(_spawner.Move).AddTo(this);
                dragInput.endDragAsObservable.Subscribe(_spawner.Destroy).AddTo(this);
            }
        }
    }
}