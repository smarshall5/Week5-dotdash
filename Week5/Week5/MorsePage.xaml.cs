using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Week5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MorsePage : ContentPage
    {
        public MorsePage()
        {
            InitializeComponent();
        }
        string entryText = "";
        string outText = "";
        void ClickOnDot(object sender, EventArgs args)
        {
            entryText += ".";

        }
        void ClickOnDash(object sender, EventArgs args)
        {
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