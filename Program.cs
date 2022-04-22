using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Connect_4
{


    class Player
    {
        public char piece;
        
        public Player()
        {

        }
        public Player(char pvalue)
        {
            piece = pvalue;
            
        }


        public virtual String PlayerInput(char[,] board) //player inputs value
        {
            return Console.ReadLine();
        }
    
    }

    class Ai : Player
    {

        public Ai(char pvalue)
        {
            piece = pvalue;
            
        }
        public override String PlayerInput(char[,] board)    //Ai inputs value
        {
            String choice;
            var rand = new Random();
            choice = (rand.Next(7)).ToString();
            if (board[0, Int32.Parse(choice)] != ' ')
            {

            }
                
            Console.WriteLine("Ai places piece in column " + choice);
            return choice;

        }

        



    }






    class GameBoard
    {
        const int rows = 6, columns = 7;
        const char Empty = ' ', PLAYER1 = 'X', PLAYER2 = 'O'; // empty space makes board easier to see than a 0



          internal char[,] board;



        int Count;




        public GameBoard()
        {
          board = new char[rows, columns];



            for (int y = 0; y < rows; y++) //sets every point on the array to Empty
                for (int x = 0; x < columns; x++)
                    board[y, x] = Empty;
        }



        public void Display()         //displays the game board
        {
            Console.WriteLine("  1    2    3    4    5    6    7");
            for (int i = 0; i < rows; i++)
            {
                for (int f = 0; f < columns; f++)
                {
                    Console.Write(" [" + board[i, f] + "] ");
                }
                Console.Write("\n \n");
            }
            return;
        }




        public bool DropPiece(char player, int column) //checks to see if the chosen column is full then places the players piece into the board
        {
            column--;



            if (board[0, column] != Empty)
                return false;



            for (int y = 0; y < rows; y++)
            {
                if ((y == rows - 1) || (board[y + 1, column] != Empty))
                {
                    board[y, column] = player;
                    break;
                }
            }
            Count++;
            return true;
        }



        public bool connectRow(char player) //checks how many pieces of the same type are in a row horizontally, vertically and diagonally 
        {
            // Horizontal check:



            for (int y = 0; y < rows; y++)
                for (int x = 0; x < 4; x++)
                    if (board[y, x] == player && board[y, x + 1] == player)
                        if (board[y, x + 2] == player && board[y, x + 3] == player)
                            return true;



            // Vertical check:



            for (int y = 0; y < 3; y++)
                for (int x = 0; x < columns; x++)
                    if (board[y, x] == player && board[y + 1, x] == player)
                        if (board[y + 2, x] == player && board[y + 3, x] == player)
                            return true;



            // Diagonal check:



            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < columns; x++)
                {



                    if (board[y, x] == player)
                    {



                        // Diagonally left:
                        try
                        {
                            if (board[y + 1, x - 1] == player)
                            {
                                if (board[y + 2, x - 2] == player)
                                    if (board[y + 3, x - 3] == player)
                                        return true;
                            }
                        }
                        catch (IndexOutOfRangeException) { }



                        // Diagonally right:
                        try
                        {
                            if (board[y + 1, x + 1] == player)
                            {
                                if (board[y + 2, x + 2] == player)
                                    if (board[y + 3, x + 3] == player)
                                        return true;
                            }
                        }
                        catch (IndexOutOfRangeException) { }
                    }
                }
            }



            return false;
        }



        public bool Full() //returns true if every space on the board is filled
        {
            return Count >= rows * columns;
        }
    }







    class Program
    {
        static void Main(string[] args)
        {
            bool valid = false;
            String gameType = " "; 
            Player player1 = new Player();
            Player player2 = new Player();
            
            Console.WriteLine("Welcome\nHow would you like to play?:\n[1]:Player Vs Player\n[2]:Player Vs AI\n[3]:AI Vs AI");

             while (valid == false)
         {
                
                gameType = Console.ReadLine();


                switch (gameType)  //chooses who will be playing
                {
                    case "1":
                        player1 = new Player('X');
                        player2 = new Player('O');
                        valid = true;
                        break;
                    case "2":
                        player1 = new Player('X');
                        player2 = new Ai('O');
                        valid = true;
                        break;
                    case "3":
                        player1 = new Ai('X');
                        player2 = new Ai('O');
                        valid = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose again");
                        break;
                }

         } 
                GameBoard game = new GameBoard();



           
                
                Player player = player1;
                int column;



                bool gameLoop = true;
                bool inputLoop;



                while (gameLoop) //loops until the game is over
                {



                    System.Console.Clear();
                    game.Display();



                    do
                    {
                        inputLoop = true;



                        Console.Write("\nPlayer ");
                        Console.Write(player.piece);
                        Console.Write(": ");



                        if (Int32.TryParse(player.PlayerInput(game.board), out column))  
                        {
                            if (1 <= column && column <= 7)
                            {
                                if (game.DropPiece(player.piece, column))
                                {
                                    if (gameType == "3" || gameType == "2")
                                    {
                                    Console.ReadKey();
                                    }
                                    inputLoop = false;
                                }
                                else
                                {
                                    System.Console.Clear();
                                    game.Display();
                                    Console.WriteLine("\nFull column");
                                }
                            }
                            else
                            {
                                System.Console.Clear();
                                game.Display();
                                Console.WriteLine("\nThe integer must be between 1 and 7.");
                            }
                        }
                        else
                        {
                            System.Console.Clear();
                            game.Display();
                            Console.WriteLine("\nPlease enter a valid integer.");
                        }
                    } while (inputLoop);
                    


                    if (game.connectRow(player.piece)) //checks to see if game is won
                    {
                        System.Console.Clear();
                        game.Display();
                        Console.Write("\nPlayer ");
                        Console.Write(player.piece);
                        Console.Write(" has won!\n");
                        Console.WriteLine("\nPress 1 to play again");
                        Console.WriteLine("Press 2 to quit.");
                        if (Console.ReadLine() == "1")
                        {
                            game = new GameBoard();
                        }
                        else
                        {
                            gameLoop = false;
                        }

                }
                else if (game.Full()) //checks for a tie
                    {
                        System.Console.Clear();
                        game.Display();
                        Console.WriteLine("\nIt is a draw.");
                        Console.WriteLine("\nPress 1 to play again");
                        Console.WriteLine("Press 2 to quit.");
                        if (Console.ReadLine() == "1")
                        {
                        game = new GameBoard();
                        }
                        else
                        {
                            gameLoop = false;
                        } 
                    
                    }
                    else  // switches player turn
                    {
                        player = player == player1 ? player2 : player1;
                    }

                
                }

              

           
        }



    }
}
