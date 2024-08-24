

using System;

namespace BoardGameNamespace
{

    public interface Player
    {
        int PlayerNumber { get; set; }
        string Name { get; set; }
        Cordinate Play(Board[] board);
    }

    public class HumanPlayer : Player
    {
        public int PlayerNumber { get; set; }

        public string Name { get; set; }
        public HumanPlayer(int playerNumber, string name)
        {
            this.PlayerNumber = playerNumber;
            this.Name = name;

        }

        public Cordinate Play(Board[] boards)
        {
            /*
            if (boardLenth == 1)]
            {//this does not make sense, fix this first
             //through board size check one or three board needed
            }*/

            Cordinate piece = new Cordinate();
            //fix later
            // check the boundary of input
            do
            {
                Console.WriteLine("Which board you prefer?");
                String str = Console.ReadLine();
                piece.boardNum = int.Parse(str);

                if (piece.boardNum < 0 || piece.boardNum >= boards.Length || !boards[piece.boardNum].available)
                {
                    Console.WriteLine("Invalid choice, please choose an available board.");
                }
            } while (piece.boardNum < 0 || piece.boardNum >= boards.Length || !boards[piece.boardNum].available);

            do
            {
                Console.WriteLine("input move x");
                String s = Console.ReadLine();
                piece.x = int.Parse(s);
                Console.WriteLine("input move y");
                s = Console.ReadLine();
                piece.y = int.Parse(s);//in board check the condition if some place is available to place a piece
            } while (boards[piece.boardNum].checkPieceAvailable(piece) != true);
            // you should have a loop to double check if the input move is valid here

            return piece;
        }

    }

    public class ComputerPlayer : Player
    {
        public int PlayerNumber { get; set; }

        public string Name { get; set; }

        public ComputerPlayer(int playerNumber, string name)
        {
            this.PlayerNumber = playerNumber;
            this.Name = name;
        }

        public Cordinate Play(Board[] board)
        {
            Random random = new Random();
            Cordinate piece = new Cordinate();
            int col, row;
            col = random.Next(0, board[0].Height);
            row = random.Next(0, board[0].Width);
            piece.x = col; //"|"
            piece.y = row; //"-"

            return piece;
        }


    }

}