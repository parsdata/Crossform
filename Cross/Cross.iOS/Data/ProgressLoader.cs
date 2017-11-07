using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Cross.Data;
using BigTed;
using Xamarin.Forms;
using Cross.iOS.Data;

[assembly: Dependency(typeof(ProgressLoader))]
namespace Cross.iOS.Data
{
    public class ProgressLoader : IProgressInterface
    {
        public ProgressLoader()
        { }
        public void HideLoading()
        {
            BTProgressHUD.Dismiss();
        }
        public void ShowLoading(string sTitle = "Loading")
        {
            BTProgressHUD.Show(sTitle, maskType: ProgressHUD.MaskType.Black);
        }
    }
}