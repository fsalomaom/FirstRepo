using System;
using System.Collections.Generic;

namespace FirstRepo.DataStructures.HashTables
{
    public class HashTable
    {
        private readonly object[] _data;

        public HashTable(int size)
        {
            _data = new object[size];
        }

        private int Hash(string key)
        {
            var hash = 0;

            for (int i = 0; i < key.Length; i++)
            {
                hash = (hash + (int)key[i] * i) % _data.Length;
            }

            return hash;
        }

        public void Set(string key, object value)
        {
            int hashedKey = Hash(key);

            if (_data[hashedKey] == null)
            {
                Console.WriteLine($"_data[{hashedKey}] == null");
                _data[hashedKey] = new Dictionary<string, object>();
            }
            else
                Console.WriteLine($"_data[{hashedKey}] != null");

            Console.WriteLine($"_data[{hashedKey}].Add([{key}, {value}])");
            ((Dictionary<string, object>)_data[hashedKey]).Add(key, value);
        }

        public object? Get(string key)
        {
            int hashedKey = Hash(key);

            if (hashedKey > _data.Length || _data[hashedKey] == null)
                return null;

            var bucket = (Dictionary<string, object>)_data[hashedKey];

            return bucket.Where(x => x.Key == key).Select(x => x.Value).FirstOrDefault();
        }

        public string[] GetKeys()
        {
            var keys = new List<string>();

            for (int i = 0; i < _data.Length; i++)
            {
                if (_data[i] != null)
                {
                    keys.AddRange(((Dictionary<string, object>)_data[i]).Keys);
                }
            }

            return keys.ToArray();
        }

        public override string ToString()
        {
            var log = new System.Text.StringBuilder();

            for (int i = 0; i < _data.Length; i++)
            {
                if (_data[i] != null)
                {
                    var dicObj = (Dictionary<string, object>)_data[i];

                    string dicLog = "";

                    foreach (var dic in dicObj)
                    {
                        dicLog += $"[{dic.Key}, {dic.Value}] ";
                    }

                    log.Append($"_data[{i}] = {dicLog}\r\n");
                }
            }

            return $"{log}";
        }
    }
}