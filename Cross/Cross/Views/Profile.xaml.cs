using Cross.Data.SQLite;
using Cross.Data.SQLite.Table;
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
    public partial class Profile : ContentPage
    {
        private string sAppID;
        public Profile(string AppID)
        {
            InitializeComponent();
            sAppID = AppID;
            NavigationPage.SetHasBackButton(this, false);
        }

        private async void btnAction_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFullName.Text))
            {
                SQLiteConnection _sqLiteConnection;
                _sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

                var list = _sqLiteConnection.Query<Base_User>("SELECT UserID FROM Base_User WHERE AppID = '" + sAppID + "' LIMIT 1");
                if (list.Count != 0)
                {
                    string sUserID = list[0].UserID;
                   Cross.Data.Service.ApiServices clsApiService = new Cross.Data.Service.ApiServices();

                    bool bResult = clsApiService.SetProfile(sUserID, txtFullName.Text);
                    if (bResult)
                    {
                        await Navigation.PushAsync(new ChatList(sAppID));
                    }
                    else
                    {
                        await DisplayAlert("پیغام خطا", "خطا در پردازش اطلاعات، لطفا مجددا تلاش نمایید.", "بستن");

                    }
                }
                else
                {
                    await DisplayAlert("پیغام خطا", "خطا در پردازش اطلاعات، لطفا مجددا تلاش نمایید.", "بستن");

                }
            }
            else
            {
                await Navigation.PushAsync(new ChatList(sAppID));
            }
        }
    }
}