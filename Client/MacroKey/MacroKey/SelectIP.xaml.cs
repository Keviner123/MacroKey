using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MacroKey
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectIP : ContentPage
	{
		public SelectIP ()
		{
			InitializeComponent ();
        }

        private void Connect_Pressed(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage(IP.Text));
        }
    }
}