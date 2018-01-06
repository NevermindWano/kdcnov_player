using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    class FileKVProvider : IKeyValueProvider
    {
        private string path;

        public FileKVProvider(string path)
        {
            this.path = path;
        }

        public string[] GetAllKeys()
        {
            throw new NotImplementedException();
        }

        public object Read(string key)
        {
            throw new NotImplementedException();
        }

        public void Save<T>(string key, T value)
        {
            throw new NotImplementedException();
        }
    }
}
