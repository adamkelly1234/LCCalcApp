using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LCCalcApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void ButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            
            Navigation.PushAsync(new HigherMaths());
        }
    }
}

