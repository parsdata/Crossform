using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cross.Data
{
    public class BasePage : ContentPage
    {
        public void Show()
        {
            DependencyService.Get<IProgressInterface>().Show();
        }
        public void Hide()
        {
            DependencyService.Get<IProgressInterface>().Hide();
        }
        public BasePage()
        { }
    }
}
