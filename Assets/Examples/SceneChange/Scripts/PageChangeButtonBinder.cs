using UniRx;
using UnityEngine;
using UnityHooks.Input;

namespace Examples.SceneChange.Scripts
{
    [RequireComponent(typeof(PageRenderer))]
    public class PageChangeButtonBinder : MonoBehaviour
    {
        [SerializeField] private ButtonInput _buttonInput = default;
        [SerializeField] private string _page = default;

        public void Start()
        {
            var pageRenderer = GetComponent<PageRenderer>();

            _buttonInput.clickAsObservable
                .Select(_ => PageDefinition.Of(_page))
                .Subscribe(pageRenderer.Replace)
                .AddTo(this);
        }
    }
}