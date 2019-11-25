using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Hash
{
    /// <summary>
    /// Хэш-таблица<para/>
    /// Содержит экземпляры класса <see cref = "Item"/>
    /// </summary>
    public class HashTable
    {
        /// <summary>
        /// Максимальная длина ключевого поля
        /// </summary>
        private readonly byte MaxSize = 255;

        /// <summary>
        /// Коллекция хранимых данных
        /// <para/>
        /// Представляет собой словарь, ключ которого представляет собой хеш ключа хранимых данных,
        /// а значение это список элементов с одинаковым хешем ключа
        /// </summary>
        private Dictionary<int, List<Item>> ItemsDictionary = null;

        /// <summary>
        /// Коллекция хранимых данных <see cref = "Item"/> в хеш-таблице в виде пар хэш-значение
        /// </summary>
        public IReadOnlyCollection<KeyValuePair<int, List<Item>>>
            Items => ItemsDictionary?.ToList()?.AsReadOnly();

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public HashTable()
        {
            ItemsDictionary = new Dictionary<int, List<Item>>(MaxSize);
        }

        /// <summary>
        /// Добавление данных в хеш таблицу <see cref = "HashTable"/>
        /// </summary>
        /// <param name="key">Ключ добавляемых данных</param>
        /// <param name="value">Добавляемые данные</param>
        public void Insert(string key, string value)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
            if (key.Length > MaxSize) throw new ArgumentException
                    ("Максимальная длинна ключа составляет " + MaxSize + " символов");
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value), "Попытка добавление пустого элемента");
            Item item = new Item(key, value);
            int hash = GetHash(item.Key);
            List<Item> hashTableItem = null;
            if (ItemsDictionary.ContainsKey(hash))
            {
                hashTableItem = ItemsDictionary[hash];
                var oldElementWithKey = hashTableItem.SingleOrDefault(i => i.Key == item.Key);
                if (oldElementWithKey != null)
                {
                    throw new ArgumentException("Хэш-таблица уже содержит элемент с ключом \"" +
                        key + "\". Ключ должен быть уникален.");
                }
                ItemsDictionary[hash].Add(item);
            }
            else
            {
                hashTableItem = new List<Item> { item };
                ItemsDictionary.Add(hash, hashTableItem);
            }
        }

        /// <summary>
        /// Удалить данные из хеш таблицы <see cref = "HashTable"/> по ключу
        /// </summary>
        /// <param name="key">Ключ</param>
        public void Delete(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
            if (key.Length > MaxSize) throw new ArgumentException
                    ("Максимальная длинна ключа составляет " + MaxSize + " символов.");
            int hash = GetHash(key);
            if (!ItemsDictionary.ContainsKey(hash)) throw new ArgumentException("Элемент не найден");
            List<Item> hashTableItem = ItemsDictionary[hash];
            Item item = hashTableItem.SingleOrDefault(i => i.Key == key);
            if (item != null) hashTableItem.Remove(item);
        }

        /// <summary>
        /// Поиск значения по ключу
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns> Найденные по ключу хранимые данные </returns>
        public string Search(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key), "Ключ не может быть пустым");
            if (key.Length > MaxSize) throw new ArgumentException
                    ("Максимальная длинна ключа составляет " + MaxSize + " символов.");
            int hash = GetHash(key);
            if (!ItemsDictionary.ContainsKey(hash)) throw new ArgumentException("Элемент не найден");
            List<Item> hashTableItem = ItemsDictionary[hash];
            if (hashTableItem != null)
            {
                var item = hashTableItem.SingleOrDefault(i => i.Key == key);
                if (item != null) return item.Value;
            }
            throw new ArgumentException("Элемент не найден");
        }

        /// <summary>
        /// Хэш функция
        /// </summary>
        /// <param name="value">Хэшируемая строка</param>
        /// <returns>Хэш строки</returns>
        private int GetHash(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));
            if (value.Length > MaxSize) throw new ArgumentException
                    ("Максимальная длинна ключа составляет " + MaxSize + " символов.");
            if (value.Length % 2 != 0) value += '\0';
            byte[] b = Encoding.ASCII.GetBytes(value);
            int sum = 0;
            for (int i = 0; i < b.Length; i += 2)
            {
                int curr = (b[i] << 8) | b[i + 1];
                sum += curr;
            }
            return sum;
        }
    }
}
