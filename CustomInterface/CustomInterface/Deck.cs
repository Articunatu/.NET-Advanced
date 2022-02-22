using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomInterface
{
    class Deck : IDeckEntity<Card>
    {
        IList<Card> cards;

        public Deck()
        {
            cards = new List<Card>()
            {
                new Card{ MyProperty = 2},
                new Card{ MyProperty = 4},
                new Card{ MyProperty = 8}
            };
        }

        public void Add(Card card)
        {
            card.MyProperty = cards.Max(c => c.MyProperty) + 1;
            cards.Add(card);
        }

        public void Delete(int id)
        {
            var card = Find(id);
            cards.Remove(card);
        }

        public Card Find(int id)
        {
            var card = cards.FirstOrDefault(c => c.MyProperty == id);
            return card;
        }

        public IList<Card> GetAll()
        {
            return cards;
        }

        public void Update(int id, Card _card)
        {
            var card = Find(id);
            card.MyProperty = _card.MyProperty; 
        }
    }
}
