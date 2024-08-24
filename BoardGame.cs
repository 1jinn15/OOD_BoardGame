

using System;

namespace BoardGameNamespace
{
    public abstract class BoardGame
    {
        protected abstract void initializeGame();
        protected abstract void play(Player player);
        protected abstract bool endOfGame();
        protected abstract bool checkWinCondition();
        protected GameMode selectGameMode;
        protected Player[] players;
        protected int currentPlayer = 1;
        protected Board[] boards;
        protected Cordinate piece;

        public int BoardSize
        {
            get { return boards.Length; }
        }
        public BoardGame()
        {

            initializeGame();
            playGame();


        }
        public void loadOldGame(Board board, Player[] player, int currentPlayer)
        {

        }
        public void playGame()
        {
            do
            {

                for (int i = 0; i < 3; i++)
                {
                    boards[i].printBoard(i);
                }

                switch (currentPlayer)
                {
                    case 1:
                        Console.WriteLine("It's now player" + selectGameMode.player1.PlayerNumber + "'s turn!");
                        piece = selectGameMode.player1.Play(boards);
                        Console.WriteLine("Put on the " + piece.boardNum.ToString() + "Board, Move: x:" + piece.x.ToString() + " y: " + piece.y.ToString());

                        boards[piece.boardNum].PlacePiece(1, piece.x, piece.y);
                        if (boards[piece.boardNum].checkWin() == true)
                        {
                            boards[piece.boardNum].available = false;
                        }
                        currentPlayer = 2;

                        if (checkWinCondition()) return;

                        break;
                    case 2:
                        Console.WriteLine("It's now player" + selectGameMode.player2.PlayerNumber + "'s turn!");
                        piece = selectGameMode.player2.Play(boards);
                        Console.WriteLine("Put on the " + piece.boardNum.ToString() + "Board, Move: x:" + piece.x.ToString() + " y: " + piece.y.ToString());

                        boards[piece.boardNum].PlacePiece(2, piece.x, piece.y);
                        if (boards[piece.boardNum].checkWin() == true)
                        {
                            boards[piece.boardNum].available = false;
                        }
                        currentPlayer = 1;

                        if (checkWinCondition()) return;
                        break;
                }

                // check win condition


            } while (true);//fix while restriction later


        }
        public void saveGame(Board board, Player[] players, int currentPlayer)
        {
            //after File done
        }



    }
    class Notakto : BoardGame
    {

        protected override void initializeGame()
        {
            this.boards = new Board[3];
            for (int i = 0; i < 3; i++)
            {
                boards[i] = new Board(3, 3);
                boards[i].printBoard(i);
            }
            this.selectGameMode = new GameMode();
            Console.WriteLine(selectGameMode.player1.Name);
            Console.WriteLine(selectGameMode.player2.Name);
            this.piece = new Cordinate();


        }

        //int[] Play(int width, int height, int boardLength);
        protected override void play(Player player)
        {

        }

        protected override bool endOfGame()
        {
            bool winStatusB1 = this.boards[0].checkWin();
            bool winStatusB2 = this.boards[1].checkWin();
            bool winStatusB3 = this.boards[2].checkWin();
            if (winStatusB1 == true && winStatusB2 == true && winStatusB3 == true)
            {
                return true;//cw output something?
            }
            else
            {
                return false;
            }
        }
        protected override bool checkWinCondition()
        {
            int countBoard = 0;
            for (int i = 0; i < 3; i++)
            {
                if (boards[i].available == false)
                {
                    countBoard++;
                }
            }
            if (countBoard == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    boards[i].printBoard(i);
                }
                Console.WriteLine("end Game, the winner is: player" + selectGameMode.player2.PlayerNumber + ", " + selectGameMode.player2.Name);
                return true;
            }
            return false;

        }
        // Specific declarations for the chess game. 
    }


    class Gomoku : BoardGame
    {
        public Gomoku()
        {
            boards = new Board[1];
        }
        protected override void initializeGame()
        {
            this.boards[0] = new Board(15, 15);
            this.boards[0].printBoard(0);
        }


        protected override void play(Player player)
        {
            // implement the method
        }
        protected override bool endOfGame()
        {
            // implement the method
            return true;
        }
        protected override bool checkWinCondition()
        {
            return true;
            // implement the method
        }
        //Specific declarations for the chess game. 
    }


}