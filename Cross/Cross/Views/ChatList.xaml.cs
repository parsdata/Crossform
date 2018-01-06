using Cross.Models.Contact;
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
    public partial class ChatList : ContentPage
    {
        private ContactViewModel contactViewModel;
        private ListView listView;

        public ChatList()
        {
            InitializeComponent();

            //lblAppID.Text = App.sAppID;

            //this.contactViewModel = new ContactViewModel();
            //listView = new ListView
            //{
            //    RowHeight = 40
            //};

            //var layout = new StackLayout()
            //{
            //    // Padding = new Thickness(10, 0, 10, 0),
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    Children = { this.listView }
            //};

            //this.Content = layout;

        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();

        //    var cell = new DataTemplate(typeof(TextCell));
        //    cell.SetBinding(TextCell.TextProperty, "FirstName");
        //    cell.SetBinding(TextCell.DetailProperty, "Phone");


        //    listView.ItemTemplate = cell;

        //    await this.contactViewModel.BindContcts();

        //    listView.ItemsSource = this.contactViewModel.ContactList;

        //}
    }
}