using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cross.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IncreaseCredit : ContentPage
	{
		public IncreaseCredit ()
		{
			InitializeComponent ();
		}

        private void btnSubmit_Clicked(object sender, EventArgs e)
        {

        }
    }
}