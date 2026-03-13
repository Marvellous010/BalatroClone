using System;
using System.Collections.Generic;
using System.Text;

namespace C__balatro
{
    internal class Hand
    {
        private readonly List<Card> _cards = new();

        public int Count => _cards.Count;

        public IEnumerable<Card> Cards => _cards.AsReadOnly();

        public void Add(Card card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));
            _cards.Add(card);
        }

        public void AddRange(IEnumerable<Card> cards)
        {
            if (cards == null) throw new ArgumentNullException(nameof(cards));
            _cards.AddRange(cards);
        }

        public bool Remove(Card card)
        {
            if (card == null) return false;
            return _cards.Remove(card);
        }

        public void Clear() => _cards.Clear();

        public override string ToString()
        {
            if (_cards.Count == 0) return "(lege hand)";
            var sb = new StringBuilder();
            for (int i = 0; i < _cards.Count; i++)
            {
                sb.AppendLine($"{i + 1}: {_cards[i]}");
            }
            return sb.ToString();
        }
    }
}
