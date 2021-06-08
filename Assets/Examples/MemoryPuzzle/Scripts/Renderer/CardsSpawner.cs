using UnityEngine;

namespace Examples.MemoryPuzzle.Scripts
{
    public class CardsSpawner : MonoBehaviour
    {
        [SerializeField] private CardRender _prefab = default;
        private CardRender[] _renderers = default;

        public void Render(Card[] cards)
        {
            if (_renderers == default)
            {
                CleanCards();
                SpawnCards(cards);
            }

            RenderCards(cards);
        }

        private void CleanCards()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }

        private void RenderCards(Card[] cards)
        {
            for (var i = 0; i < cards.Length; i++)
            {
                _renderers[i].Render(cards[i]);
            }
        }

        private void SpawnCards(Card[] cards)
        {
            _renderers = new CardRender[cards.Length];

            for (var i = 0; i < cards.Length; i++)
            {
                _renderers[i] = Instantiate(_prefab, transform, false);
                _renderers[i].gameObject.name = $"card[{i.ToString()}]";
            }
        }
    }
}