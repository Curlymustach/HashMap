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

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {

            //int hash = key.GetHashCode();
            int hash = comparer.GetHashCode(key);
            int index = hash % 10;

            buckets[index].AddFirst(new KeyValuePair<TKey, TValue>(key, value));
            //if(comparer.Equals(key, linkedListKey))

            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
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
