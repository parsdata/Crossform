using System.IO;
using SQLite;
using Xamarin.Forms;
using Cross.Data;
using Cross.Droid.Data;

[assembly: Dependency(typeof(DeviceID_Android))]

namespace Cross.Droid.Data
{
    public class DeviceID_Android : DeviceID
    {
        public DeviceID_Android() { }
        public string GetDeviceID()
        {
            string sDeviceID = string.Empty;

            sDeviceID = Android.OS.Build.Serial;

            return sDeviceID;
        }
    }
}