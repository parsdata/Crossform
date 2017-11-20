using Cross.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.Data.Interface
{
    public interface IAddressBookInformation
    {
        Task<List<Contacts>> GetContacts();
    }
}
