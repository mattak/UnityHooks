using System;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using UnityHooks;

namespace Examples.MemoryPuzzle.Scripts
{
    public class CardInitializeBinder : MonoBehaviour
    {
        [SerializeField] private CardSet _cardSet = default;
        [SerializeField] private int _stageSizeX = 6;
        [SerializeField] private int _stageSizeY = 6;

        private void Start()
        {
            var length = _stageSizeX * _stageSizeY;
            CheckInitializeState(length);

            var reset = Hooks.UseState(HookKeys.Reset);
            reset.Where(x => x).Subscribe(_ => Reset(length)).AddTo(this);
            reset.Value = true;
        }

        private void CheckInitializeState(int length)
        {
            Assert.AreEqual(length % 2, 0, "Illegal card stage size. the size should be divided by 2.");
            Assert.IsTrue(length > 1, "Illegal card stage size. the length should be more than by two.");
            Assert.IsTrue(_cardSet.cards.Length * 2 >= length, "card set is less than stage length");
        }

        private void Reset(int length)
        {
            var stage = Hooks.UseState(HookKeys.StageCard);
            stage.Value = CreateStage(length);

            var ngCount = Hooks.UseState(HookKeys.NgCount);
            ngCount.Value = 0;
        }

        private Card[] CreateStage(int length)
        {
            var data = new Card[length];
            for (var i = 0; i < length; i += 2)
            {
                var index = i / 2;
                var card = _cardSet.cards[index];
                card.state = CardState.Hidden;
                data[i] = card.Copy();
                data[i + 1] = card.Copy();
            }

            var cards = data.ToList().OrderBy(x => Guid.NewGuid()).ToArray();
            for (var i = 0; i < cards.Length; i++)
            {
                cards[i].stageIndex = i;
            }

            return cards;
        }
    }
}