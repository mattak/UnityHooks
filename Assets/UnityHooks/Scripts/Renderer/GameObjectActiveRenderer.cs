using UnityEngine;

namespace UnityHooks.Renderer
{
    public class GameObjectActiveRenderer : MonoBehaviour
    {
        public void Render(bool active)
        {
            this.gameObject.SetActive(active);
        }
    }
}