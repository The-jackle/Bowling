using System;
using System.Windows.Forms;

namespace Bowling
{
    public partial class frmBowling : Form
    {
        public frmBowling()
        {
            InitializeComponent();
        }

        string[] FrameScore = new string[] { "", "", "", "", "", "", "", "", "", "" };
        string[] TurnScore = new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        int Turn = 0;
        int Frame = 0;
        int LastPoint = 0;
        bool Strike = false;
        bool Spare = false;
        int CountSpare = 0;
        int CountStrike1 = 0;
        int CountStrike2 = 0;
        int CountStrike3 = 0;
        int TotalScore = 0;
        private void btn1_Click(object sender, EventArgs e)
        {//Calls the score procedure and sends the poiint value of the button.
            Add_Score(1);
        }

        public void Disable_Button(int ButtonPress)
        {//Depending on the button press it diables different buttons so that the value cannot be greater than the value of the
         //remaining pins
            switch (ButtonPress)
            {
                case 1:
                    btn9.Enabled = btnStrike.Enabled = false;
                    break;
                case 2:
                    btn9.Enabled = btn8.Enabled = btnStrike.Enabled = false;
                    break;
                case 3:
                    btn9.Enabled = btn8.Enabled = btn7.Enabled = btnStrike.Enabled = false;
                    break;
                case 4:
                    btn9.Enabled = btn8.Enabled = btn7.Enabled = btn6.Enabled = btnStrike.Enabled = false;
                    break;
                case 5:
                    btn9.Enabled = btn8.Enabled = btn7.Enabled = btn6.Enabled = btn5.Enabled = btnStrike.Enabled = false;
                    break;
                case 6:
                    btn9.Enabled = btn8.Enabled = btn7.Enabled = btn6.Enabled = btn5.Enabled = btn4.Enabled = btnStrike.Enabled = false;
                    break;
                case 7:
                    btn9.Enabled = btn8.Enabled = btn7.Enabled = btn6.Enabled = btn5.Enabled = btn4.Enabled = btn3.Enabled = btnStrike.Enabled = false;
                    break;
                case 8:
                    btn9.Enabled = btn8.Enabled = btn7.Enabled = btn6.Enabled = btn5.Enabled = btn4.Enabled = btn3.Enabled = btn2.Enabled = btnStrike.Enabled = false;
                    break;
                case 9:
                    btn9.Enabled = btn8.Enabled = btn7.Enabled = btn6.Enabled = btn5.Enabled = btn4.Enabled = btn3.Enabled = btn2.Enabled = btn1.Enabled = btnStrike.Enabled = false;
                    break;
                case 0:
                    btnStrike.Enabled = false;
                    break;
                case 10:
                    btnSpare.Enabled = false;
                    break;
            }
        }
        public void Add_Score(int ButtonPress)
        {//This determines what value is added to the score first the proc to disable buttons is ran.
            Disable_Button(ButtonPress);
            if (CountStrike1 > 0 || CountStrike2 > 0 || CountStrike3 > 0)
            {//If there has been a strike in the last two turns it will see if this throw was a spare.
                if (Spare == true)
                {//If this throw was a spare and it is before throw 20 it will remove the last throw's score from the previous
                 //frame, else it will remove the proits from the current frame
                    if (Turn < 20)
                    {
                        FrameScore[Frame - 1] = (Convert.ToInt32(FrameScore[Frame - 1]) - LastPoint).ToString();
                        TotalScore = TotalScore - LastPoint;
                    }
                    else
                    {
                        FrameScore[Frame] = (Convert.ToInt32(FrameScore[Frame]) - LastPoint).ToString();
                    }
                }
            }
            if (Turn % 2 == 0)
            {//If there was a spare in the last throw it will add the points to the last frame if tune is below 20, else it will
             //add the points to the current frame
                if (CountSpare > 0 && Turn < 20)
                {
                    CountSpare--;
                    TotalScore = TotalScore + ButtonPress;
                    FrameScore[Frame - 1] = (Convert.ToInt32(FrameScore[Frame - 1]) + ButtonPress).ToString();
                }
                else if (CountSpare > 0 && Turn == 20)
                {
                    CountSpare--;
                    TotalScore = TotalScore + ButtonPress;
                    FrameScore[Frame] = (Convert.ToInt32(FrameScore[Frame]) + ButtonPress).ToString();
                }
            }
            else
            {
                if (CountSpare > 0)
                {//If there was a spare on this throw it will remove the last throws points from current frame
                    TotalScore = TotalScore - LastPoint;
                    FrameScore[Frame - 1] = (Convert.ToInt32(FrameScore[Frame - 1]) - LastPoint).ToString();
                }
            }
            if (Turn >= 2 && Turn < 19)
            {//These steps will only run after frame 1 and before throw 2 and 3 of frame 10.
                if (Turn % 2 != 0 )
                {//this will only run on the first throw of a frame.
                    if (CountStrike1 == 1)
                    {//If the last frame was a strike, but the last throw was not a strike, it will add this throw to the last frame
                        CountStrike1--;
                        TotalScore = TotalScore + ButtonPress;
                        FrameScore[Frame - 1] = (Convert.ToInt32(FrameScore[Frame - 1]) + ButtonPress).ToString();
                    }
                }
                else
                {
                    if (CountStrike1 == 1)
                    {//If this is the second frame after a strike was thrown twice in a row it will add the points of the throw to
                     //the last two frames
                        CountStrike1--;
                        TotalScore = TotalScore + ButtonPress;
                        FrameScore[Frame - 1] = (Convert.ToInt32(FrameScore[Frame - 1]) + ButtonPress).ToString();
                        FrameScore[Frame - 2] = (Convert.ToInt32(FrameScore[Frame - 2]) + ButtonPress).ToString();
                    }
                }
                if (CountStrike1 == 2)
                {//This will add points to the last frame due to a strike
                    CountStrike1--;
                    TotalScore = TotalScore + ButtonPress;
                    FrameScore[Frame - 1] = (Convert.ToInt32(FrameScore[Frame - 1]) + ButtonPress).ToString();
                }
            }
            if (Turn >= 4 && Turn < 19)
            {//These steps will only run after frame 2 and before throw 2 and 3 of frame 10.
                if (Turn % 2 != 0)
                {//this will only run on the first throw of a frame.
                    if (CountStrike2 == 1)
                    {//If the last frame was a strike, but the last throw was not a strike, it will add this throw to the last frame
                        CountStrike2--;
                        TotalScore = TotalScore + ButtonPress;
                        FrameScore[Frame - 1] = (Convert.ToInt32(FrameScore[Frame - 1]) + ButtonPress).ToString();
                    }
                }
                else
                {
                    if (CountStrike2 == 1)
                    {//If this is the second frame after a strike was thrown twice in a row it will add the points of the throw to
                     //the last two frames
                        CountStrike2--;
                        TotalScore = TotalScore + ButtonPress;
                        FrameScore[Frame - 1] = (Convert.ToInt32(FrameScore[Frame - 1]) + ButtonPress).ToString();
                        FrameScore[Frame - 2] = (Convert.ToInt32(FrameScore[Frame - 2]) + ButtonPress).ToString();
                    }
                }
                if (CountStrike2 == 2)
                {//This will add points to the last frame due to a strike
                    CountStrike2--;
                    TotalScore = TotalScore + ButtonPress;
                    FrameScore[Frame - 1] = (Convert.ToInt32(FrameScore[Frame - 1]) + ButtonPress).ToString();
                }
            }
            if (Turn >= 5 && Turn < 19)
            {//These steps will only run after frame 3 and before throw 2 and 3 of frame 10.
                if (Turn % 2 != 0)
                {//this will only run on the first throw of a frame.
                    if (CountStrike3 == 1)
                    {//If the last frame was a strike, but the last throw was not a strike, it will add this throw to the last frame
                        CountStrike3--;
                        TotalScore = TotalScore + ButtonPress;
                        FrameScore[Frame - 1] = (Convert.ToInt32(FrameScore[Frame - 1]) + ButtonPress).ToString();
                    }
                }
                else
                {
                    if (CountStrike3 == 1)
                    {//If this is the second frame after a strike was thrown twice in a row it will add the points of the throw to
                     //the last two frames
                        CountStrike3--;
                        TotalScore = TotalScore + ButtonPress;
                        FrameScore[Frame - 1] = (Convert.ToInt32(FrameScore[Frame - 1]) + ButtonPress).ToString();
                        FrameScore[Frame - 2] = (Convert.ToInt32(FrameScore[Frame - 2]) + ButtonPress).ToString();
                    }
                }
                if (CountStrike3 == 2)
                {//This will add points to the last frame due to a strike
                    CountStrike3--;
                    TotalScore = TotalScore + ButtonPress;
                    FrameScore[Frame - 1] = (Convert.ToInt32(FrameScore[Frame - 1]) + ButtonPress).ToString();
                }
            }
            if (Turn ==19 && (CountStrike1 ==1 || CountStrike2 == 1 || CountStrike3 == 1))
            {//On turn 20 it will add this throws points to this and last frames points if there was a strike thrown last frame
                TotalScore = TotalScore + ButtonPress;
                FrameScore[Frame - 1] = (Convert.ToInt32(FrameScore[Frame - 1]) + ButtonPress).ToString();
                FrameScore[Frame] = (Convert.ToInt32(FrameScore[Frame]) + ButtonPress).ToString();
            }
            if (Turn == 20 && (CountStrike1 >= 1 || CountStrike2 >= 1 || CountStrike3 >= 1))
            {//On turn 21 it will add this throws points to this frames points again if there was a strike thrown on throw 19
                TotalScore = TotalScore + ButtonPress;
                FrameScore[9] = (Convert.ToInt32(FrameScore[9]) + 20).ToString();
            }
            if (Strike == true)
            {//If a strike was thrown it will mark that a strike was thrown on scorecard and track that a strike was thrown
                if (Turn < 18)
                {
                    TurnScore[Turn + 1] = "X";
                }
                else
                {
                    TurnScore[Turn] = "X";
                }
                if (CountStrike1 == 0)
                {
                    CountStrike1 = 2;
                }
                else if (CountStrike2 == 0)
                {
                    CountStrike2 = 2;
                }
                else if (CountStrike3 == 0)
                {
                    CountStrike3 = 2;
                }

            }
            else if (Spare == true)
            {//If spare was thrown it will mark that a spare was thrown while subtracting the last throw
                CountSpare = 1;
                TurnScore[Turn] = "/";
                TotalScore = TotalScore - LastPoint;
            }
            else
            {
                TurnScore[Turn] = ButtonPress.ToString();
                btnSpare.Enabled = true;
            }
            LastPoint = ButtonPress;
            if (Turn < 20)
            {//add points to the total score when before last turn.
                TotalScore = TotalScore + ButtonPress;
            }
            FrameScore[Frame] = TotalScore.ToString();
            Turn++;
            if (Strike == true && Turn < 19)
            {//If a strike was thrown on the first throw of a frame it will skip to the next frame
                Turn++;
            }
            if (Turn == 20 && Spare == true)
            {//Disables the Spare button but allows a strike at the last turn
                btnSpare.Enabled = false;
                btn9.Enabled = btn8.Enabled = btn7.Enabled = btn6.Enabled = btn5.Enabled = btn4.Enabled = btn3.Enabled = btn2.Enabled = btn1.Enabled = btnStrike.Enabled = true;
            }
            if (Turn % 2 == 0 && Turn < 20)
            {//On the first turn of each frame it will set the spare button to false and everything else to true
                Frame++;
                btnSpare.Enabled = false;
                btn9.Enabled = btn8.Enabled = btn7.Enabled = btn6.Enabled = btn5.Enabled = btn4.Enabled = btn3.Enabled = btn2.Enabled = btn1.Enabled = btnStrike.Enabled = true;
            }
            //sets spare and strike to false while also adding points to the score
            Spare = false;
            Strike = false;
            lblFrame1.Text = FrameScore[0];
            lblFrame2.Text = FrameScore[1];
            lblFrame3.Text = FrameScore[2];
            lblFrame4.Text = FrameScore[3];
            lblFrame5.Text = FrameScore[4];
            lblFrame6.Text = FrameScore[5];
            lblFrame7.Text = FrameScore[6];
            lblFrame8.Text = FrameScore[7];
            lblFrame9.Text = FrameScore[8];
            lblFrame10.Text = FrameScore[9];
            lblShot1.Text = TurnScore[0];
            lblShot2.Text = TurnScore[1];
            lblShot3.Text = TurnScore[2];
            lblShot4.Text = TurnScore[3];
            lblShot5.Text = TurnScore[4];
            lblShot6.Text = TurnScore[5];
            lblShot7.Text = TurnScore[6];
            lblShot8.Text = TurnScore[7];
            lblShot9.Text = TurnScore[8];
            lblShot10.Text = TurnScore[9];
            lblShot11.Text = TurnScore[10];
            lblShot12.Text = TurnScore[11];
            lblShot13.Text = TurnScore[12];
            lblShot14.Text = TurnScore[13];
            lblShot15.Text = TurnScore[14];
            lblShot16.Text = TurnScore[15];
            lblShot17.Text = TurnScore[16];
            lblShot18.Text = TurnScore[17];
            lblShot19.Text = TurnScore[18];
            lblShot20.Text = TurnScore[19];
            lblShot21.Text = TurnScore[20];
            if (Turn == 20 && lblShot20.Text != "X" && lblShot20.Text != "/" && lblShot19.Text != "X")
            {//sets the buttons to be disabled if there was no strike or spare on turn 19 and 20
                btnSpare.Enabled = btn0.Enabled =
                btn9.Enabled = btn8.Enabled = btn7.Enabled = btn6.Enabled = btn5.Enabled = btn4.Enabled = btn3.Enabled = btn2.Enabled = btn1.Enabled = btnStrike.Enabled = false;
            }
            if (Turn == 21)
            {//sets the buttons to be disabled on turn 21
                btnSpare.Enabled = btn0.Enabled =
                btn9.Enabled = btn8.Enabled = btn7.Enabled = btn6.Enabled = btn5.Enabled = btn4.Enabled = btn3.Enabled = btn2.Enabled = btn1.Enabled = btnStrike.Enabled = false;
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {//Calls the score procedure and sends the poiint value of the button.
            Add_Score(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {//Calls the score procedure and sends the poiint value of the button.
            Add_Score(3);
        }
        private void btn4_Click(object sender, EventArgs e)
        {//Calls the score procedure and sends the poiint value of the button.
            Add_Score(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {//Calls the score procedure and sends the poiint value of the button.
            Add_Score(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {//Calls the score procedure and sends the poiint value of the button.
            Add_Score(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {//Calls the score procedure and sends the poiint value of the button.
            Add_Score(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {//Calls the score procedure and sends the poiint value of the button.
            Add_Score(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {//Calls the score procedure and sends the poiint value of the button.
            Add_Score(9);
        }

        private void btn0_Click(object sender, EventArgs e)
        {//Calls the score procedure and sends the poiint value of the button.
            Add_Score(0);
        }

        private void btnSpare_Click(object sender, EventArgs e)
        {//Calls the score procedure and sends the poiint value of the button while setting that a spare was made.
            Spare = true;
            Add_Score(10);
        }

        private void btnStrike_Click(object sender, EventArgs e)
        {//Calls the score procedure and sends the poiint value of the button while setting that a strike was made.
            Strike = true;
            Add_Score(10);
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {//Starts a new game by setting everything back to an empty state.
            Frame = Turn =  LastPoint = CountSpare = CountStrike1 = CountStrike2 = CountStrike3 = TotalScore = 0;
            Strike = Spare = btnSpare.Enabled = false;
            lblFrame1.Text = lblFrame2.Text = lblFrame3.Text = lblFrame4.Text = lblFrame5.Text = lblFrame6.Text =
                lblFrame7.Text = lblFrame8.Text = lblFrame9.Text = lblFrame10.Text = lblShot1.Text = lblShot2.Text =
                lblShot3.Text = lblShot4.Text = lblShot5.Text = lblShot6.Text = lblShot7.Text = lblShot8.Text = lblShot9.Text =
                lblShot10.Text = lblShot11.Text = lblShot12.Text = lblShot13.Text = lblShot14.Text = lblShot15.Text = lblShot16.Text =
                lblShot17.Text = lblShot18.Text = lblShot19.Text = lblShot20.Text = lblShot21.Text = "";
            btn9.Enabled = btn8.Enabled = btn7.Enabled = btn6.Enabled = btn5.Enabled = btn4.Enabled = btn3.Enabled = btn2.Enabled = btn1.Enabled = btnStrike.Enabled = btn0.Enabled = true;
            for (int i = 0; i < FrameScore.Length; i++)
            {
                FrameScore[i] = "0";
            }
            for (int i = 0; i < TurnScore.Length; i++)
            {
                TurnScore[i] = "0";
            }
        }
    }
}