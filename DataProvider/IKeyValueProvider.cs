using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public interface IKeyValueProvider
    {
        void Save<T>(string key, T value);
        object Read(string key);
        string[] GetAllKeys();
    }
}
