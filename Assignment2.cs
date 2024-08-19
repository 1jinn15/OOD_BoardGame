using System;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Enumeration;

public class MoveTracker{
  
  public MoveTracker(){
    
  
  }
}

public interface Player{
  public int PlayerNumber { get; set; }
  public string Name { get; set; }

  public int Play(int width);
}

public class HumanPlayer : Player
{
  

  public HumanPlayer(int playerNumber, string name){
    PlayerNumber = playerNumber;
    Name = name;
  }

  public int Play(int width){
    int number;
  }

}

public class ComputerPlayer : Player{
  

  
}

public class GameMode
{
  
  public GameMode()
  {
    int chooseGameMode;
    do
    {
      Console.Write("Enter your choice (1. Human vs Human, 2. Human vs Computer) : ");
      Console.WriteLine("Please enter a game mode");
    } while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2));

    switch (choice)
    {
      case 1:
        setHumanVsHumanMode(name1, name2);
        break;
      case 2:
        setHumanVsComputerMode(name);
        break;
    }
  }

  private void setHumanVsHumanMode(string name1, string name2){
    HumanPlayer p1 = new HumanPlayer(1, name1);
    HumanPlayer p2 = new HumanPlayer(2, name2);
  }

  private void setHumanVsComputerMode(string name){
    HumanPlayer p1 = new HumanPlayer(1, name);
    ComputerPlayer p2 = new ComputerPlayer(2, "ComputerPlayer");
  }


}
public class Board
{
  public int width { get; private set; }
  public int height { get; private set; }

  public MoveTracker MoveTracker{get;set;}

  public Board(int size){
    width = size;
    height = size;


  }

  // public Board(int height,int width)
  // {
    
  // }

  public void Draw()
  {

  }
  
  public bool PlacePiece(int playerNumber,  int position_y ,int position_x = 0)
  {
    
  }
  
  public bool IsFull()
  {
    
  }

  public void Undo()
  {
    
  }

  public void Redo()
  {
    
  }
}

public class SaveFile{  
  
  public void saveGameToFile(Board board, Player[] players, int currentPlayer)
  {
    
  }
  public void loadGameFromFile()
  {
 

    
    
  }

  private string generateFileName(string filename)
  {
    
  }

}


public abstract class BoardGame
{
  
  public void newGame(){
    
  }
  public void loadOldGame(Board board, Player[] player, int currentPlayer)
  {
    
  }
  public void playGame()
  {
    
  }
  public void saveGame(Board board, Player[] players, int currentPlayer)
  {
    
  }
  
}
class Notakto : BoardGame
{
  
  protected override void initializeGame()
  {
    private Board board;
    board.size = 3;

  }


  protected override void play(Player player)
  {
    

  }
  protected override bool endOfGame()
  { 
    
  }
  protected override bool checkWinCondition()
  {
    
    
  }
  /* Specific declarations for the chess game. */
}


class Gomoku : BoardGame
{
  private Board board;
  protected override void initializeGame()
  {

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
  /* Specific declarations for the chess game. */
}

class Program
{
  static void Main(string[] args)
  {


  }

  
}
