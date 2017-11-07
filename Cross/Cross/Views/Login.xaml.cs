
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cross.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cross.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : BasePage
    {
        #region [Page]
        public Login()
        {
            InitializeComponent();
           
        }
        #endregion

        #region [Form]
        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(txtMobile.Text))
            {
                Show();
                string sDeviceOS = "0";
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        sDeviceOS = "2";
                        break;
                    case Device.Android:
                        sDeviceOS = "1";
                        break;
                    case Device.WinPhone:
                        sDeviceOS = "3";
                        break;
                    case Device.UWP:
                        sDeviceOS = "4";
                        break;
                }
                //TODO: Get Device ID
                string sDeviceID = DependencyService.Get<DeviceID>().GetDeviceID(); ;

                //TODO: Get Google ID - Notifiction
                string sGID = "123456";

                Cross.Data.Service.ApiServices clsApiService = new Cross.Data.Service.ApiServices();

                string sAppID = clsApiService.RegisterAsync(txtMobile.Text, sDeviceOS, sDeviceID, sGID);
                if (sAppID != "")
                {
                    await Navigation.PushAsync(new Confrim(sAppID));
                    Hide();
                }
                else
                {
                    Hide();
                    await DisplayAlert("پیغام خطا", "خطا در پردازش اطلاعات، لطفا مجددا تلاش نمایید.", "بستن");
                }
            }
            else
            {
                await DisplayAlert("پیغام خطا", "لطفا شماره موبایل را وارد نمایید.", "بستن");
            }
        }
        #endregion
    }
}