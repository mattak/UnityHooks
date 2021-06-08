using System;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityHooks;
using UnityHooks.Renderer;

namespace Examples.MemoryPuzzle.Scripts
{
    [RequireComponent(typeof(TextRenderer))]
    public class OkCountBinder : MonoBehaviour
    {
        private void Start()
        {
            var hook = Hooks.UseState(HookKeys.StageCard);
            hook.Value
                .Select(ConvertCounts)
                .Subscribe(GetComponent<TextRenderer>().Render)
                .AddTo(this);
        }

        private String ConvertCounts(Card[] cards)
        {
            var shownCounts = cards.Count(x => x.state == CardState.Shown) / 2;
            return $"o {shownCounts}";
        }
    }
}