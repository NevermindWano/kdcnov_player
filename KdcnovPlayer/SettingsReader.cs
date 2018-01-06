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
            Data value = new Data(new RegistryProvider(section));
            var response = value.Read<T>(key);
            value.Dispose();
            return response;

        }
    }
}
