using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    /// <summary>
    /// Key-Value Data. Класс отвечающий за запись данных в виде Ключ-Значение
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Data<T>
    {
        private IKeyValueProvider provider = new RegistryProvider();

        private string key;
        private T value;

#region CONSTRUCTORS

        public Data(IKeyValueProvider provider)
        {
            this.provider = provider;
        }

        public Data(IKeyValueProvider provider, string key)
        {
            this.provider = provider;
            this.key = key;
        }

        public Data(string key)
        {
            this.key = key;
        }

        public Data(IKeyValueProvider provider, string key, T value)
        {
            this.provider = provider;
            this.key = key;
            this.value = value;
            Save();
        }

        public Data(string key, T value)
        {
            this.key = key;
            this.value = value;
            Save();
        }

#endregion

        public void Save()
        {
            provider.Save(key.ToString(), value);
        }            
        
        public T Read()
        {
            var value = provider.Read(key.ToString());
            if (value == null)
                return default(T);
            return (T)Convert.ChangeType(value, typeof(T));
        }    

        public Dictionary<string, T> ReadAllValues()
        {
            string[] value = provider.GetAllKeys();
            if (value == null) return null;

            Dictionary<string, T> values = new Dictionary<string, T>();
            foreach (string name in value)
            {
                var v = provider.Read(name);
                values[name] = (T)Convert.ChangeType(v, typeof(T));
            }
            return values;
        }
     
    }
}
