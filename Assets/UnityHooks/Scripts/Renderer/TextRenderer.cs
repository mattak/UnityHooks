using UnityEngine;
using UnityEngine.UI;

namespace UnityHooks.Renderer
{
    [RequireComponent(typeof(Text))]
    public class TextRenderer : MonoBehaviour
    {
        public void Render(string text) => GetComponent<Text>().text = text;
    }
}