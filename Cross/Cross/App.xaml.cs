using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

using Xamarin.Forms;

namespace Cross
{
    public partial class App : Application
    {
        public class Person
        {
            public string Name { get; set; }
            public DateTime Birthday { get; set; }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new Cross.MainPage();

            var person = new Person { Name = "Bob", Birthday = new DateTime(1987, 2, 2) };
            var json = JsonConvert.SerializeObject(person);
            var person2 = JsonConvert.DeserializeObject<Person>(json);
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
