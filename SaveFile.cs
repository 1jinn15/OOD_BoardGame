using System;


namespace BoardGameNamespace {
    public class SaveFile
    {

        public String fileName { get; private set; }
        public int fileID { get; private set; }
        public DateTime saveTime { get; private set; }

        public SaveFile()
        {

        }
    }
}