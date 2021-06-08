using System.Linq;
using UnityEngine;

namespace Examples.MemoryPuzzle.Scripts
{
    [CreateAssetMenu(fileName = "CardSet", menuName = "ScriptableObjects/CardSet", order = 1)]
    public class CardSet : ScriptableObject
    {
        public Card[] cards = default;

        public Card GetCard(string cardName)
        {
            return cards.FirstOrDefault(x => x.name == cardName);
        }
    }
}