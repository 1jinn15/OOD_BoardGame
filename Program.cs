using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;


using BoardGameNamespace;
using BoardGame_OOD;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.CompilerServices;


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
        SaveFile svfile = new SaveFile();
        BoardGame oldGame;
        Console.WriteLine("input your choice:\n1. Start New Game\n2. Load Old Game");
        String input = Console.ReadLine();
        switch (int.Parse(input))
        {
            case 1: //Start new Game
                BoardGame newGame = new Notakto();
                newGame.playGame();
                break;
            case 2: // Load Old Game
                svfile.printSaveFile();
                Console.WriteLine("Select your old game file");
                String filename = Console.ReadLine();
                svfile.loadFile(filename);

                oldGame = new Notakto(svfile.player1, svfile.player2, svfile.currentPlayer, svfile.board,svfile.str);
                
                
                //oldGame.loadOldGame();


                //Player[] players = new Player[2];
                //int currentPlayer;
                


                //************************  Please only finish the following part, don't change anything else *************************

                // Task: Read 2 player name, currentPlayer, and 3 board from file and put it in the following variable 
                //Player[] names = new Player[2];
                //currentPlayer = 0;
                //Board[] boards = new Board[3];

                //SaveFile saveFile = new SaveFile(players[0], players[1],currentPlayer, boards);


                //saveFile.loadFile(filename);


                //names[0] = saveFile.player1;
                //names[1] = saveFile.player2;
                //currentPlayer = saveFile.currentPlayer;
                //boards = saveFile.board;

                //made the changes let me know if this works


                //string[] name = new string[2] { "ComputerPlayer", "anythinelse" };
                //// "ComputerPlayer" and "anythingelse" is just a example to run code with no error
                //currentPlayer = 0;
                //char[,] exampleBoard = new char[3, 3] { { ' ', 'X', ' ' }, { 'X', ' ', 'X' }, { ' ', 'X', 'X' } };

                //for(int i = 0; i < 3; i++)
                //{
                //    for (int j = 0; j < 3; j++)
                //    {
                //        Console.Write(exampleBoard[i, j]);
                //    }
                //}
                //Console.WriteLine(exampleBoard);
                // You should read 3 board from file, here only give 1 as an example
                //This look like
                //   X
                // X   X
                //   X X

                //for (int i = 0; i < 3; i++)
                //{
                //    for (int j = 0; j < 3; j++)
                //    {
                //        for (int k = 0; k < 3; k++)
                //        {
                //            boards[i].board[j, k] = exampleBoard[j, k];
                //            Console.WriteLine(exampleBoard[j,k]);
                //        }
                //    }
                //}

                // **************************************************************************************************************

                //for (int i = 0; i < 2; i++)
                //{
                //    if (name[i] == "ComputerPlayer")
                //    {
                //        players[i] = new ComputerPlayer(i + 1, name[i]);
                //    }
                //    else players[i] = new HumanPlayer(i + 1, name[i]);
                //}

                //oldGame.loadOldGame(players, currentPlayer, boards);



                break;

        }
    }


}
