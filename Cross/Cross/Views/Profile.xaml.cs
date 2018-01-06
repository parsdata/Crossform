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
        public Profile()
        {
            InitializeComponent();
            sAppID = App.sAppID;
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

                    bool bResult = clsApiService.SetProfile(sUserID, txtFullName.Text, txtUsername.Text);
                    if (bResult)
                    {
                        await Navigation.PushModalAsync(new MenuPage(), false);
                    }
                    else
                    {
                        await DisplayAlert("پیغام خطا", App.sMessage, "بستن");
                    }
                }
                else
                {
                    await DisplayAlert("پیغام خطا", "خطا در پردازش اطلاعات، لطفا مجددا تلاش نمایید.", "بستن");
                }
            }
            else
            {
                SQLiteConnection _sqLiteConnection;

                _sqLiteConnection = DependencyService.Get<Cross.Data.SQLite.ISQLite>().GetConnection();

                _sqLiteConnection.CreateTable<Cross.Data.SQLite.Table.Base_User>();

                var listRow = _sqLiteConnection.Query<Cross.Data.SQLite.Table.Base_User>("SELECT * FROM Base_User WHERE AppID = '" + sAppID + "' LIMIT 1");
                if (listRow.Count != 0)
                {
                    foreach (var baseUser in listRow)
                    {
                        string sFullName = string.Empty;
                        sFullName = baseUser.FullName;
                        if (string.IsNullOrEmpty(sFullName))
                        {
                            sFullName = baseUser.Mobile;
                        }
                        App.sFullName = sFullName;
                    }
                    await Navigation.PushModalAsync(new MenuPage(), false);
                }
                else
                {
                    App.sAppID = string.Empty;
                    App.IsActive = false;
                    await Navigation.PushModalAsync(new Login(), false);
                }
            }
        }
    }
}