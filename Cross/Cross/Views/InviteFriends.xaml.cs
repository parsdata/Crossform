using Cross.Models;
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
    public partial class InviteFriends : ContentPage
    {
        private ContactViewModel contactViewModel;

        public InviteFriends()
        {

            InitializeComponent();

            this.contactViewModel = new ContactViewModel();
            //listView = new ListView
            //{
            //    RowHeight = 80
            //};

            //var layout = new StackLayout()
            //{
            //    // Padding = new Thickness(10, 0, 10, 0),
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    Children = { this.listView }
            //};

            //this.Content = layout;

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var cell = new DataTemplate(typeof(TextCell));
            cell.SetBinding(TextCell.TextProperty, "FirstName");
            cell.SetBinding(TextCell.DetailProperty, "Phone");

            //NamesListView.ItemTemplate
            NamesListView.ItemTemplate = cell;

            await this.contactViewModel.BindContcts();

            NamesListView.ItemsSource = this.contactViewModel.ContactList;

        }

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var contacts = new List<Contacts>();
            NamesListView.ItemsSource = this.contactViewModel.ContactList.Where(x => x.FirstName.ToLower().Contains(EntrySearch.Text.ToLower()));
        }
    }
}