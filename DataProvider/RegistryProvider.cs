using Microsoft.Win32;

namespace DataProvider
{
    public class RegistryProvider : IKeyValueProvider
    {
        string regKeyName = "Software\\Nevermind\\KdcnovAuto";

        private string key;

        public RegistryProvider(string path = "")
        {
            regKeyName  = "Software\\Nevermind\\KdcnovAuto\\" + path;
        }

        public void Save<T>(string key, T value)
        {

            this.key = key;
            RegistryKey rk = null;

            try
            {
                rk = Registry.CurrentUser.CreateSubKey(regKeyName);
                if (rk == null) return;
                rk.SetValue(key, value);
            }

            finally
            {
                if (rk != null) rk.Close();
            }
        }

        public object Read(string key)
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.CurrentUser.OpenSubKey(regKeyName);
                return rk.GetValue(key);                
            }

            catch
            {
                return null;
            }

            finally
            {
                //
            }
        }

        public string[] GetAllKeys()
        {
            try
            {
                RegistryKey rk = null;
                rk = Registry.CurrentUser.OpenSubKey(regKeyName);
                return rk.GetValueNames();
            }
            catch
            {
                return null;
            }
        }
    }
}
