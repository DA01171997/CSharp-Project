//File: TicTacToeframe.cs
//Author: Duy Do
//Author's email: duy.ado@fullerton.edu
//Author's Github: https://github.com/DA01171997
//Project: Tic Tac Toe Game
//Purpose: Creating a UI Tic Tac Toe Game. Choose a Player X or O to go first. For new game press New.  
//Date last Modified: 10/17/2017 
//Source Files in this program: TicTacToeframe.cs, TicTacToemain.cs, run.sh
//Compile and execute program by typing ./run.sh in to respective terminal 

using System;
using System.Drawing;
using System.Windows.Forms;


public class TicTacToeframe : Form {
	//Making The UI
	private const int widthUI = 960; //UI X coord
	private const int heightUI = 540; // UI Y coor	
	private const int marginVX = 320; // boxes divider 
	private const int marginVY = 0; // boxes divider 
	private const int marginHX = 0; // boxes divider 
	private const int marginHY = 134; // boxes divider 
	private const int marginHE = 402; // boxes divider 
	private const int XXL = 93; //shapes coord 
	private const int XYL = 0; //shapes coord 
	private const int XXR = 227; //shapes coord 
	private const int XYR = 134; //shapes coord 
	private int mX = 0; // mouse coord
	private int mY = 0; // mouse coord
	private int tempNum = 0; // temp checks win value 
	private int turnCounter =0; // counter determnes turn
	private int tempSum = 0; // counter determines winner
	private bool xFirst = false; // X player 
 	private bool oFirst = false; // O player
	private bool xWin = false; // X win
	private bool oWin = false; // O win
	private bool noWin = false; // no win 
	private String sMessage = "Winner is "; // string for winner message
	private String lMessage;
	private int [,] mark = new int [3,3]; // array for value of shape 
	private bool availR1C1 = true; //current box availibility to changes
	private bool availR1C2 = true; //current box availibility to changes
	private bool availR1C3 = true; //current box availibility to changes
	private bool availR2C1 = true; //current box availibility to changes
	private bool availR2C2 = true; //current box availibility to changes
	private bool availR2C3 = true; //current box availibility to changes
	private bool availR3C1 = true; //current box availibility to changes
	private bool availR3C2 = true; //current box availibility to changes
	private bool availR3C3 = true; //current box availibility to changes
	
	//Drawing variables
	private const int dpen = 4; // size pen
	private Pen marginPen = new Pen(Color.Black, dpen); // black margin 
	private Pen marginPenX = new Pen(Color.Blue, dpen); // blue X
	private Pen marginPenO = new Pen(Color.Red, dpen); // red O
	//Buttons for User
	private Button gameB = new Button(); // new game button
	private Button exitB = new Button(); // exit game button
	private RadioButton XB = new System.Windows.Forms.RadioButton(); // x radio button
	private RadioButton OB = new System.Windows.Forms.RadioButton(); // o radio button
	private GroupBox groupBox = new GroupBox(); // groupbox for radio button
	//Locations 
	private Point locationMessage = new Point(200, 450);
	//Location of userB
	private Point locateGameB = new Point(790,450);
	private Point locateExitB = new Point(850,450);
	private Font writingStyle= new System.Drawing.Font("Arial",16,FontStyle.Bold); 
	private Brush writingPen = new SolidBrush(System.Drawing.Color.Black);
	
	//***CONSTRUCTOR 
	public TicTacToeframe() {	
	//UI Title
	Text = "Tic Tac Toe by Duy Do";
	System.Console.WriteLine("widthUI {0}. heighUI = {1}", widthUI, heightUI);
	//Initialize size for UI
	Size = new Size(widthUI, heightUI);
	//Set Background color for form
	BackColor = Color.White;
	
		//Initialize UserB
	gameB.Text = "New Game";
	gameB.Size = new Size(60,26);
	gameB.Location = locateGameB;
	gameB.BackColor = Color.White;
	exitB.Text = "Exit";
	exitB.Size = new Size(60, 26);
	exitB.Location = locateExitB;
	exitB.BackColor = Color.White;
	// Radio B +  groupbox
	XB.Text = "X:";
	XB.Size = new System.Drawing.Size(29,16);
	OB.Text = "O:";
	OB.Size = new System.Drawing.Size(29,16);
	groupBox.Text = "Who's First?";
	groupBox.Size = new System.Drawing.Size(120, 36);
	groupBox.Location = new System.Drawing.Point(650,445);
	groupBox.BackColor = Color.Yellow;
	//Radio Button
	groupBox.Controls.Add(XB);
	XB.Location = new System.Drawing.Point(25,15);
	groupBox.Controls.Add(OB);
	OB.Location = new System.Drawing.Point(65,15);
	//Controls
	Controls.Add(gameB);
	Controls.Add(exitB);
	Controls.Add(groupBox);
	//Click 
	gameB.Click += new EventHandler(newGame);
	exitB.Click += new EventHandler(exitGame);
	XB.Click += new EventHandler(xPlayer);
	OB.Click += new EventHandler(oPlayer);
	groupBox.Click += new EventHandler(boxFunc);
	//Initialize the array 
	for (int r = 0; r < 3; r++) {         // setting 0 for shape box. 0 means no shape
		for (int c = 0; c <3; c++) {
			mark[r,c] = 0;
		} 
	}	
	
	}
	
	protected override void OnPaint(PaintEventArgs game) {
		Graphics Duygame = game.Graphics;
		
		//Game Box Margins
		Duygame.DrawLine(marginPen, marginVX, marginVY, marginVX, marginHE);            // drawing the margin for boxes 
		Duygame.DrawLine(marginPen, marginVX+320, marginVY, marginVX+320, marginHE);
		Duygame.DrawLine(marginPen, marginHX, marginHY, marginHX+959, marginHY);
		Duygame.DrawLine(marginPen, marginHX, marginHY+134, marginHX+959, marginHY+134);
		Duygame.DrawLine(marginPen, marginHX, marginHE, widthUI, marginHE);
		Duygame.FillRectangle(Brushes.Yellow, marginHX, marginHE+1, widthUI, heightUI);
		
				//Draw X Row1                        // if value is of array box  = 2 than draw X 
				if (mark[0,0] == 2 ) {
				Duygame.DrawLine(marginPenX, XXL, XYL, XXR, XYR);
				Duygame.DrawLine(marginPenX, XXR, XYL, XXL, XYR); 
				}
				if (mark[0,1] == 2 ) {	
				Duygame.DrawLine(marginPenX, XXL+marginVX, XYL, XXR+marginVX, XYR);
				Duygame.DrawLine(marginPenX, XXR+marginVX, XYL, XXL+marginVX, XYR);
				}
				if (mark[0,2] == 2 ) {	
				Duygame.DrawLine(marginPenX, XXL+marginVX*2, XYL, XXR+marginVX*2, XYR);
				Duygame.DrawLine(marginPenX, XXR+marginVX*2, XYL, XXL+marginVX*2, XYR);  
				}
				//Draw X Row2			    // if value is of array box  = 2 than draw X 
				if (mark[1,0] == 2 ) {
				Duygame.DrawLine(marginPenX, XXL, XYL+marginHY, XXR, XYR+marginHY);
				Duygame.DrawLine(marginPenX, XXR, XYL+marginHY, XXL, XYR+marginHY); 
				}
				if (mark[1,1] == 2 ) {
				Duygame.DrawLine(marginPenX, XXL+marginVX, XYL+marginHY, XXR+marginVX, XYR+marginHY);
				Duygame.DrawLine(marginPenX, XXR+marginVX, XYL+marginHY, XXL+marginVX, XYR+marginHY);
				}			
				if (mark[1,2] == 2 ) {
				Duygame.DrawLine(marginPenX, XXL+marginVX*2, XYL+marginHY, XXR+marginVX*2, XYR+marginHY);
				Duygame.DrawLine(marginPenX, XXR+marginVX*2, XYL+marginHY, XXL+marginVX*2, XYR+marginHY);
				}
				//Draw X Row3			    // if value is of array box  = 2 than draw X 
				if (mark[2,0] == 2 ) {
				Duygame.DrawLine(marginPenX, XXL, XYL+marginHY*2, XXR, XYR+marginHY*2);
				Duygame.DrawLine(marginPenX, XXR, XYL+marginHY*2, XXL, XYR+marginHY*2); 
				}
				if (mark[2,1] == 2 ) {
				Duygame.DrawLine(marginPenX, XXL+marginVX, XYL+marginHY*2, XXR+marginVX, XYR+marginHY*2);
				Duygame.DrawLine(marginPenX, XXR+marginVX, XYL+marginHY*2, XXL+marginVX, XYR+marginHY*2);
				}
				if (mark[2,2] == 2 ) {
				Duygame.DrawLine(marginPenX, XXL+marginVX*2, XYL+marginHY*2, XXR+marginVX*2, XYR+marginHY*2);
				Duygame.DrawLine(marginPenX, XXR+marginVX*2, XYL+marginHY*2, XXL+marginVX*2, XYR+marginHY*2); 
				} 
				//Draw O Row1                   // if value is of array box  = 5 than draw O 
				if (mark[0,0] == 5 ) {
				Duygame.DrawEllipse(marginPenO,XXL,XYL, marginHY, marginHY); 
				}
				if (mark[0,1] == 5 ) {
				Duygame.DrawEllipse(marginPenO,XXL+marginVX,XYL, marginHY, marginHY);
				}
				if (mark[0,2] == 5 ) {
				Duygame.DrawEllipse(marginPenO,XXL+marginVX*2,XYL, marginHY, marginHY);
				}
				//Draw 0 Row2			// if value is of array box  = 5 than draw O
				if (mark[1,0] == 5 ) {
				Duygame.DrawEllipse(marginPenO,XXL,XYL+marginHY, marginHY, marginHY); 
				}
				if (mark[1,1] == 5 ) {
				Duygame.DrawEllipse(marginPenO,XXL+marginVX,XYL+marginHY, marginHY, marginHY);
				}
				if (mark[1,2] == 5 ) {
				Duygame.DrawEllipse(marginPenO,XXL+marginVX*2,XYL+marginHY, marginHY, marginHY);
				}
				//Draw 0 Row3			// if value is of array box  = 5 than draw O
				if (mark[2,0] == 5 ) {
				Duygame.DrawEllipse(marginPenO,XXL,XYL+marginHY*2, marginHY, marginHY); 
				}
				if (mark[2,1] == 5 ) {
				Duygame.DrawEllipse(marginPenO,XXL+marginVX,XYL+marginHY*2, marginHY, marginHY);
				}
				if (mark[2,2] == 5 ) {
				Duygame.DrawEllipse(marginPenO,XXL+marginVX*2,XYL+marginHY*2, marginHY, marginHY);
				}
			
		if (xWin) {     // messages when X Wins
			lMessage = sMessage + "X Player. Press New Game";
			Duygame.DrawString(lMessage, writingStyle, writingPen, locationMessage);
		}
		if (oWin) {	// messages when O Wins
			lMessage = sMessage + "O Player. Press New Game";
			Duygame.DrawString(lMessage, writingStyle, writingPen, locationMessage);
		}
		if (noWin) {	// messages when NO Wins
			lMessage = "No Winner. Press New Game";
			Duygame.DrawString(lMessage, writingStyle, writingPen, locationMessage);
		}
		base.OnPaint(game);
	}
	//Game Buttons Functions
	protected void newGame(Object sender, EventArgs events) {
	//reseting all the value 
	xFirst = false;
	oFirst = false;
	xWin = false;
	oWin = false;
	noWin = false;
	XB.Enabled = true;
	OB.Enabled = true;
	XB.Checked = false;
	OB.Checked = false;
	turnCounter = 0;
	tempNum = 0;
	availR1C1 = true;
	availR1C2 = true;
	availR1C3 = true;
	availR2C1 = true;
	availR2C2 = true;
	availR2C3 = true;
	availR3C1 = true;
	availR3C2 = true;
	availR3C3 = true;
	for (int r = 0; r < 3; r++) {  // reinitializing box shape to 0
		for (int c = 0; c <3; c++) {
			mark[r,c] = 0;
		} 
	}	
	System.Console.WriteLine("You Pressed New Game.");
	Invalidate ();	
	}
	protected void exitGame(Object sender, EventArgs events) {
	System.Console.WriteLine("Exit Game");
	Close(); // exit game
	}
	protected void xPlayer(Object sender, EventArgs events) {
	xFirst = true; // X player first
	oFirst = false;
	XB.Enabled = false; // Disable radio button
	OB.Enabled = false; // Disable radio button
	turnCounter =0;
	
	System.Console.WriteLine("You Pressed X");
	}
	protected void oPlayer(Object sender, EventArgs events) {
	oFirst = true; // O player first
	xFirst = false;
	XB.Enabled = false; // Disable radio button
	OB.Enabled = false; // Disable radio button
	turnCounter =0;
	
	System.Console.WriteLine("You Pressed O");
	}
	protected void boxFunc(Object sender, EventArgs events) {} // nothing happens 
	protected override void OnMouseDown(MouseEventArgs uMouse) {
	mX = uMouse.X; // getting x coord
	mY = uMouse.Y; // getting y coord
	if ((!xWin)&&(!oWin)) { // if no winner yet, game begins
	if (xFirst) { // X will be first shape
		if (turnCounter%2==0) {
		tempNum = 2;
		}
		else if (turnCounter%2!=0) {
		tempNum = 5;		
		}
	drawMark(mX, mY, tempNum); // adding shape's value to shape box array
	}
	if (oFirst) { // Y will be first shape
		if (turnCounter%2==0) {
		tempNum = 5;
		}
		else if (turnCounter%2!=0) {
		tempNum = 2;		
		}
	drawMark(mX, mY, tempNum); // adding shape's value to shape box array
	}
	}
	Invalidate();
	}
	protected void drawMark (int x, int y, int num) { // funtion that take user in mouse input and put respective value for shape in array. 2==X 5==O
		//R1C1
	if (((x >= 0)&&(x < marginVX))&&((y >= 0)&&(y < marginHY))&&(availR1C1)) {
	mark[0,0] = num;
	availR1C1 = false;				// lock the changed shape
	System.Console.WriteLine("R1C1--num is: " + num.ToString());
	turnCounter++;	                                // update turncounter
	System.Console.WriteLine("Num Counter ++");
	}
	//R1C2
	if (((x >= marginVX)&&(x < marginVX*2-1))&&((y >= 0)&&(y < marginHY))&&(availR1C2)){
	mark[0,1] = num;
	availR1C2 = false;				// lock the changed shape
	System.Console.WriteLine("R1C2--num is: " + num.ToString());
	turnCounter++;					// update turn counter
	System.Console.WriteLine("Num Counter ++");	
	}
	//R1C3
	if (((x >=marginVX*2)&&(x < marginVX*3-1))&&((y >=0)&&(y < marginHY))&&(availR1C3)) {
	mark[0,2] = num;		
	availR1C3 = false;				// lock the changed shape
	System.Console.WriteLine("R1C3--num is: " + num.ToString());
	turnCounter++;					//update turn counter 
	System.Console.WriteLine("Num Counter ++");	
	}
		//R2C1
	if (((x >= 0)&&(x < marginVX))&&((y >= marginHY)&&(y < marginHY*2-1))&&(availR2C1)) {
	mark[1,0] = num;
	availR2C1 = false;;				// lock the changed shape
	System.Console.WriteLine("R2C1--num is: " + num.ToString());
	turnCounter++;					// update turn counter
	System.Console.WriteLine("Num Counter ++");	
	}
	//R2C2
	if (((x >=marginVX)&&(x < marginVX*2-1))&&((y >= marginHY)&&(y < marginHY*2-1))&&(availR2C2)) {
	mark[1,1] = num;
	availR2C2 = false;				// lock the changed shape
	System.Console.WriteLine("R2C2--num is: " + num.ToString());
	turnCounter++;					// update turn counter
	System.Console.WriteLine("Num Counter ++");	
	}
	//R2C3
	if (((x > marginVX*2)&&(x < marginVX*3-1))&&((y >= marginHY)&&(y < marginHY*2-1))&&(availR2C3)) {
	mark[1,2] = num;
	availR2C3 = false;				// lock the changed shape
	System.Console.WriteLine("R2C3--num is: " + num.ToString());
	turnCounter++;					// update turn counter
	System.Console.WriteLine("Num Counter ++");	
	}
		//R3C1
	if (((x >=0)&&(x < marginVX))&&((y >= marginHY*2)&&(y < marginHE))&&(availR3C1)) {
	mark[2,0] = num;
	availR3C1 = false;				//  lock the changed shape
	System.Console.WriteLine("R3C1--num is: " + num.ToString());
	turnCounter++;					// update turn counter
	System.Console.WriteLine("Num Counter ++");	
	}
	//R3C2
	if (((x >= marginVX)&&(x < marginVX*2-1))&&((y >= marginHY*2)&&(y < marginHE))&&(availR3C2)) {
	mark[2,1] = num;
	availR3C2 = false;				// lock the changed shape
	System.Console.WriteLine("R3C2--num is: " + num.ToString());
	turnCounter++;					// update turn counter
	System.Console.WriteLine("Num Counter ++");	
	}
	//R3C3
	if (((x >= marginVX*2)&&(x < marginVX*3-1))&&((y >= marginHY*2)&&(y < marginHE))&&(availR3C3)) {
	mark[2,2] = num;
	availR3C3 = false;				// lock the changed shape
	System.Console.WriteLine("R3C3--num is: " + num.ToString());
	turnCounter++;					// update turn counter 
	System.Console.WriteLine("Num Counter ++");	
	}
	System.Console.WriteLine(turnCounter.ToString());
	System.Console.WriteLine("drawMark was called");
	WinCheck();
	}
	protected void WinCheck() {                                	 
		for ( int r = 0; r < 3; r++) {
			for ( int c = 0; c < 3; c++) {			// check value for winner from rows
				tempSum+=mark[r,c];
				if (tempSum == 6) {			// check value for winner value == 6(2*2*2) X wins
					xWin = true;
					Invalidate();
				System.Console.WriteLine("X Win");
					
				}		
				if (tempSum == 15) {			// check value for winner value == 15(5*5*5) O wins
					oWin = true;
					Invalidate();
				System.Console.WriteLine("O Win");
				}
			}
			tempSum = 0;					// reset sum counter
		}
		for ( int c = 0; c < 3; c++) {				// check value for winner from columns
			for ( int r = 0; r < 3; r++) {
				tempSum+=mark[r,c];
				if (tempSum == 6) {			// check value for winner value == 6(2*2*2) X wins
					xWin = true;
					Invalidate();
				System.Console.WriteLine("X Win");
				}		
				if (tempSum == 15) {			// check value for winner value == 15(5*5*5) O wins
					oWin = true;	
					Invalidate();	
				System.Console.WriteLine("O Win");
				}
			}
			tempSum = 0;					// reset sum counter
		}
		if((tempSum+mark[0,0]+mark[1,1]+mark[2,2]) == 6) {     	// check 01 11 22 diagnols for  x winner 
			xWin = true;
			Invalidate();
			System.Console.WriteLine("X Win");
		}
		if((tempSum+mark[0,0]+mark[1,1]+mark[2,2]) == 15) {	// check 01 11 22 diagnols for  O winner
			oWin = true;
			Invalidate();
			System.Console.WriteLine("O Win");
		}
		if((tempSum+mark[0,2]+mark[1,1]+mark[2,0]) == 6) {	// check 02 11 20 diagnols for  x winner
			xWin = true;
			Invalidate();
			System.Console.WriteLine("X Win");
		}
		if((tempSum+mark[0,2]+mark[1,1]+mark[2,0]) == 15) {	// check 02 11 20 diagnols for  O winner
			oWin = true;
			Invalidate();
			System.Console.WriteLine("O Win");
		}
		if (turnCounter == 9&&(!oWin)&&(!xWin)) {					// Check for no winner 
			noWin = true;
			Invalidate();
			System.Console.WriteLine("No Win");
		}
		System.Console.WriteLine("checkWin");
	}


}

