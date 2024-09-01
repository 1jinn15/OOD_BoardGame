using BoardGame_OOD;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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
        protected int previousBoard;
        protected bool firstEnter;
        protected Board[] boards;
        protected Cordinate piece;
        protected SaveFile save;
        protected MoveTracker moveTracker;
        //protected MoveTracker mv = new MoveTracker();

        public BoardGame()
        {
            this.moveTracker = new MoveTracker();
            //initializeGame();
        }

        public int BoardSize
        {
            get { return boards.Length; }
        }

       
        public void playGame()
        {
            firstEnter = true;
            save = new SaveFile();
            
            do
            {
                
                for (int i = 0; i < 3; i++)
                {
                    boards[i].printBoard(i);
                }
                
                switch (currentPlayer)
                {
                    case 1:
                        Console.WriteLine("It's now player" + this.player1.PlayerNumber + "'s turn!");
                        if (firstEnter!=true) {
                            Console.WriteLine("Do you want to save this game and exit?(y/n)");
                            string s = Console.ReadLine();
                            if (s == "y") {
                                Console.WriteLine("name this game: ");
                                string name = Console.ReadLine();
                                //save.saveFile(name);
                                return;
                            }
                            while (true) {
                                Console.WriteLine("Do you want to undo or redo move?(undo/redo/n)");
                                string input = Console.ReadLine();
                                if (input != "n") {
                                    
                                    if (input == "undo") {
                                        GlobalUndo();
                                    }
                                    else if (input == "redo") {
                                        GlobalRedo();
                                    }
                                    //this.boards[previousBoard].UndoMove();
                                }
                                for (int i = 0; i < 3; i++)
                                {
                                    this.boards[i].printBoard(i);
                                }

                                if (input=="n") {
                                    break;
                                }
                            }
                        }
                        piece = this.player1.Play(boards);
                        previousBoard = piece.boardNum;
                        Console.WriteLine("Put on the " + piece.boardNum.ToString() + "Board, Move: x:" + piece.x.ToString() + " y: " + piece.y.ToString());

                        boards[piece.boardNum].PlacePiece(1, piece.x, piece.y);
                        if (boards[piece.boardNum].checkWin() == true)
                        {
                            boards[piece.boardNum].available = false;
                        }
                        firstEnter = false;
                        currentPlayer = 2;

                        if (checkWinCondition()) return;

                        break;
                    case 2:
                        Console.WriteLine("It's now player" + this.player2.PlayerNumber + "'s turn!");
                        if (player2.Name!= "ComputerPlayer"&& firstEnter != true) {
                            Console.WriteLine("Do you want to save this game and exit?(y/n)");
                            string str = Console.ReadLine();
                            if (str == "y")
                            {
                                Console.WriteLine("name this game: ");
                                string name = Console.ReadLine();
                                //save.saveFile(name);
                                return;
                            }
                            Console.WriteLine("Do you want to undo and redo move?(y/n)");
                            string yes = Console.ReadLine();
                            if (yes == "y")
                            {
                                //boards[previousBoard].UndoMove();
                            }
                        }
                        piece = this.player2.Play(this.boards);
                        this.previousBoard = piece.boardNum;
                        Console.WriteLine("Put on the " + piece.boardNum.ToString() + "Board, Move: x:" + piece.x.ToString() + " y: " + piece.y.ToString());

                        this.boards[piece.boardNum].PlacePiece(2, piece.x, piece.y);
                        if (this.boards[piece.boardNum].checkWin() == true)
                        {
                            this.boards[piece.boardNum].available = false;
                        }
                        this.firstEnter = false;
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

        public void GlobalUndo()
        {
            if (moveTracker.HasHistory())
            {
                var lastMove = moveTracker.PopMove();
                int boardNum = lastMove.Item1;

                if (boardNum >= 0 && boardNum < boards.Length)
                {
                    List<int> move = lastMove.Item2;
                    boards[boardNum].UndoMove(move);
                    moveTracker.PushRedo(boardNum, move);
                    

                    Console.WriteLine($"Undo completed on Board {boardNum + 1}.");  // Display as 1-based for user-friendly output
                }
                else
                {
                    Console.WriteLine("Invalid board number.");
                }
            }
            else
            {
                Console.WriteLine("Nothing to undo.");
            }
        }


        public void GlobalRedo()
        {
            if (moveTracker.HasRedoHistory())
            {
                var redoMove = moveTracker.PopRedo();
                int boardNum = redoMove.Item1;
                if (boardNum >= 0 && boardNum < boards.Length)
                {
                    List<int> move = redoMove.Item2;
                    boards[boardNum].RedoMove(move);
                    Console.WriteLine($"Redo completed on Board {boardNum + 1}.");  // Display as 1-based for user-friendly output
                }
                else
                {
                    Console.WriteLine("Invalid board number.");
                }
            }
            else
            {
                Console.WriteLine("Nothing to redo.");
            }
        }



    }
    class Notakto : BoardGame
    {
        public Notakto() {
            initializeGame();
        }
        public Notakto(Player player1, Player player2, int currentPlayer, Board[] board, string str) {

            this.boards = board;
            this.player1 = player1;
            this.player2 = player2;
            this.currentPlayer = currentPlayer;
            //Console.WriteLine("b: "+ this.boards+", p1: "+this.player1.Name+", p2: "+this.player2.Name+", current: "+this.currentPlayer);

            playGame();
        }
        protected override void initializeGame()
        {
            boards = new Board[3];
            for (int i = 0; i < 3; i++){
                boards[i] = new Board(3, 3,i, moveTracker);
                boards[i].printBoard(i);
            }
            selectGameMode = new GameMode();
            Console.WriteLine(selectGameMode.player1.Name);
            Console.WriteLine(selectGameMode.player2.Name);
            this.player1 = selectGameMode.player1;
            this.player2 = selectGameMode.player2;
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
                if (this.currentPlayer == 1){
                    Console.WriteLine("end Game, the winner is: player" + this.player2.PlayerNumber + ", " + this.player2.Name);
                }else {
                    Console.WriteLine("end Game, the winner is: player" + this.player1.PlayerNumber + ", "+ this.player1.Name);
                }
                
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
            this.boards[0] = new Board(15, 15,0, moveTracker);
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