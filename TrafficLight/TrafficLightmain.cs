//File: TrafficLightmain.cs
//Author: Duy Do
//Author's email: duy.ado@fullerton.edu
//Author's Github: https://github.com/DA01171997
//Project: Traffic Light 
//Purpose: Creating a UI Traffic Light with 3 different switching speeds using a timer. Default Speed = SLOW*
//Date last Modified: 10/17/2017 
//Source Files in this program: TrafficLightframe.cs, TrafficLightmain.cs, run.sh
//Compile and execute program in Bash Shell. Type ./run.sh in to respective directory's terminal.

using System;
using System.Drawing;
using System.Windows.Forms;
public class TrafficLightmain {
	public static void Main() {
	System.Console.WriteLine("Traffic Light program starts.");
	TrafficLightframe trafficlight = new TrafficLightframe();
	Application.Run(trafficlight);
	System.Console.WriteLine("Traffic Light program has ended");
	}
}
