
using System;


namespace BoardGameNamespace
{
    

    public class GameMode
    {
        public Player player1 { set; get; }
        public Player player2 { set; get; }

        public GameMode(int chooseGameMode) { 
            
        }
        public GameMode()
        {
            int chooseGameMode;
            do
            {
                Console.Write("Enter your choice (1. Human vs Human, 2. Human vs Computer) : ");
                Console.WriteLine("Please enter a game mode");
            } while (!int.TryParse(Console.ReadLine(), out chooseGameMode) || (chooseGameMode != 1 && chooseGameMode != 2));

            switch (chooseGameMode)
            {
                case 1:
                    string name1;
                    string name2;
                    System.Console.Write("plz enter player1 name: ");
                    name1 = Console.ReadLine();
                    System.Console.Write("plz enter player2 name: ");
                    name2 = Console.ReadLine();
                    setHumanVsHumanMode(name1, name2);
                    break;
                case 2:
                    string name;
                    System.Console.Write("plz enter humanPlayer name: ");
                    name = Console.ReadLine();
                    setHumanVsComputerMode(name);
                    break;
            }
        }
        

        private void setHumanVsHumanMode(string name1, string name2)
        {
            player1 = new HumanPlayer(1, name1);
            player2 = new HumanPlayer(2, name2);
        }

        private void setHumanVsComputerMode(string name)
        {
            player1 = new HumanPlayer(1, name);
            player2 = new ComputerPlayer(2, "ComputerPlayer");
        }


    }
    
}