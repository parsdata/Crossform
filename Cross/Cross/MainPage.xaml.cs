using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using SQLite;
using SQLitePCL;

namespace Cross
{
    public partial class MainPage : Data.BasePage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ShowLoading();
            HideLoading();
        }
    }
}
