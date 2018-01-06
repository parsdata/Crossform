using Cross.Models.MenuItem;
using Cross.Views;
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
    public partial class MenuPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public MenuPage()
        {
            InitializeComponent();
            lblFullName.Text = App.sFullName;
            lblAppID.Text = "کد پذیرندگی شما: " + App.sUserID;

            Data.Service.ApiServices RefService = new Data.Service.ApiServices();

            string sCredit = RefService.GetCredit(App.sUserID);
            lblCredit.Text = "اعتبار شما: #Credit# تومان".Replace("#Credit#", StringFormatCurency(sCredit));

            menuList = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "افزایش اعتبار", Icon = "itemIcon1.png", TargetType = typeof(IncreaseCredit) };
            var page2 = new MasterPageItem() { Title = "انتقال به بانک", Icon = "itemIcon2.png", TargetType = typeof(TransferToBank) };
            var page3 = new MasterPageItem() { Title = "انتقال به پذیرنده", Icon = "itemIcon4.png", TargetType = typeof(TransferToReceiver) };
            var page4 = new MasterPageItem() { Title = "گزارش", Icon = "itemIcon3.png", TargetType = typeof(NoPage) };
            //var page4 = new MasterPageItem() { Title = "دوستان", Icon = "itemIcon4.png", TargetType = typeof(Friends) };
            //var page5 = new MasterPageItem() { Title = "دعوت از دوستان", Icon = "itemIcon4.png", TargetType = typeof(InviteFriends) };
            var page6 = new MasterPageItem() { Title = "درباره ما", Icon = "itemIcon5.png", TargetType = typeof(NoPage) };
            var page7 = new MasterPageItem() { Title = "پشتیبانی", Icon = "itemIcon6.png", TargetType = typeof(NoPage) };
            var page8 = new MasterPageItem() { Title = "تنظیمات", Icon = "itemIcon7.png", TargetType = typeof(NoPage) };
            var page9 = new MasterPageItem() { Title = "خروج", Icon = "itemIcon8.png", TargetType = typeof(NoPage) };

            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            //menuList.Add(page5);
            menuList.Add(page6);
            menuList.Add(page7);
            menuList.Add(page8);
            menuList.Add(page9);


            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ChatList)));
        }

        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
        public static string StringFormatCurency(string Value)
        {
            string sResult = String.Format("{0:C}", Value);
            return sResult;
        }
    }
}