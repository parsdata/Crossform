
using SQLite;
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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMobile.Text))
            {
                //TODO: Get Device ID
                string sDeviceID = "123456";

                //TODO: Get Google ID - Notifiction
                string sGID = "123456";

                Cross.Data.Service.ApiServices clsApiService = new Cross.Data.Service.ApiServices();

                string sAppID = clsApiService.RegisterAsync(txtMobile.Text, sDeviceID, sGID);
                if (sAppID != "")
                {
                    await Navigation.PushAsync(new Confrim(sAppID));
                }
                else
                {
                    await DisplayAlert("پیغام خطا", "خطا در پردازش اطلاعات، لطفا مجددا تلاش نمایید.", "بستن");
                }
            }
            else
            {
                await DisplayAlert("پیغام خطا", "لطفا شماره موبایل را وارد نمایید.", "بستن");
            }
        }
    }
}