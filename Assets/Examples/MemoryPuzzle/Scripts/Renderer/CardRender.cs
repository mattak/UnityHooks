using UnityEngine;
using UnityEngine.UI;

namespace Examples.MemoryPuzzle.Scripts
{
    public class CardRender : MonoBehaviour
    {
        [SerializeField] private Image _containerImage = default;
        [SerializeField] private Image _cardImage = default;

        public Card Card { get; private set; }

        public void Render(Card card)
        {
            Card = card;
            _cardImage.sprite = card.sprite;
            _cardImage.color = card.GetForegroundColor();
            _containerImage.color = card.GetBackgroundColor();
            if (card.state == CardState.Hidden)
            {
                _cardImage.gameObject.SetActive(false);
            }
            else
            {
                _cardImage.gameObject.SetActive(true);
            }
        }
    }
}