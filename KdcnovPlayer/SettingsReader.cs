using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;

namespace kdcnovAutoWinForms
{
    static class SettingsReader<T>
    {
        static internal T Read(string key, string section = "")
        {
            Data<T> value = new Data<T>(new RegistryProvider(section), key);
            return value.Read();
        }
    }
}
