using System;
using System.Collections.Generic;

namespace DataProvider
{
    /// <summary>
    /// Key-Value Data. Класс отвечающий за запись данных в виде Ключ-Значение
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Data : IDisposable
    {
        private IKeyValueProvider provider = new RegistryProvider();

        #region CONSTRUCTORS

        public Data() {}

        public Data(IKeyValueProvider provider)
        {
            this.provider = provider;
        }

#endregion

        public void Save<T>(string key, T value)
        {
            provider.Save(key.ToString(), value);
        }            
        
        public T Read<T>(string key)
        {
            var value = provider.Read(key.ToString());
            if (value == null)
                return default(T);
            return (T)Convert.ChangeType(value, typeof(T));
        }    

        public Dictionary<string, T> ReadAllValues<T>()
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

        public void Dispose()
        {
            provider = null;            
        }
    }
}
