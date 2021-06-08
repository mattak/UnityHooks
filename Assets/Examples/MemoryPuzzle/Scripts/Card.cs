using System;
using UnityEngine;

namespace Examples.MemoryPuzzle.Scripts
{
    [Serializable]
    public class Card
    {
        public string name;
        public Sprite sprite;
        public ColorPalette palette;
        public CardState state { get; set; }
        public int stageIndex { get; set; }

        public Color GetForegroundColor()
        {
            return palette.GetColor();
        }

        public Boolean IsSameCard(Card card)
        {
            return this.sprite == card.sprite && this.palette == card.palette;
        }

        public Color GetBackgroundColor()
        {
            switch (state)
            {
                case CardState.Hidden: return Color.white;
                case CardState.Selected: return Color.yellow;
                case CardState.Shown: return Color.gray;
                default: throw new InvalidProgramException("Invalid program to handle card state");
            }
        }

        public Card Copy()
        {
            var card = new Card();
            card.name = this.name;
            card.sprite = this.sprite;
            card.palette = this.palette;
            card.state = this.state;
            card.stageIndex = this.stageIndex;
            return card;
        }
    }
}