using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMap
{
    class HashMap<TKey, TValue> : IDictionary<TKey, TValue>
    {
        LinkedList<KeyValuePair<TKey, TValue>>[] buckets;
        IEqualityComparer<TKey> comparer;

        public TValue this[TKey key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        //turns keys into collection
        public ICollection<TKey> Keys => throw new NotImplementedException();

        public ICollection<TValue> Values => throw new NotImplementedException();

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {
            //int hash = key.GetHashCode();
            int hash = comparer.GetHashCode(key);
            int index = hash % buckets.Length;
            if (ContainsKey(key))
            {
                throw new Exception();
            }
            else if(buckets[index] == null)
            {
               LinkedList<KeyValuePair<TKey, TValue>> newList = new LinkedList<KeyValuePair<TKey, TValue>>();
               buckets[index] = newList;
            }
            buckets[index].AddFirst(new KeyValuePair<TKey, TValue>(key, value));

            //if(comparer.Equals(key, linkedListKey))
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            ContainsKey(item.Key);
            return false;

        }

        public bool ContainsKey(TKey key)
        {
            int index = comparer.GetHashCode(key) % buckets.Length;
            if (buckets[index] == null)
            {
                return false;
            }

            foreach (var pair in buckets[index])
            {
                if (comparer.Equals(pair.Key, key))
                {
                    return true;
                }
            }
            return false;
        }

        public void Remove(TKey key, TValue value)
        {
            int index = comparer.GetHashCode(key) % buckets.Length;
            foreach (var pair in buckets[index])
            {
                if (comparer.Equals(pair.Key, key))
                {
                    
                }
            }
        }

        public void Rehash()
        {

        }








        //Optional
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        //Save for end
        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        //It's own lesson:
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
