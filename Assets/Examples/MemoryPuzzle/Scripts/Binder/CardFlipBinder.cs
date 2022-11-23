using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityHooks;
using UnityHooks.Input;

namespace Examples.MemoryPuzzle.Scripts
{
    public class CardFlipBinder : MonoBehaviour
    {
        [SerializeField] private PointerDownInput _input = default;
        [SerializeField] private CardRender _render = default;

        private void Start()
        {
            var cardsHook = Hooks.UseState(HookKeys.StageCard);
            var ngCountHook = Hooks.UseState(HookKeys.NgCount);

            _input.pointerDownAsObservable
                .ThrottleFirst(TimeSpan.FromSeconds(1f))
                .Subscribe(_ => Flip(cardsHook, ngCountHook).Forget())
                .AddTo(this);
        }

        private async UniTask Flip(Hook<Card[]> cardsHook, Hook<int> ngCountHook)
        {
            var card = _render.Card;
            if (card.state == CardState.Shown || card.state == CardState.Selected)
            {
                return;
            }

            if (card.state == CardState.Hidden)
            {
                var selectedCard = cardsHook.Value.FirstOrDefault(x => x.state == CardState.Selected);
                if (selectedCard != default)
                {
                    var isSameCard = selectedCard.IsSameCard(card);
                    var nextState = isSameCard ? CardState.Shown : CardState.Hidden;
                    UpdateCards(cardsHook, selectedCard.stageIndex, card.stageIndex, CardState.Selected);
                    await ResetDelay(cardsHook, selectedCard.stageIndex, card.stageIndex, nextState);

                    if (!isSameCard) ngCountHook.Value += 1;
                }
                else
                {
                    cardsHook.Value[card.stageIndex].state = CardState.Selected;
                    cardsHook.ForceUpdate();
                }
            }
        }

        private async UniTask ResetDelay(Hook<Card[]> hook, int index1, int index2, CardState state)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            UpdateCards(hook, index1, index2, state);
        }

        private void UpdateCards(Hook<Card[]> hook, int index1, int index2, CardState state)
        {
            hook.Value[index1].state = state;
            hook.Value[index2].state = state;
            hook.ForceUpdate();
        }
    }
}