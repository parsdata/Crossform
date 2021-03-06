﻿
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
    public partial class Confrim : ContentPage
    {
        public string sAppID;
        public Confrim()
        {
            InitializeComponent();
            Device.StartTimer(new TimeSpan(0, 0, 20), CallWebService); //180 seconds, ie 3 mins
            sAppID = App.sAppID;
        }

        private async void btnAction_Clicked(object sender, EventArgs e)
        {
            SQLiteConnection _sqLiteConnection;
            _sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

            var list = _sqLiteConnection.Query<Base_User>("SELECT * FROM Base_User WHERE ActivationCode = '" + txtActiveCode.Text + "'");
            if (list.Count != 0)
            {
                Cross.Data.Service.ApiServices clsApiService = new Cross.Data.Service.ApiServices();

                int iResult = 0;
                iResult = clsApiService.CheckActivationCode(sAppID, txtActiveCode.Text);

                switch (iResult)
                {
                    case (0):
                        await DisplayAlert("خطا!", "کد فعالسازی وارد شده اشتباه است.", "بستن");
                        break;
                    case (1):
                        await Navigation.PushModalAsync(new MenuPage(), false);
                        break;
                    case (2):
                        await Navigation.PushModalAsync(new Profile());
                        break;
                }
            }
            else
            {
                await DisplayAlert("خطا!", "کد فعالسازی وارد شده اشتباه است.", "بستن");
            }

        }


        private bool CallWebService()
        {
            btnReSend.IsVisible = true;
            return true;
            // Do you webservice call here //
            // return true or false ;  
        }
    }
}