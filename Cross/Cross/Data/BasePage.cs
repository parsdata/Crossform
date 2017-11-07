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
        public void ShowLoading()
        {
            DependencyService.Get<IProgressInterface>().ShowLoading();
        }
        public void HideLoading()
        {
            DependencyService.Get<IProgressInterface>().HideLoading();
        }
        public BasePage()
        { }
    }
}
