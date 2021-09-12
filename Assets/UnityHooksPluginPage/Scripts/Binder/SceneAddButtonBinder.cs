using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace UnityHooks.PluginPage.Binder
{
    [RequireComponent(typeof(Button))]
    public class SceneAddButtonBinder : MonoBehaviour
    {
        [SerializeField] private string[] scenes = default;

        private void Start()
        {
            Assert.IsTrue(scenes != default, $"loadScenes is default. please attach on {gameObject.name}");
            var hook = Hooks.UseState(PageHookKeys.SCENES);

            this.GetComponent<Button>()
                .OnClickAsObservable()
                .Select(_ => scenes)
                .Subscribe(x =>
                {
                    var list = hook.Current;
                    list.AddRange(x);
                    hook.Update(list);
                })
                .AddTo(this);
        }
    }
}