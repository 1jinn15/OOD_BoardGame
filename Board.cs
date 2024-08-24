namespace BoardGameNamespace
{
    public class Cordinate
    {
        
            public int x { get; set; }
            public int y { get; set; }
            public int boardNum { get; set; }
        
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

        public bool checkPieceAvailable(Cordinate cordinate)
        {
            if (board[cordinate.x, cordinate.y] != ' ')
            {
                Console.WriteLine("The place is not empty, plz try another!");
                return false;
            }
            else
            {
                return true;
            }
        }
        public void printBoard(int boardNum)
        {
            Console.WriteLine("board: " + boardNum);
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
            board[position_x, position_y] = 'X';
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
}