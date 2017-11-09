using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clserlib;
using DataProvider;

namespace kdcnovAutoWinForms
{
    class Fonts
    {
        private static string key;

        private static Dictionary<string, Font> fonts = new Dictionary<string, Font>();   
    
        internal static void Set(string key, Font font)
        {
            fonts[key] = font;
        }

        internal static Font Get(string key)
        {
            if (fonts.ContainsKey(key))
                return fonts[key];
            return null;
        }

        internal static void SaveToRegistry()
        {
            if (fonts == null)
                return;

            foreach (KeyValuePair<string, Font> font in fonts)
            {
                byte[] binObj = BinarySerialize.Serialize<Font>(font.Value);
                new Data<byte[]>(new RegistryProvider("Fonts"), font.Key, binObj);                
            }
        }

        internal static void ReadFromRegistry()
        {
            Data<byte[]> sets = new Data<byte[]>(new RegistryProvider("Fonts"));
            Dictionary<string, byte[]> values = sets.ReadAllValues();

            foreach (KeyValuePair<string, byte[]> value in values)
            {
                Set(value.Key, BinarySerialize.Deserialize<Font>(value.Value));
            }
        }

    }
}
