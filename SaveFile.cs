using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BoardGame_OOD
{
    internal class SaveFile
    {
        public String fileName { get; private set; }
        public int fileID { get; private set; }
        public DateTime saveTime { get; private set; }
        public Board[] Boards { get; private set; }
        public Player[] Players { get; private set; }
        public int CurrentPlayer { get; private set; }

        //board status (doubt) 
        // public string BoardStatus { get; private set; }


        public SaveFile(String fileName, int fileID, Board[] boards, Player[] players, int currentPlayer)
        {
            FileName = Name;
            FileID = ID;
            SaveTime = DateTime.Now;
            Boards = boards;
            Players = players;
            CurrentPlayer = currentPlayer;
        }

        private SaveFile() 
        { 
        
        }

        // Save File Method
        public void Save()
        {
            const string FILENAME = "SaveGame.txt";

            FileStream outFile = new FileStream(FILENAME, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFile);

            writer.WriteLine("{0},{1},{2}",fileName, fileID, saveTime);

            writer.Close();
            outFile.Close();
        }

        // Load File Method 

        public static SaveFile Load()
        {
            const string FILENAME = "Game.txt";
            SaveFile savefile = new SaveFile();


            FileStream intFile = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(intFile);


            string record;
            string[] fields;


            Console.WriteLine("\n{0},-10}{1,-18},{2,10}\n", "ID", "Name", "Save Time");
            record = reader.ReadLine();


            while (record != null)
            {
                fields = record.Split(',');

                savefile.fileID = Convert.ToInt16(fields[0]);
                savefile.fileName = fields[1];
                savefile.saveTime = DateTime.Parse(fields[2]);
                Console.WriteLine("{0},-10}{1,-18},{2,10}", savefile.fileID, savefile.fileName);
                record = reader.ReadLine();

            }


            reader.Close();
            intFile.Close();

            return savefile;
        }
        // Delete File Method
        public static void DeleteSaveFile(string fileName)
        {
            File.Delete(fileName);  
        }
    }
}
