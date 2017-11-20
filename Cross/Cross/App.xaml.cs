using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Cross
{
    public partial class App : Application
    {
        public static string sAppID = string.Empty;
        public static string sFullName = string.Empty;
        public static bool IsActive = false;


        public App()
        {
            InitializeComponent();


        }

        protected override void OnStart()
        {
            SQLiteConnection _sqLiteConnection;

            _sqLiteConnection = DependencyService.Get<Cross.Data.SQLite.ISQLite>().GetConnection();

            _sqLiteConnection.CreateTable<Cross.Data.SQLite.Table.Base_User>();

            var listRow = _sqLiteConnection.Query<Cross.Data.SQLite.Table.Base_User>("SELECT * FROM Base_User WHERE IsActive = '1' LIMIT 1");
            if (listRow.Count != 0)
            {
                foreach (var baseUser in listRow)
                {
                    sAppID = baseUser.AppID;
                    sFullName = baseUser.FullName;
                    if (string.IsNullOrEmpty(sFullName))
                    {
                        sFullName = baseUser.Mobile;
                    }
                }
                IsActive = true;
                MainPage = new Views.MenuPage();
            }
            else
            {
                MainPage = new Views.Login();
            }
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
