using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cross.Data;
using Xamarin.Forms;

namespace Cross
{
    public partial class App : Application
    {


        public App()
        {
            InitializeComponent();
            DependencyService.Register<IProgressInterface>();
            //MainPage = new NavigationPage(new Cross.Views.Login());
            MainPage = new NavigationPage(new Cross.Views.Login());

        }

        protected override void OnStart()
        {
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
