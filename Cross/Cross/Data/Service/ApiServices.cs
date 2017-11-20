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
        public string RegisterAsync(string sMobile, string sDeviceOS, string sDID, string sGID)
        {
            string url = "http://beta.api.parsdata.com/Register/GetRegisterByMobile/" + sMobile + "/" + sDeviceOS + "/" + sDID + "/" + sGID + "";
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

                        var listRow = _sqLiteConnection.Query<Cross.Data.SQLite.Table.Base_User>("SELECT * FROM Base_User WHERE AppID = '" + DataValue["AppID"] + "'");
                        if (listRow.Count != 0)
                        {
                            _sqLiteConnection.Query<Cross.Data.SQLite.Table.Base_User>("UPDATE Base_User SET ActivationCode='" + DataValue["ActivationCode"] + "' WHERE AppID = '" + DataValue["AppID"] + "'");
                        }
                        else
                        {
                            _sqLiteConnection.Insert(new Cross.Data.SQLite.Table.Base_User
                            {
                                UserID = DataValue["UserID"],
                                AppID = DataValue["AppID"],
                                ActivationCode = DataValue["ActivationCode"],
                                Mobile = Data.Base.Convert._MobileFormat(sMobile),
                                FullName = "",
                                IsActive = false
                            });
                        }
                        _sqLiteConnection.Query<Cross.Data.SQLite.Table.Base_User>("UPDATE Base_User SET IsActive='0'");
                    }
                }
            }
            return sResult;
        }
        public int CheckActivationCode(string sAppID, string sActivationCode)
        {
            string url = "http://beta.api.parsdata.com/Register/CheckActivationCode/" + sAppID + "/" + sActivationCode;

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        var sJSON = content.ReadAsStringAsync().Result;

                        Dictionary<string, string> DataValue = JsonConvert.DeserializeObject<Dictionary<string, string>>(sJSON.Replace("[", "").Replace("]", ""));
                        bool bStatus = bool.Parse(DataValue["Status"]);
                        string sFullName = DataValue["FullName"];
                        int iResult = 0;
                        if (bStatus == false)
                        {
                            iResult = 0;
                        }
                        else
                        {
                            SQLiteConnection _sqLiteConnection;
                            _sqLiteConnection = DependencyService.Get<Cross.Data.SQLite.ISQLite>().GetConnection();
                            _sqLiteConnection.Query<Cross.Data.SQLite.Table.Base_User>("UPDATE Base_User SET IsActive='1' , FullName='" + sFullName + "' WHERE AppID = '" + sAppID + "'");

                            App.sAppID = sAppID;
                            App.IsActive = true;
                            App.sFullName = sFullName;
                            if (!string.IsNullOrEmpty(sFullName))
                            {
                                iResult = 1;
                            }
                            else
                            {
                                iResult = 2;
                            }
                        }

                        return iResult;
                    }
                }
            }
        }
        public bool SetProfile(string sUserID, string sFullName)
        {
            string url = "http://beta.api.parsdata.com/Register/SetProfile/" + sUserID + "/" + sFullName;

            SQLiteConnection _sqLiteConnection;
            _sqLiteConnection = DependencyService.Get<Cross.Data.SQLite.ISQLite>().GetConnection();
            _sqLiteConnection.Query<Cross.Data.SQLite.Table.Base_User>("UPDATE Base_User SET FullName='" + sFullName + "' WHERE UserID = '" + sUserID + "'");

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        var sJSON = content.ReadAsStringAsync().Result;


                        Dictionary<string, string> DataValue = JsonConvert.DeserializeObject<Dictionary<string, string>>(sJSON.Replace("[", "").Replace("]", ""));
                        bool bStatus = bool.Parse(DataValue["Status"]);
                        return bStatus;
                    }
                }
            }
        }
    }
}
