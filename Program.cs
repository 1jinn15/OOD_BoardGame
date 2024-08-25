using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;


using BoardGameNamespace; 


    /*
    


    // public class SaveFile
    // {

    //     public char player1;
    //     public char player2;
    //     public char currentPlayer;
    //     public Board[] board;

    //     public void File(Board[] board)
    //     {
    //         this.board = board;
    //     }

    //     public void loadFile()
    //     {
    //         // load file
    //     }

    //     void saveFile()
    //     {

    //     }

    //     private string generateFileName(string filename)
    //     {

    //     }

    // }

    */
    /*
    

    */





    class Program
    {
        static void Main(string[] args)
        {
        Console.WriteLine("input your choice:\n1. Start New Game\n2. Load Old Game");
        String input = Console.ReadLine();
        switch (int.Parse(input))
        {
            case 1: //Start new Game
                BoardGame newGame = new Notakto();
                newGame.playGame();
                break;
            case 2: // Load Old Game
                Console.WriteLine("Select your old game file");
                BoardGame oldGame = new Notakto();


                Player[] players = new Player[2];
                int currentPlayer;
                Board[] boards = new Board[3];

                for(int i = 0; i < 3; i++)
                {
                    boards[i] = new Board(3,3);
                }

                //************************  Please only finish the following part, don't change anything else *************************

                // Task: Read 2 player name, currentPlayer, and 3 board from file and put it in the following variable 



                string[] name = new string[2] { "ComputerPlayer", "anythinelse" };
                // "ComputerPlayer" and "anythingelse" is just a example to run code with no error
                currentPlayer = 0;
                char[,] exampleBoard = new char[3, 3] { {' ','X',' ' }, { 'X',' ','X' },{' ','X','X' } };
                // You should read 3 board from file, here only give 1 as an example
                //This look like
                //   X
                // X   X
                //   X X

                for (int i =0; i < 3; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        for(int k = 0; k < 3; k++)
                        {
                            boards[i].board[j, k] = exampleBoard[j, k];
                        }
                    }
                }

                // **************************************************************************************************************

                for(int i = 0; i < 2; i++)
                {
                    if (name[i] == "ComputerPlayer")
                    {
                        players[i] = new ComputerPlayer(i + 1, name[i]);
                    }
                    else players[i] = new HumanPlayer(i + 1, name[i]);
                }

                oldGame.loadOldGame(players, currentPlayer, boards);

                

                break;

        }
    }


    }

