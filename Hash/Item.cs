using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    /// <summary>
    /// Экземпляр данных, хранимых хэш-таблицей <see cref = "HashTable"/>
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Ключ.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Хранимые данные.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Создать новый экземпляр хранимых данных <see cref = "Item"/>
        /// </summary>
        /// <param name="key"> Ключ. </param>
        /// <param name="value"> Значение. </param>
        public Item(string key, string value)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Ключ объекта. </returns>
        public override string ToString()
        {
            return Key;
        }
    }
}
