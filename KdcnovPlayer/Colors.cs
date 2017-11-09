using DataProvider;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kdcnovAutoWinForms
{
    static class Colors
    {
        private static readonly Dictionary<string, long> DEFAULT_COLORS = new Dictionary<string, long>
        {
            { "bgTrackFontColor",  -32704 },
            { "concreteBgColor",   -12550016 },
            { "nextButtonColor",   -8355585 },
            { "nextTrackColor",    -1 },
            { "stopButtonColor",   -65536 },
        };

        private static Dictionary<string, Color> colors = new Dictionary<string, Color>();

        public static Color Get(string key)
        {
            if (colors.ContainsKey(key))
                return colors[key];
            return Color.White;
        }

        public static void Set(string key, Color color)
        {
            colors[key] = color;
        }

        public static void SetBackColor<T>(T element, string key)
        {
            try
            {
                setColorProperty<T>("BackColor", element, key);
            }

            catch { }
        }
        public static void SetForeColor<T>(T element, string key)
        {
            try
            {
                setColorProperty<T>("ForeColor", element, key);
            }

            catch { }
        }

        public static void ReadFromRegistry()
        {
            Data<long> sets = new Data<long>(new RegistryProvider("Colors"));

            Dictionary<string, long> values = sets.ReadAllValues();

            if (values == null)
                values = DEFAULT_COLORS;

            foreach (KeyValuePair<string, long> value in values)
            {
                Set(value.Key, Color.FromArgb(Convert.ToInt32(value.Value)));
            }
        }

        public static void SaveToRegistry()
        {
            foreach (KeyValuePair<string, Color> color in colors)
            {
                new Data<int>(new RegistryProvider("Colors"), color.Key, color.Value.ToArgb());
            }
        }


        private static void setColorProperty<T>(string propName, T element, string key)
        {
            Type type = element.GetType();
            if (type.GetProperty(propName) != null)
            {
                var prop = type.GetProperty(propName);
                Convert.ChangeType(element, type);
                element.GetType().GetProperty(prop.Name).SetValue(element, colors[key]);
            }
        }
    }
}
