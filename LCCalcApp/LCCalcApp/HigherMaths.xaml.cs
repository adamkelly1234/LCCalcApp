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
    public partial class HigherMaths : ContentPage
    {
        public HigherMaths()
        {
            InitializeComponent();
        }

        private void YesButtonClicked(object sender, EventArgs e)
        {
            Calculator calc = new Calculator();
            calc.SetHLMaths(true);
            calc.SetScore(25);
            Navigation.PushAsync(calc);
        }

        private void NoButtonClicked(object sender, EventArgs e)
        {
            Calculator calc = new Calculator();
            calc.SetHLMaths(false);
            calc.SetScore(0);
            Navigation.PushAsync(calc);
        }
    }
}