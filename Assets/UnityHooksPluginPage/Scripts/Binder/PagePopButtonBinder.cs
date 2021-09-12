using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityHooks.PluginPage.Renderer;

namespace UnityHooks.PluginPage.Binder
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(PageRenderer))]
    public class PagePopButtonBinder : MonoBehaviour
    {
        private void Start()
        {
            Bind().Forget();
        }

        private async UniTask Bind()
        {
            await GetComponent<Button>().OnClickAsync();
            GetComponent<PageRenderer>().Pop();
        }
    }
}