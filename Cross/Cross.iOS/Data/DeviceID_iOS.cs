
using Cross.Data;
using Cross.iOS.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(DeviceID_iOS))]

namespace Cross.iOS.Data
{
    public class DeviceID_iOS : DeviceID
    {
        public DeviceID_iOS()
        { }
        public string GetDeviceID()
        {
            string sDeviceID = string.Empty;

            sDeviceID = UIKit.UIDevice.CurrentDevice.IdentifierForVendor.AsString();

            return sDeviceID;
        }
    }
}
