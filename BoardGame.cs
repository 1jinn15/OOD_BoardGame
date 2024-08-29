using BoardGame_OOD;
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
        protected GameMode oldGameMode;
        protected Player player1;
        protected Player player2;
        //protected Player[] players;
        protected int currentPlayer = 1;
        protected Board[] boards;
        protected Cordinate piece;
        protected SaveFile save;

        public BoardGame()
        {
            //initializeGame();
        }

        public int BoardSize
        {
            get { return boards.Length; }
        }

       
        public void playGame()
        {
            this.save = new SaveFile();
            do
            {

                for (int i = 0; i < 3; i++)
                {
                    this.boards[i].printBoard(i);
                }
                switch (this.currentPlayer)
                {
                    case 1:
                        Console.WriteLine("It's now player" + this.player1.PlayerNumber + "'s turn!");
                        Console.WriteLine("Do you want to save this game and exit?(y/n)");
                        string s = Console.ReadLine();
                        if (s=="y") {
                            Console.WriteLine("name this game: ");
                            string name = Console.ReadLine();
                            //save.saveFile(name);
                            return;
                        }
                        piece = this.player1.Play(this.boards);
                        Console.WriteLine("Put on the " + piece.boardNum.ToString() + "Board, Move: x:" + piece.x.ToString() + " y: " + piece.y.ToString());

                        this.boards[piece.boardNum].PlacePiece(1, piece.x, piece.y);
                        if (this.boards[piece.boardNum].checkWin() == true)
                        {
                            this.boards[piece.boardNum].available = false;
                        }
                        this.currentPlayer = 2;

                        if (checkWinCondition()) return;

                        break;
                    case 2:
                        Console.WriteLine("It's now player" + this.player2.PlayerNumber + "'s turn!");
                        if (player2.Name!= "ComputerPlayer") {
                            Console.WriteLine("Do you want to save this game and exit?(y/n)");
                            string str = Console.ReadLine();
                            if (str == "y")
                            {
                                Console.WriteLine("name this game: ");
                                string name = Console.ReadLine();
                                //save.saveFile(name);
                                return;
                            }
                        }
                        piece = this.player2.Play(this.boards);
                        Console.WriteLine("Put on the " + piece.boardNum.ToString() + "Board, Move: x:" + piece.x.ToString() + " y: " + piece.y.ToString());

                        this.boards[piece.boardNum].PlacePiece(2, piece.x, piece.y);
                        if (this.boards[piece.boardNum].checkWin() == true)
                        {
                            this.boards[piece.boardNum].available = false;
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
        public Notakto() {
            initializeGame();
        }
        public Notakto(Player player1, Player player2, int currentPlayer, Board[] board, string str) {

            this.oldGameMode = new GameMode(1);
            this.boards = board;
            this.player1 = player1;
            this.player2 = player2;
            this.currentPlayer = currentPlayer;

            playGame();
        }
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