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
    public partial class TransferToReceiver : ContentPage
    {
        public string sCredit;
        Data.Service.ApiServices RefService = new Data.Service.ApiServices();

        public TransferToReceiver()
        {
            InitializeComponent();


            sCredit = RefService.GetCredit(App.sUserID);
            lblCredit.Text = "اعتبار شما: #Credit# تومان".Replace("#Credit#", sCredit);
        }

        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            if (txtAmount.Text != "" && txtAmount.Text != "0")
            {
                sCredit = RefService.GetCredit(App.sUserID);
                if (int.Parse(sCredit) >= int.Parse(txtAmount.Text))
                {
                    try
                    {
                        if (txtReceiver.Text != "")
                        {
                            string sDescription = "-";
                            if (!string.IsNullOrEmpty(txtDescription.Text))
                            {
                                sDescription = txtDescription.Text;
                            }
                            bool bStatus = RefService.SetCredit(App.sUserID, "3", txtReceiver.Text, txtAmount.Text, sDescription);
                            if (bStatus == true)
                            {
                                lblCredit.Text = "اعتبار شما: #Credit# تومان".Replace("#Credit#", App.sCredit);

                                await DisplayAlert("پیام", "مبلغ #Price# از اعتبار شما کسر شد.".Replace("#Price#", txtAmount.Text), "بستن");

                                txtAmount.Text = "";
                                txtDescription.Text = "";
                                txtReceiver.Text = "";
                            }
                            else
                            {
                                await DisplayAlert("خطا در پرداز اطلاعات", App.sMessage, "بستن");
                                App.sMessage = string.Empty;
                            }
                        }
                    }
                    catch
                    {
                        await DisplayAlert("خطا!", "در انتقال اعتبار خطایی رخ داده است. لطفا مجددا تلاش نمایید.", "بستن");

                    }
                }
                else
                {
                    await DisplayAlert("خطا!", "مبلغ وارد شده بیشتر از اعتبار شما می باشد.", "بستن");
                }
            }
            else
            {
                await DisplayAlert("خطا!", "مبلغ وارد شده صحیح نمی باشد.", "بستن");
            }

        }
    }
}