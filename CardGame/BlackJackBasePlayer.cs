using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class BlackJackPlayer
    {
        string PlayerName;
        List<Card> HandList = new List<Card>();
        Players PlayerType;
        int PlayerPoints;

        public BlackJackPlayer()
        {
        }
        public BlackJackPlayer(Players playertype, string playername = "")
        {
            PlayerName = playername;
            PlayerType = playertype;
        }
        public void DrawCard(Deck deck, int DrawAmount = 1)
        {
            if (DrawAmount > deck.GetDeck().Count)
            {
                Console.WriteLine("There isn't enough cards to draw.");
            }
            else
            {
                for (int x = 0; x < DrawAmount; x++)
                {
                    HandList.Add(deck.GetDeck()[0]);
                    deck.GetDeck().Remove(deck.GetDeck()[0]);
                }
            }
        }
        public void ShowHand()
        {
            Console.WriteLine(PlayerName + " Cards in hand: ");
            foreach (Card card in HandList)
            {
                Console.WriteLine(card.GetCardString());
            }
        }
        public void ClearHand()
        {
            HandList.Clear();
        }
        public List<Card> GetCardsInHand()
        {
            return HandList;
        }
        public void SetPoints(int points)
        {
            PlayerPoints = points;
        }
        public int GetPoints()
        {
            return PlayerPoints;
        }
        public Players GetPlayerType()
        {
            return PlayerType;
        }
        public string GetName()
        {
            return PlayerName;
        }
    }
}
