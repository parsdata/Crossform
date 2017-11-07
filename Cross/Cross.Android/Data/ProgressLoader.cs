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
using AndroidHUD;
using Xamarin.Forms;
using Cross.Data;
using Cross.Droid.Data;

[assembly: Dependency(typeof(ProgressLoader))]
namespace Cross.Droid.Data
{
    public class ProgressLoader : IProgressInterface
    {
        public ProgressLoader()
        { }
        public void HideLoading()
        {
            AndHUD.Shared.Dismiss();
        }
        public void ShowLoading(string sTitle = "Loading")
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                AndHUD.Shared.Show(Forms.Context, status: sTitle, maskType: MaskType.Black);
            });
        }
    }
}