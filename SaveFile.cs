using System;
using System.IO;

namespace BoardGame_OOD
{
    public class SaveFile
    {
        public char player1 { get; private set; }
        public char player2 { get; private set; }
        public char currentPlayer { get; private set; }
        public Board[] board { get; private set; }


        public SaveFile(char player1, char player2, char currentPlayer, Board[] board)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.currentPlayer = currentPlayer;
            this.board = board;
        }


        public void File(Board[] board)
        {
            this.board = board;
        }

        // Method to save game information 
        public void saveFile(string fileName)
        {
            string filePath = generateFileName(fileName);

            FileStream outFile = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFile);


            writer.WriteLine(player1);
            writer.WriteLine(player2);
            writer.WriteLine(currentPlayer);


            foreach (var b in board)
            {
                for (int i = 0; i < b.board.GetLength(0); i++)
                {
                    for (int j = 0; j < b.board.GetLength(1); j++)
                    {
                        writer.Write(b.board[i, j]);
                    }
                    writer.WriteLine(); 
                }
            }

            writer.Close();
            outFile.Close();
        }

        // Method to load information from file
        public void loadFile(string fileName)
        {
            string filePath = generateFileName(fileName);

            FileStream inFile = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);

     
            player1 = reader.ReadLine()[0];
            player2 = reader.ReadLine()[0];
            currentPlayer = reader.ReadLine()[0];


            for (int b = 0; b < board.Length; b++)
            {
                for (int i = 0; i < board[b].board.GetLength(0); i++)
                {
                    string line = reader.ReadLine();
                    for (int j = 0; j < board[b].board.GetLength(1); j++)
                    {
                        board[b].board[i, j] = line[j];
                    }
                }
            }


            reader.Close();
            inFile.Close();
        }


        private string generateFileName(string filename)
        {
            return $"{filename}.txt";
        }
    }
}
