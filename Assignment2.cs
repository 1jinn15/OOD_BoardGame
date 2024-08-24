using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;


public class Cordinate
{
    public int x { get; set; }
    public int y { get; set; }
    public int boardNum { get; set; }
}

/*
public class MoveTracker
{

    public MoveTracker()
    {


    }
}
*/

public class SaveFile{

  public String fileName {get; private set; }
  public int fileID {get; private set; }
  public DateTime saveTime {get; private set; }

  public SaveFile(){



}
    
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
    
    public int BoardSize{
        get { return boards.Length; }
    }
    public BoardGame(){

        initializeGame();
        playGame();

        
    }
    public void loadOldGame(Board board, Player[] player, int currentPlayer){

    }
    public void playGame(){
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
    public void saveGame(Board board, Player[] players, int currentPlayer){
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
    protected override void play(Player player){
        
    }
    
    protected override bool endOfGame()
    {
        bool winStatusB1 = this.boards[0].checkWin();
        bool winStatusB2 = this.boards[1].checkWin();
        bool winStatusB3 = this.boards[2].checkWin();
        if(winStatusB1==true&&winStatusB2==true&&winStatusB3==true){
            return true;//cw output something?
        }else{
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
    public Gomoku(){
        boards = new Board[1];
    }
    protected override void initializeGame(){
        this.boards[0] = new Board(15,15);
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
        do {
            Console.WriteLine("Which board you prefer?");
            String str = Console.ReadLine();
            piece.boardNum = int.Parse(str);
            
            if (piece.boardNum < 0 || piece.boardNum >= boards.Length || !boards[piece.boardNum].available){
                Console.WriteLine("Invalid choice, please choose an available board.");
            }
        } while (piece.boardNum < 0 || piece.boardNum >= boards.Length || !boards[piece.boardNum].available);

        do{
            Console.WriteLine("input move x");
            String s = Console.ReadLine();
            piece.x = int.Parse(s);
            Console.WriteLine("input move y");
            s = Console.ReadLine();
            piece.y = int.Parse(s);//in board check the condition if some place is available to place a piece
        } while (boards[piece.boardNum].checkPieceAvailable(piece)!=true);
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


public class GameMode
{
    public Player player1 { set; get; }
    public Player player2 { set; get; }
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
public class Board
{
    //public or private?
    public int Width { get; private set; }
    public int Height { get; private set; }
    public bool available { get; set; }
    public char[,] board;
    
    public Board(int width, int height)
    {
        this.Width = width;
        this.Height = height;
        this.board = new char[width, height];
        this.available = true;

        // Initialize the board with spaces
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                board[i, j] = ' ';
            }
        }
    }
    
    public bool checkPieceAvailable(Cordinate cordinate) {
        if (board[cordinate.x, cordinate.y] != ' ')
        {
            Console.WriteLine("The place is not empty, plz try another!");
            return false;
        }else {
            return true;
        }
    }
    public void printBoard(int boardNum)
    {
        Console.WriteLine("board: " +boardNum);
        Console.WriteLine("-------");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write("|");
                if (board[i, j] == ' ')
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(board[i, j]);
                }
            }
            Console.WriteLine("|");


            Console.WriteLine("-------");
            
        }
    }

    public bool checkWin()
    {
        if ((board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2] && board[0, 2] != ' ')
        || (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2] && board[1, 2] != ' ')
        || (board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2] && board[2, 2] != ' ')
        || (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0] && board[2, 0] != ' ')
        || (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1] && board[2, 1] != ' ')
        || (board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2] && board[2, 2] != ' ')
        || (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[2, 2] != ' ')
        || (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[2, 0] != ' '))
            return true;
        return false;
    }

    public bool PlacePiece(int playerNumber, int position_x, int position_y)
    {
        board[position_x,position_y]= 'X';
        return true;
    }

    //Maybe dont need IsFull() in Notakto?
    public bool IsFull(int sizeWidth, int sizeHeight)
    {
        for (int i = 0; i < sizeWidth; i++)
        {
            for (int j = 0; j < sizeHeight; j++)
            {
                if (board[i, j] == ' ')
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void Undo()
    {

    }

    public void Redo()
    {

    }
}





class Program
{
    static void Main(string[] args){
        
        BoardGame game = new Notakto();


    }


}
