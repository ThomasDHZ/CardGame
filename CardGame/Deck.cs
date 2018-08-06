using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Deck
    {
        protected List<Card> CardList = new List<Card>();
        protected List<Card> DiscardPile = new List<Card>();

        public Deck()
        {
            for (int x = 1; x <= 13; x++)
            {
                for (int y = 0; y <= 3; y++)
                {
                    CardList.Add(new Card(x, ConvertIntToSuit(y)));
                }
            }
            ShuffleDeck();
        }
        Suit ConvertIntToSuit(int number)
        {
            switch (number)
            {
                case (int)Suit.Club: return Suit.Club;
                case (int)Suit.Diamond: return Suit.Diamond;
                case (int)Suit.Heart: return Suit.Heart;
                case (int)Suit.Spade: return Suit.Spade;
                default: return 0;
            }
        }
        string ConvertNumberToFaceCard(int number)
        {
            if (number == 1 || number >= 11)
            {
                switch (number)
                {
                    case 1: return "A";
                    case 11: return "J";
                    case 12: return "Q";
                    case 13: return "K";
                    default: return "";
                }
            }
            else
            {
                return number.ToString();
            }
        }
        void ShowCardDeck()
        {
            Console.WriteLine("Cards in deck: ");
            foreach (Card card in CardList)
            {
                Console.WriteLine(card.GetCardString());
            }
        }
        public void ShowDiscardPile()
        {
            Console.WriteLine("Cards in discard: ");
            foreach (Card card in DiscardPile)
            {
                Console.WriteLine(card.GetCardString());
            }
        }
        public void ShuffleDeck()
        {
            Random random = new Random();
            List<Card> TempCardList = new List<Card>();

            Console.WriteLine("Shuffling...");
            for (int x = CardList.Count - 1; x >= 0; x--)
            {
                int randomNumber = random.Next(0, CardList.Count);

                TempCardList.Add(CardList[randomNumber]);
                CardList.Remove(CardList[randomNumber]);
            }
            CardList = TempCardList;
        }
        public List<Card> GetDeck()
        {
            return CardList;
        }
        public void GetDeckCardCount()
        {
            Console.WriteLine(CardList.Count);
        }
    }
    /*public void Discard()
  {
    ShowHand();
    Console.WriteLine("Choose card to discard.");
    string DiscardingCard = Console.ReadLine();
    CheckForMulitpleDiscard(DiscardingCard.ToUpper());
  }
  void CheckForMulitpleDiscard(string CardList)
  {
    List<string> DiscardList = new List<string>();
    string temp = "";

    for(int x = 0; x <= CardList.Length - 1; x++)
    {
      if(CardList[x] != ',')
      {
        temp += CardList[x];
      }
      else if(CardList[x] == ',')
      {
        DiscardList.Add(temp);
        temp = "";
      }
      if(x == CardList.Length - 1)
      {
        DiscardList.Add(temp);
        temp = "";
      }
    }
    foreach(string discard in DiscardList)
    {
      CheckCardInHand(discard);
    }
    ShowDiscardPile();
  }
  void CheckCardInHand(string Discard)
  {
    foreach(Card card in HandList)
    {
      string CardName = card.GetCardString();
      if(CardName == Discard)
      {
        Console.WriteLine(Discard + " has been discarded");
        DiscardPile.Add(card);
        HandList.Remove(card);
        break;
      }
    }
  }*/
}
