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
    public partial class IncreaseCredit : ContentPage
    {
        Data.Service.ApiServices RefService = new Data.Service.ApiServices();

        public IncreaseCredit()
        {
            InitializeComponent();

            string sCredit = RefService.GetCredit(App.sUserID);
            lblCredit.Text = "اعتبار شما: #Credit# تومان".Replace("#Credit#", sCredit);
        }

        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            if (txtAmount.Text != "" && txtAmount.Text != "0")
            {
                try
                {
                    bool bStatus = RefService.SetCredit(App.sUserID, "1", App.sUserID, txtAmount.Text, txtDescription.Text);
                    if (bStatus == true)
                    {
                        lblCredit.Text = "اعتبار شما: #Credit# تومان".Replace("#Credit#", App.sCredit);

                        await DisplayAlert("پیام", "مبلغ #Price# به اعتبار شما اضافه شده.".Replace("#Price#", txtAmount.Text), "بستن");

                        txtAmount.Text = "";
                        txtDescription.Text = "";
                    }
                    else
                    {
                        await DisplayAlert("خطا در پرداز اطلاعات", App.sMessage, "بستن");
                        App.sMessage = string.Empty;
                    }
                }
                catch
                {
                    await DisplayAlert("خطا!", "در افزایش اعتبار خطایی رخ داده است. لطفا مجددا تلاش نمایید.", "بستن");

                }
            }
            else
            {
                await DisplayAlert("خطا!", "مبلغ وارد شده باید بزرگتر از 0 باشد.", "بستن");
            }
        }
    }
}