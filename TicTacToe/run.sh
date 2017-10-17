#!/bin/bash 

#File: run.sh
#Author: Duy Do
#Author's email: duy.ado@fullerton.edu
#Author's Github: https://github.com/DA01171997
#Project: Tic Tac Toe Game
#Purpose: Creating a UI Tic Tac Toe Game. Choose a Player X or O to go first. For new game press New.  
#Date last Modified: 10/17/2017 
#Source Files in this program: TicTacToeframe.cs, TicTacToemain.cs, run.sh
#Compile and execute program by typing ./run.sh in to respective terminal 
echo "***Remove old binary files.***"
rm *.dll
rm *.exe

echo "***View the list of source files.***"
ls -l

echo "***Compile TicTacToeframe.cs to create the file: TicTacToeframe.dll.***"
mcs -target:library -r:System.Windows.Forms.dll -r:System.Drawing.dll -out:TicTacToeframe.dll TicTacToeframe.cs

echo "***Compile TicTacToemain.cs and link previously created dll file to create an executable file.***"
mcs -r:System.Windows.Forms.dll -r:System.Drawing.dll -r:TicTacToeframe.dll -out:TicTacToe.exe TicTacToemain.cs

echo "***View the list of files in the current folder.***"
ls -l

echo "***Run TicTacToe program.***"
./TicTacToe.exe

echo "***The script has terminated.***"