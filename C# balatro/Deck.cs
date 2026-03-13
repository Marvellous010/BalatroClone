using System;
using System.Collections.Generic;
using System.Linq;

namespace KlasUitwerking
{
    public class Deck
    {
        private List<Card> cards;
        private Random random;

        public int Count => this.cards.Count;

        public Deck()
        {
            this.cards = new List<Card>();
            this.random = new Random();
            this.InitializeStandardDeck();
        }

        private void InitializeStandardDeck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    this.cards.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            // Fisher-Yates shuffle algorithm
            int n = this.cards.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = this.random.Next(0, i + 1);
                Card temp = this.cards[i];
                this.cards[i] = this.cards[j];
                this.cards[j] = temp;
            }
        }

        public Card TakeCard()
        {
            if (this.cards.Count == 0)
            {
                throw new InvalidOperationException("Deck is empty!");
            }

            Card card = this.cards[0];
            this.cards.RemoveAt(0);
            return card;
        }

        public void AddCard(Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }
            this.cards.Add(card);
        }

        public bool RemoveCard(Card card)
        {
            return this.cards.Remove(card);
        }

        public void Reset()
        {
            this.cards.Clear();
            this.InitializeStandardDeck();
        }
    }
}