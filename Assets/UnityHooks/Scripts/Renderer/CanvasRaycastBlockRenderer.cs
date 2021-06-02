using UnityEngine;

namespace UnityHooks.Renderer
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasRaycastBlockRenderer : MonoBehaviour
    {
        public void Render(bool block) => GetComponent<CanvasGroup>().blocksRaycasts = block;
    }
}