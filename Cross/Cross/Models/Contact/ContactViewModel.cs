using Cross.Data.Interface;
using Cross.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cross.Models.Contact
{
    public class ContactViewModel : BaseViewModel
    {
        public ObservableCollection<Contacts> ContactList { get; set; }

        public ContactViewModel()
        {
            ContactList = new ObservableCollection<Contacts>();
        }

        public async Task BindContcts()
        {
            var addressBook = DependencyService.Get<IAddressBookInformation>();
            if (addressBook != null)
            {
                var allAddress = await addressBook.GetContacts();
                foreach (var c in allAddress)
                {
                    var name = c.FirstName + " " + c.Phone ;
                }

                this.ContactList = new ObservableCollection<Contacts>(allAddress);
                //foreach (var c in allAddress)
                //{
                //    var name = c.FirstName + " " + c.LastName;
                //}
            }
        }
    }
}
