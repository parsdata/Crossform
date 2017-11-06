using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using SQLite;
using Xamarin.Forms;
namespace Cross.Data.Service
{
    public class ApiServices
    {
        public string RegisterAsync(string sMobile, string sDID, string sGID)
        {
            string url = "http://beta.api.parsdata.com/Register/GetRegisterByMobile/" + sMobile + "/1/" + sDID + "/" + sGID + "";
            string sResult = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        var sJSON = content.ReadAsStringAsync().Result;

                        Dictionary<string, string> DataValue = JsonConvert.DeserializeObject<Dictionary<string, string>>(sJSON.Replace("[", "").Replace("]", ""));
                        sResult = DataValue["AppID"];

                        SQLiteConnection _sqLiteConnection;

                        _sqLiteConnection = DependencyService.Get<Cross.Data.SQLite.ISQLite>().GetConnection();

                        _sqLiteConnection.CreateTable<Cross.Data.SQLite.Table.Base_User>();

                        _sqLiteConnection.Insert(new Cross.Data.SQLite.Table.Base_User
                        {
                            UserID = DataValue["UserID"],
                            AppID = DataValue["AppID"],
                            ActivationCode = DataValue["ActivationCode"]
                        });
                    }
                }
            }
            return sResult;
        }
    }
}
