using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Connect_4
{



class GameBoard
{
const int rows = 6, columns = 7;
const char Empty = '0', PLAYER1 = 'X', PLAYER2 = 'O';



private char[,] board;



int Count;




public GameBoard()
{
board = new char[rows, columns];



for (int y = 0; y < rows; y++)
for (int x = 0; x < columns; x++)
board[y, x] = Empty;
}



public void Display()
{
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




public bool DropPiece(char player, int column)
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



public bool connectRow(char player)
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



public bool Full()
{
return Count >= rows * columns;
}
}




/*class Gameboard
{
string[,] board = new string[6, 7]; // represents the values of each space on the board
public Gameboard() // constructs an empty gameboard
{
for (int i = 0; i <= 5; i++)
{
for (int f = 0; f <= 6; f++)
{
board[i, f] = " ";
}
}
}*/






/*internal class Program
{
static void Main(string[] args)
{
Gameboard gameboard = new Gameboard();
gameboard.Display();
Console.ReadKey();
*/



class Program
{
static void Main(string[] args)
{
GameBoard game = new GameBoard();



char player = 'X';
int column;



bool gameLoop = true;
bool inputLoop;



while (gameLoop)
{



System.Console.Clear();
game.Display();



do
{
inputLoop = true;



Console.Write("\nPlayer ");
Console.Write(player);
Console.Write(": ");



if (Int32.TryParse(Console.ReadLine(), out column))
{
if (1 <= column && column <= 7)
{
if (game.DropPiece(player, column))
{
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
Console.WriteLine("\nPlease enter an integer.");
}
} while (inputLoop);



if (game.connectRow(player))
{
System.Console.Clear();
game.Display();
Console.Write("\nPlayer ");
Console.Write(player);
Console.Write(" has won!\n");
Console.WriteLine("\nPress enter to quit.");
gameLoop = false;
}
else if (game.Full())
{
System.Console.Clear();
game.Display();
Console.WriteLine("\nIt is a draw.");
Console.WriteLine("\nPress enter to quit.");
gameLoop = false;
}
else
{
player = player == 'X' ? 'O' : 'X';
}
}



Console.ReadKey();
}



}
}
