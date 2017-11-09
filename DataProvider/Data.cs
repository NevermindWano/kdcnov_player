using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class Data<T>
    {
        private IData saver;

        public string key;
        public T value;

        public Data(IData saver)
        {
            this.saver = saver;
        }

        public Data(IData saver, string key)
        {
            this.saver = saver;
            this.key = key;
        }

        public Data(IData saver, string key, T value)
        {
            this.saver = saver;
            this.key = key;
            this.value = value;

            Save();
        }
        
        public void Save()
        {
            saver.Save(key.ToString(), value);
        }            
        
        public T Read()
        {
            var value = saver.Read(key.ToString());
            if (value == null)
                return default(T);
            return (T)Convert.ChangeType(value, typeof(T));
        }    

        public Dictionary<string, T> ReadAllValues()
        {
            string[] value = saver.GetAllKeys();
            if (value == null) return null;

            Dictionary<string, T> values = new Dictionary<string, T>();
            foreach (string name in value)
            {
                var v = saver.Read(name);
                values[name] = (T)Convert.ChangeType(v, typeof(T));
            }
            return values;
        }
     
    }
}
