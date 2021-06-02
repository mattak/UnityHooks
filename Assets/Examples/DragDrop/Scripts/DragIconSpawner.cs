using UnityEngine;
using UnityEngine.EventSystems;
using UnityHooks.Renderer;

namespace Examples.DragDrop.Scripts
{
    public class DragIconSpawner : MonoBehaviour
    {
        [SerializeField] private DragIcon _prefab = default;

        private DragIcon _dragging = default;

        public void Spawn(PointerEventData eventData)
        {
            var icon = eventData.pointerDrag.GetComponent<DragIcon>();
            _dragging = Instantiate(_prefab, transform, true);
            _dragging.Name = icon.Name;

            var raycastBlockRenderer = _dragging.GetComponent<CanvasRaycastBlockRenderer>();
            raycastBlockRenderer.Render(false);
        }

        public void Move(PointerEventData eventData)
        {
            _dragging.transform.position = eventData.position;
        }

        public void Destroy(PointerEventData eventData)
        {
            if (_dragging != default)
            {
                Destroy(_dragging.gameObject);
                _dragging = null;
            }
        }
    }
}