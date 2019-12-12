using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LCCalcApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculator : ContentPage
    {
        private int score = 0;
        private bool HigherLevelMaths;
        private int[] SixHighestScores = new int[6];
        private int subjects = 0;

        private bool isOrdinaryLevel = false;

        public Calculator()
        {
            InitializeComponent();
            //by default, set all the ordinary buttons to hidden (so that only the HL ones show up
            O1Button.IsVisible = false;
            O2Button.IsVisible = false;
            O3Button.IsVisible = false;
            O4Button.IsVisible = false;
            O5Button.IsVisible = false;
            O6Button.IsVisible = false;
            O7Button.IsVisible = false;
            O8Button.IsVisible = false;
        }

        //getters and setters for the score and HL maths boolean
        public int GetScore()
        {
            return score;
        }

        public void SetScore(int inputScore)
        {
            score = inputScore;
            //change the label's text to display the updated score
            ScoreLabel.Text = "Score: " + score;
        }

        public bool GetHLMaths()
        {
            return HigherLevelMaths;
        }

        public void SetHLMaths(bool inputHLMaths)
        {
            HigherLevelMaths = inputHLMaths;
            if (HigherLevelMaths)
            {
                HLMathsLabel.Text = "+25 because taking HL Maths";
            }
            else
            {
                HLMathsLabel.Text = "";
            }
        }
        //End of Getters and Setters

        //When any of the H1 to H8 or O1 to O8 buttons get clicked...
        //Find the minimum score and replace it with this value (if it is larger)
        private void Button_Clicked(object sender, EventArgs e)
        {
            int newScore = score;
            int thisScore = 0;
            Button button = sender as Button;
            subjects++;
            SubjectsLabel.Text = "Subjects: " + subjects;

            switch (button.ClassId)
            {
                case "H1":
                    thisScore = 100;
                    break;
                case "H2":
                    thisScore = 88;
                    break;
                case "H3":
                    thisScore = 77;
                    break;
                case "H4":
                    thisScore = 66;
                    break;
                case "H5":
                    thisScore = 56;
                    break;
                case "H6":
                    thisScore = 46;
                    break;
                case "H7":
                    thisScore = 37;
                    break;
                case "H8":
                    thisScore = 0;
                    break;

                case "O1":
                    thisScore = 56;
                    break;
                case "O2":
                    thisScore = 46;
                    break;
                case "O3":
                    thisScore = 37;
                    break;
                case "O4":
                    thisScore = 28;
                    break;
                case "O5":
                    thisScore = 20;
                    break;
                case "O6":
                    thisScore = 12;
                    break;
                case "O7":
                    thisScore = 0;
                    break;
                case "O8":
                    thisScore = 0;
                    break;
                default:
                    thisScore = 0;
                    break;
            }

            int minimumScoreIndex = GetIndexOfMinimumScore();
            int minScoreValue = SixHighestScores[minimumScoreIndex];
            //if it is larger than the minimum that we have, replace the minimum with this grade
            if (thisScore > minScoreValue)
            {
                newScore -= minScoreValue;
                newScore += thisScore;
                SixHighestScores[minimumScoreIndex] = thisScore;
            }
            SetScore(newScore);
        }

        public int GetIndexOfMinimumScore()
        {
            int currentMinimum = 101;
            int index = 0;
            for (int i = 0; i < 6; i++)
            {
                if (SixHighestScores[i] < currentMinimum)
                {
                    currentMinimum = SixHighestScores[i];
                    index = i;
                }
            }
            return index;
        }

        //a switch to display the Higher buttons and hide the ordinary and vice versa
        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            isOrdinaryLevel = !isOrdinaryLevel;
            if (isOrdinaryLevel)
            {
                //hide all the higher level buttons and display the ordinary level ones
                H1Button.IsVisible = false;
                H2Button.IsVisible = false;
                H3Button.IsVisible = false;
                H4Button.IsVisible = false;
                H5Button.IsVisible = false;
                H6Button.IsVisible = false;
                H7Button.IsVisible = false;
                H8Button.IsVisible = false;

                O1Button.IsVisible = true;
                O2Button.IsVisible = true;
                O3Button.IsVisible = true;
                O4Button.IsVisible = true;
                O5Button.IsVisible = true;
                O6Button.IsVisible = true;
                O7Button.IsVisible = true;
                O8Button.IsVisible = true;

            }
            else
            {
                //Display the higher level buttons and hide the Ordinary level ones
                H1Button.IsVisible = true;
                H2Button.IsVisible = true;
                H3Button.IsVisible = true;
                H4Button.IsVisible = true;
                H5Button.IsVisible = true;
                H6Button.IsVisible = true;
                H7Button.IsVisible = true;
                H8Button.IsVisible = true;

                O1Button.IsVisible = false;
                O2Button.IsVisible = false;
                O3Button.IsVisible = false;
                O4Button.IsVisible = false;
                O5Button.IsVisible = false;
                O6Button.IsVisible = false;
                O7Button.IsVisible = false;
                O8Button.IsVisible = false;
            }

        }

        private void Home_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}