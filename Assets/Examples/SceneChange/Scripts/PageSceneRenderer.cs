using UnityEngine;
using UnityHooks;

namespace Examples.SceneChange.Scripts
{
    public class PageSceneRenderer : MonoBehaviour
    {
        public void Render(Page page)
        {
            var hook = Hooks.UseState(HookKeys.SCENE);
            hook.Update(page.SceneNames);
        }
    }
}