using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Card
    {
        int CardNumber;
        string CardNumberString;
        Suit CardSuit;

        public Card()
        {

        }
        public Card(int cardnumber, Suit cardsuit)
        {
            CardNumber = cardnumber;
            CardNumberString = ConvertNumberToFaceCard(cardnumber);
            CardSuit = cardsuit;
        }
        public string ConvertSuitToString()
        {
            switch (CardSuit)
            {
                case Suit.Club: return "C";
                case Suit.Diamond: return "D";
                case Suit.Heart: return "H";
                case Suit.Spade: return "S";
                default: return "error";
            }
        }
        public string ConvertNumberToFaceCard(int number)
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
        public int GetNumber()
        {
            return CardNumber;
        }
        public string GetNumberInString()
        {
            return CardNumberString;
        }
        public Suit GetSuit()
        {
            return CardSuit;
        }
        public String GetSuitString()
        {
            return ConvertSuitToString();
        }
        public string GetCardString()
        {
            return GetNumberInString() + GetSuitString();
        }
    }
}
