using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE05
{
    public class CollectionManager
    {
        private List<Card> _availableCards;
        private Dictionary<string, List<Card>> _currentCollection;

        public CollectionManager()
        {
            _availableCards = new List<Card>();
            _currentCollection = new Dictionary<string, List<Card>>();
        }




        // custom Getter for the card list
        public List<Card> GetList()
        {
            return _availableCards;
        }

        // custom Setter for the Card List
        public void  AddToList(Card addedCard)
        {
            _availableCards.Add(addedCard);
        }

        // custom remove a card from the list
        public void RemoveFromList(int index)
        {
            _availableCards.RemoveAt(index);

        }
        // custom getter for the dictionary
        public Dictionary<string, List<Card>> GetDictionary()
        {
            return _currentCollection;
        }

        public Card GetCard(string name, int index)
        {
            Card currentCard;
            List<Card> cardList = _currentCollection[name].ToList();
            currentCard = cardList[index];
            return currentCard;
        }
        // custom setter method for the dictionary
        public void AddToDictionary(string name, Card addedCard)
        {

            if (_currentCollection.Keys.Contains(name))
            {
                _currentCollection[name].Add(addedCard);
            }
            else
            {
                _currentCollection[name] = new List<Card> { addedCard };
            }

        }

        public void RemoveFromDictionary(string name, int index)
        {
            if (_currentCollection.Keys.Contains(name))
            {
                _currentCollection[name].RemoveAt(index-1);
                
            }
            else
            {
                Utility.ColoredConsole("red",$"The card you chose does not exist in {name}'s collection!");
            }
        }

        public List<string> GetDictionaryKeys()
        {
            if (_currentCollection.Count > 0)
            {
                List<string> keyList = new List<string>(_currentCollection.Keys);
                return keyList;
            }
            else
            {
                return null;
            }
        }

    }
}

