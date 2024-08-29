using BoardGameNamespace;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Xml.Linq;

namespace BoardGame_OOD
{
    public class SaveFile
    {
        public Player player1 { get; private set; }
        public Player player2 { get; private set; }
        public int currentPlayer { get; private set; }
        public Board[] board { get; private set; }
        public string str = "";


        public SaveFile(Player player1, Player player2, int currentPlayer, Board[] board)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.currentPlayer = currentPlayer;
            this.board = board;

        }
        public SaveFile()
        {
            board = new Board[3];
        }

        public void BoardFile(Board[] board)//used to be File
        {
            this.board = board;
        }

        // Method to save game information 
        public void saveFile(string fileName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;
            string filePath = Path.Combine(projectDirectory, fileName);

            // Ensure the board array is initialized
            if (this.board == null)
            {
                Console.WriteLine("Board array is null.");
                return;
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(this.player1.Name);
                writer.WriteLine(this.player2.Name);
                writer.WriteLine(this.currentPlayer);

                for (int i=0;i<3;i++) { 
                    
                }
            }

            Console.WriteLine($"Game saved to {filePath}");
        }



        // Method to load information from file
        public void loadFile(string fileName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;
            string filePath = Path.Combine(projectDirectory, fileName);
            //Console.WriteLine(readFile);
            using (StreamReader reader = new StreamReader(filePath))
            {
                string p1Name = reader.ReadLine();
                string p2Name = reader.ReadLine();
                //player1.Name = reader.ReadLine();  // 
                //player2.Name = reader.ReadLine();  // 
                if (p2Name == "ComputerPlayer")
                {
                    player1 = new HumanPlayer(1, p1Name);
                    player2 = new ComputerPlayer(2, "ComputerPlayer");
                }
                else
                {
                    player1 = new HumanPlayer(1, p1Name);
                    player2 = new HumanPlayer(2, p2Name);
                }
                //Console.WriteLine(player1.Name+", p2: "+player2.Name);


                
                if (int.TryParse(reader.ReadLine(), out int playerNumber))
                {
                    this.currentPlayer = playerNumber;
                }
                else
                {
                    throw new InvalidDataException("Invalid data for currentPlayer");
                }
                //Console.WriteLine("currentplayer: "+currentPlayer);
                for (int i = 0; i < 3; i++)
                { 
                    this.board[i] = new Board(3, 3);
                    string line="";
                    line = reader.ReadLine();
                    //this.board[i-1].printBoard(i, line);
                    this.str = line;
                    this.board[i].oldToBoard(line, board[i]);
                    //Console.WriteLine(str);
                }
            }
        }

        public void printSaveFile()
        {
            FileInfo fileInfo;
            DateTime lastModified;
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;

            Console.WriteLine("Searching for files...");
            try
            {
                string[] files = Directory.GetFiles(projectDirectory, "*.txt");

                if (files.Length == 0)
                {
                    Console.WriteLine("No .txt files found in the project directory.");
                    return;
                }

                foreach (string file in files)
                {
                    //Console.WriteLine($"Reading file: {Path.GetFileName(file)}");

                    try
                    {
                        fileInfo = new FileInfo(file);
                        //modified date
                        lastModified = fileInfo.LastWriteTime;
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("File name: "+ Path.GetFileName(file)+", Date: "+lastModified);
                        Console.WriteLine("--------------------------");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error reading file {Path.GetFileName(file)}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing directory: {ex.Message}");
            }
        }


        private string generateFileName(string filename)
        {
            return $"{filename}.txt";
        }
    }
}