//File: TicTacToemain.cs
//Author: Duy Do
//Author's email: duy.ado@fullerton.edu
//Author's Github: https://github.com/DA01171997
//Project: Tic Tac Toe Game
//Purpose: Creating a UI Tic Tac Toe Game. Choose a Player X or O to go first. For new game press New.  
//Date last Modified: 10/17/2017 
//Source Files in this program: TicTacToeframe.cs, TicTacToemain.cs, run.sh
//Compile and execute program by typing ./run.sh in to respective terminal 
using System;
using System.Windows.Forms;
public class TicTacToemain {
	public static void Main() {
	System.Console.WriteLine("The TicTacToe game will begin now.");
	TicTacToeframe gameapplication = new TicTacToeframe();
	Application.Run(gameapplication);
	System.Console.WriteLine("The TicTacToe game has ended. Bye.");
	}
}