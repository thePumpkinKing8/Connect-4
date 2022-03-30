using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
   public virtual class player1{
        char 'x';
       public  void OnClick(){
        
       }
    }
      public override class player2{
        char 'o';
           public  void OnClick(){
        
       }
    }
    

    class Gameboard
    { 
        string[,] board = new string[6,7]; // represents the  values of each space on the board
        public Gameboard() // constructs an empty gameboard
        {
            for(int i=0;i<=5;i++)
            {
                for (int f = 0; f <= 6; f++)
                {
                    board[i,f] = " ";
                }
            }
        }

        public void Display()  // displays the board and game UI
        {
            Console.WriteLine("  1    2    3    4    5    6    7");
            for (int i = 0; i <= 5; i++)
            {
                for (int f = 0; f <= 6; f++)
                {
                    
                    Console.Write(" [" + board[i, f] + "] ");
                }
                Console.Write("\n \n");
                
            }
            return;
        }

    }

    
    internal class Program
    {
        static void Main(string[] args)
        {
            Gameboard gameboard = new Gameboard();
            gameboard.Display();
            Console.ReadKey();
            
        }
    }
}
