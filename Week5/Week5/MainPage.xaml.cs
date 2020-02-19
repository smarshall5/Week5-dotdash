using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Week5
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        string entryText = "";
        string outText = "";
         void ClickOnDot(object sender, EventArgs args)
        {
            entryText += ".";

        }
        void ClickOnDash(object sender, EventArgs args) {
            entryText += "-";
        }
        void ClickOnSubmit(object sender, EventArgs args)
        {

            char text = Morse.MorseCoder(entryText);
            outText += text;
            entryText = "";
            output.Text = outText;

        }

    }
}
