using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.Data
{
    public interface IProgressInterface
    {
        void Show(string sTitle = "Loading");
        void Hide();
    }
}
