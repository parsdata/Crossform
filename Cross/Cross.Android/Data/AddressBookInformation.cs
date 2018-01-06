using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cross.Data.Interface;
using Cross.Models;
using Cross.Droid.Data;
using Cross.Models.Contact;
using System.Threading.Tasks;
using Xamarin.Contacts;
using Xamarin.Forms;

[assembly: Dependency(typeof(AddressBookInformation))]
namespace Cross.Droid.Data
{
    public class AddressBookInformation : IAddressBookInformation
    {
        /// <summary>
        /// The book.
        /// </summary>
        public AddressBook book = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBookInformation"/> class.
        /// </summary>
        public AddressBookInformation()
        {
            this.book = new AddressBook(Forms.Context.ApplicationContext);
        }

        public async Task<List<Contacts>> GetContacts()
        {
            var contacts = new List<Contacts>();

            // Observation:
            // On device RequestPermission() returns false sometimes so you can use  this.book.RequestPermission().Result (remove await)
            try
            {
                var permissionResult = await this.book.RequestPermission();
                if (permissionResult)
                {
                    if (!this.book.Any())
                    {
                        Console.WriteLine("No contacts found");
                    }
                    //book.Select(x => x.Phones).Distinct();
                    foreach (Contact contact in book)
                    {
                        foreach (var phone in contact.Phones)
                        {
                            //if (contact.DisplayName.Contains("Mehrdad"))
                            //{
                            //    contacts.Add(new Contacts() { FirstName = contact.DisplayName, Phone = phone.Number });
                            //}
                            contacts.Add(new Contacts() { FirstName = contact.DisplayName, Phone = phone.Number });
                            contacts = contacts.OrderBy(x => x.FirstName).ToList();
                        }
                        // Note: on certain android device(Htc for example) it show name in DisplayName Field

                    }
                }
            }
            catch (Exception ex)
            { }

            return contacts;
        }
    }
}