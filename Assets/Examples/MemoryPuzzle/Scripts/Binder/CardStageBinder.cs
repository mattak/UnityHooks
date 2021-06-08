using UniRx;
using UnityEngine;
using UnityHooks;

namespace Examples.MemoryPuzzle.Scripts
{
    [RequireComponent(typeof(CardsSpawner))]
    public class CardStageBinder : MonoBehaviour
    {
        private void Start()
        {
            var hook = Hooks.UseState(HookKeys.StageCard);
            hook.Value
                .Where(x => x != default && x.Length >= 2)
                .Subscribe(GetComponent<CardsSpawner>().Render)
                .AddTo(this);
        }
    }
}