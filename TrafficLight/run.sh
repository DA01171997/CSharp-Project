#!/bin/bash

#File: run.sh
#Author: Duy Do
#Author's email: duy.ado@fullerton.edu
#Author's Github: https://github.com/DA01171997
#Project: Traffic Light 
#Purpose: Creating a UI Traffic Light with 3 different switching speeds using a timer. Default Speed = SLOW*
#Date last Modified: 10/17/2017 
#Source Files in this program: TrafficLightframe.cs, TrafficLightmain.cs, run.sh
#Compile and execute program in Bash Shell. Type ./run.sh in to respective directory's terminal.


echo "***Remove old binary files.***"
rm *.dll
rm *.exe

echo "***View the list of source files.***"
ls -l

echo "***Compile TrafficLightframe.cs to create the file: TrafficLightframe.dll.***"
mcs -target:library -r:System.Windows.Forms.dll -r:System.Drawing.dll -out:TrafficLightframe.dll TrafficLightframe.cs

echo "***Compile TrafficLightmain.cs and link previously created dll file to create an executable file.***"
mcs -r:System.Windows.Forms.dll -r:System.Drawing.dll -r:TrafficLightframe.dll -out:TrafficLight.exe TrafficLightmain.cs

echo "***View the list of files in the current folder.***"
ls -l

echo "***Run TrafficLight program.***"
./TrafficLight.exe

echo "***The script has terminated.***"

