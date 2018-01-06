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

        private static Data options = new Data(new RegistryProvider("Fonts"));
    
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
                options.Save(font.Key, binObj);                
            }
        }

        internal static void ReadFromRegistry()
        {            
            Dictionary<string, byte[]> values = options.ReadAllValues<byte[]>();

            if (values == null)
                return;

            foreach (KeyValuePair<string, byte[]> value in values)
            {
                Set(value.Key, BinarySerialize.Deserialize<Font>(value.Value));
            }
        }

    }
}
