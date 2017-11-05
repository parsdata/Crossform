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
    public partial class MainPage : ContentPage
    {
        public class Person
        {
            public string Name { get; set; }
            public DateTime Birthday { get; set; }
        }

        public MainPage()
        {
            InitializeComponent();
            
            var person = new Person { Name = "Bob", Birthday = new DateTime(1987, 2, 2) };
            var json = JsonConvert.SerializeObject(person);
            var person2 = JsonConvert.DeserializeObject<Person>(json);

            lblTitle.Text = "Welcome 6";
        }
    }
}
