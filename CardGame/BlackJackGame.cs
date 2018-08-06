using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class BlackJack
    {
        Deck deck;
        List<BlackJackPlayer> PlayerList = new List<BlackJackPlayer>();
        Players CurrentPlayer = Players.PlayerDraw;
        bool ContinueGameFlag = true;

        public BlackJack()
        {
            PlayerList.Add(new BlackJackPlayer(Players.PlayerDraw, "Player"));
            PlayerList.Add(new BlackJackPlayer(Players.DealerDraw, "Dealer"));
            NewGame();
        }
        void NewGame()
        {
            deck = new Deck();
            CurrentPlayer = Players.PlayerDraw;
           // PlayerList.Clear();
            
            PlayerList[(int)CurrentPlayer].DrawCard(deck, 2);
            PlayerList[(int)Players.DealerDraw].DrawCard(deck, 2);
        }
        void DealerAI()
        {
            if (PlayerList[(int)Players.DealerDraw].GetPoints() <= 17)
            {
                Hit();
            }
            else
            {
                CheckForWinner();
            }
        }
        public void Menu()
        {
            int Choice;
            Console.WriteLine("What do you want to do? \n");
            Console.WriteLine("1. Hit");
            Console.WriteLine("2. Stay");

            string ChoiceString = Console.ReadLine();
            int.TryParse(ChoiceString, out Choice);

            if (Choice == 1)
            {
                Hit();
            }
            else if (Choice == 2)
            {
                Stay();
            }
        }
        void PlayAgainMenu()
        {
            int Choice;

            Console.WriteLine("Play Again? \n");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");

            string ChoiceString = Console.ReadLine();
            int.TryParse(ChoiceString, out Choice);

            if (Choice == 1)
            {
                NewGame();
            }
            else if (Choice == 2)
            {
                ContinueGameFlag = false;
            }
        }
        void CheckForWinner()
        {
            if (PlayerList[(int)Players.PlayerDraw].GetPoints() > PlayerList[(int)Players.DealerDraw].GetPoints())
            {
                Console.WriteLine("Player Winner");
            }
            else if (PlayerList[(int)Players.PlayerDraw].GetPoints() <= PlayerList[(int)Players.DealerDraw].GetPoints())
            {
                Console.WriteLine("Dealer Winner");
            }
            PlayAgainMenu();
        }
        void CheckCardTotal(BlackJackPlayer player)
        {
            player.SetPoints(0);

            SendAcesToBack(player);
            foreach (Card CardInList in player.GetCardsInHand())
            {
                if (CardInList.GetNumber() == 11 || //Jack
                   CardInList.GetNumber() == 12 || //Queen
                   CardInList.GetNumber() == 13)   //King
                {
                    player.SetPoints(player.GetPoints() + 10);
                }
                else if (CardInList.GetNumber() == 1)
                {
                    if (PlayerList[(int)CurrentPlayer].GetPoints() > 10)
                    {
                        player.SetPoints(player.GetPoints() + 1);
                    }
                    else
                    {
                        player.SetPoints(player.GetPoints() + 11);
                    }
                }
                else
                {
                    player.SetPoints(player.GetPoints() + CardInList.GetNumber());
                }
            }
            CheckIfOver21(player);
        }
        void CheckIfOver21(BlackJackPlayer player)
        {
            if (player.GetPoints() > 21)
            {
                GetCardTotal(player);
                Console.WriteLine(player.GetName() + " Lose");
                PlayAgainMenu();
            }
        }
        public void SendAcesToBack(BlackJackPlayer player)
        {
            foreach (Card card in player.GetCardsInHand())
            {
                if (card.GetNumber() == 1)
                {
                    player.GetCardsInHand().Remove(card);
                    player.GetCardsInHand().Add(card);
                    break;
                }
            }
        }
        public void GetCardTotal(BlackJackPlayer player)
        {
            Console.WriteLine("Card Total:" + player.GetPoints() + "\n\n");
        }
        void Hit()
        {
            PlayerList[(int)CurrentPlayer].DrawCard(deck, 1);
        }
        void Stay()
        {
            CurrentPlayer = Players.DealerDraw;
        }
        public void Update()
        {
            Console.Clear();
            foreach (BlackJackPlayer player in PlayerList)
            {
                player.ShowHand();
                CheckCardTotal(player);
                GetCardTotal(player);
            }
            if (CurrentPlayer == Players.PlayerDraw)
            {
                Menu();
            }
            else if (CurrentPlayer == Players.DealerDraw)
            {
                PlayerList[(int)Players.DealerDraw].ShowHand();
                DealerAI();
            }
        }
        public bool GetGameStatus()
        {
            return ContinueGameFlag;
        }
    }
}
