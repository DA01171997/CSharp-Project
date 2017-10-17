//File: TrafficLightfame.cs
//Author: Duy Do
//Author's email: duy.ado@fullerton.edu
//Author's Github: https://github.com/DA01171997
//Project: Traffic Light 
//Purpose: Creating a UI Traffic Light with 3 different switching speeds using a timer. *Default Speed = SLOW*
//Date last Modified: 10/17/2017 
//Source Files in this program: TrafficLightframe.cs, TrafficLightmain.cs, run.sh
//Compile and execute program in Bash Shell. Type ./run.sh in to respective directory's terminal. 
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class TrafficLightframe : Form {
	private const int xframe = 600; //UI X's size
	private const int yframe = 600;	//UI Y's size
	private const int pensize = 1;
	private SolidBrush trafficBoxBrush = new SolidBrush(Color.Black);
	private SolidBrush trafficBoxBarBrush = new SolidBrush(Color.Green);
	private SolidBrush trafficBoxLightBrush = new SolidBrush(Color.Silver);
	private RadioButton slowRB  = new System.Windows.Forms.RadioButton();
	private RadioButton mediumRB = new System.Windows.Forms.RadioButton();
	private RadioButton fastRB = new System.Windows.Forms.RadioButton();
	private Button startB = new System.Windows.Forms.Button();
	private Button pauseB = new System.Windows.Forms.Button();
	private Button exitB = new System.Windows.Forms.Button();
	private GroupBox rbBox =  new GroupBox();
	private Point startBL = new Point(410,500);
	private Point pauseBL = new Point(470,500);
	private Point exitBL = new Point(530,500);	
	private Size RadioSize = new System.Drawing.Size(60,20);
	private Size buttonSize = new Size(60,50);
	private int pauseCounter =0;
	private bool rateSC = true;	// rate slow is picked by default 
	private bool rateMC = false;	
	private bool rateFC = false;
	//timer variables
	private static System.Timers.Timer lightClock = new System.Timers.Timer();
	private int lightCounter = 0; 
	private bool redLight = false; 	
	private bool yellowLight = false;
	private bool greenLight = false;
	private SolidBrush trafficLightBrush;
	public TrafficLightframe () {
                // Initialize the UI
		Text = "Traffic Light by Duy Do";
                System.Console.WriteLine("xframe={0}. yframe={1}.", xframe, yframe);
                Size = new Size(xframe,yframe);
                BackColor = Color.White;
		// Initialize Buttons
		startB.Text = "Start";
		startB.Size = buttonSize;
		startB.Location = startBL;
		startB.BackColor = Color.Yellow;
		startB.TabIndex = 0;
		pauseB.Text = "Pause";
		pauseB.Size = buttonSize;
		pauseB.Location = pauseBL;
		pauseB.BackColor = Color.Yellow;
		pauseB.TabIndex = 1;
		exitB.Text = "Exit";
		exitB.Size = buttonSize;
		exitB.Location = exitBL;
		exitB.BackColor = Color.Yellow;
		exitB.TabIndex = 2;
		// Initialize Radio Buttons
		slowRB.Text = "Slow";
		slowRB.Size = RadioSize;
		mediumRB.Text = "Medium";
		mediumRB.Size = RadioSize;
		fastRB.Text = "Fast";	
		fastRB.Size = RadioSize;
		// Initialize Radio Box
		rbBox.Text = "Change of Rate";
		rbBox.Size = new System.Drawing.Size(190,49);
		rbBox.Location = new System.Drawing.Point(195,500);
		rbBox.BackColor = Color.Yellow;
		
		//Add Buttons to frame
		Controls.Add(startB);
		Controls.Add(pauseB);
		Controls.Add(exitB);
		rbBox.Controls.Add(slowRB);
		slowRB.Location = new System.Drawing.Point(1,25);
		rbBox.Controls.Add(mediumRB);
		mediumRB.Location = new System.Drawing.Point(62,25);
		rbBox.Controls.Add(fastRB);
		fastRB.Location = new System.Drawing.Point(135,25);
		Controls.Add(rbBox);
		// Add live handlers to UI
		startB.Click += new EventHandler(startBP);
		pauseB.Click += new EventHandler(pauseBP);
		exitB.Click += new EventHandler(exitBP);
		slowRB.Click += new EventHandler(rateS);
		mediumRB.Click += new EventHandler(rateM);
		fastRB.Click += new EventHandler(rateF);
		
		// add traffic clock to UI
		lightClock.Enabled = false; //disable timer
		lightClock.Elapsed += new ElapsedEventHandler(lightControl);
		lightClock.Interval = 1; //arbitary initial time
		lightClock.Stop();

        }
	protected void lightControl(System.Object sender, ElapsedEventArgs evt) {
		switch(lightCounter) {
			case 0: //case 0 for red light
				if (rateSC) {lightClock.Interval = (int)4000;}	//red light slow speed-4seconds
				if (rateMC) {lightClock.Interval = (int)2000;}	//red light medium speed-2seconds
				if (rateFC) {lightClock.Interval = (int)1000;}	//red light fast speed-1second
				trafficLightBrush = new SolidBrush(System.Drawing.Color.Red); //make red brush
				redLight = true;	//red light ON
				yellowLight = false;	//yellow light OFF
				greenLight = false;	//green Light OFF
				break;
			case 1: //case 1 for yellow light
				if (rateSC) {lightClock.Interval = (int)1000;}	//yellow light slow speed-1seconds
				if (rateMC) {lightClock.Interval = (int)500;}	//yellow light medium speed-0.50seconds
				if (rateFC) {lightClock.Interval = (int)250;}	//yellow light fast speed-0.25seconds
				trafficLightBrush = new SolidBrush(System.Drawing.Color.Yellow); //make yellow brush
				redLight = false;	//red light OFF
				yellowLight = true;	//yellow light ON
				greenLight = false;	//green light OFF			
				break;
			case 2: // case 2 for green light 
				if (rateSC) {lightClock.Interval = (int)3000;}	//green light slow speed-3seconds
				if (rateMC) {lightClock.Interval = (int)1500;}	//green light medium speed-1.5seconds
				if (rateFC) {lightClock.Interval = (int)750;}	//green light fase speed-0.75seconds
				trafficLightBrush = new SolidBrush(System.Drawing.Color.Green); //make green light brush
				redLight = false;	//red light OFF
				yellowLight = false;	//yellow light OFF
				greenLight = true;	//green light ON	
				break;
		}
		lightCounter = (lightCounter+1)%3;	//light loop mechanic 
		Invalidate();
	}

	protected void startBP(Object sender, EventArgs events) {
		System.Console.WriteLine("Start");
		lightClock.Enabled = true;	//enable timer
		lightClock.Start();		//start timer
		Invalidate();
	}	
	protected void pauseBP(Object sender, EventArgs events) {
		if((pauseCounter%2)==0) { // change button to resume when pause is pressed
		System.Console.WriteLine("Pause");		
		lightClock.Stop();	//pause the timer 
		pauseB.Text = "Resume"; //change Pause -> Resume
		}
		else { // change button to  pause when resume is pressed
		System.Console.WriteLine("Resume");	
		lightClock.Start();	//resume the timer
		pauseB.Text = "Pause";	//change Resume ->
		}
		pauseCounter++;		//update counter
	}
	protected void exitBP(Object sender, EventArgs events) {
	System.Console.WriteLine("Exit");
	Close(); //exit
	}
	protected void rateS(Object sender, EventArgs events) {
		System.Console.WriteLine("Slow");		
		rateSC = true; // rate slow is picked
		rateMC = false;
		rateFC = false;
		Invalidate();	
	}
	protected void rateM(Object sender, EventArgs events) {
		System.Console.WriteLine("Slow");		
		rateSC = false;
		rateMC = true; //rate medium is picked
		rateFC = false;
		Invalidate();	
	}
	protected void rateF(Object sender, EventArgs events) {
		System.Console.WriteLine("Slow");
		rateSC = false;
		rateMC = false;
		rateFC = true; //rate fast is picked
		Invalidate();	
	}
		
	protected override void OnPaint(PaintEventArgs light) {
		Graphics DuyLight = light.Graphics;
		//Draw traffic light box 
		DuyLight.FillRectangle(trafficBoxBrush, 225, 25, 150,450);	//box
		DuyLight.FillRectangle(trafficBoxBarBrush, 225, 25, 150,35);	//top margin
		DuyLight.FillRectangle(trafficBoxBarBrush, 225, 440, 150,35);	//bottom margin	
		DuyLight.FillEllipse(trafficBoxLightBrush, 250,75, 100,100); 	//OFF red light
  		DuyLight.FillEllipse(trafficBoxLightBrush, 250, 200, 100,100);	//OFF yellow Light
		DuyLight.FillEllipse(trafficBoxLightBrush, 250, 325, 100,100);	//OFF green light
		//		
		if(redLight) {
		DuyLight.FillEllipse(trafficLightBrush, 250,75, 100,100);	//ON red light
  		}
		if(yellowLight) {
		DuyLight.FillEllipse(trafficLightBrush, 250, 200, 100,100);	//ON yellow light
		}
		if(greenLight) {
		DuyLight.FillEllipse(trafficLightBrush, 250, 325, 100,100);	//ON green light
		}

	}
	
}
