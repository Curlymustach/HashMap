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

        public HashMap(int length)
        {
            buckets = new LinkedList<KeyValuePair<TKey, TValue>>[length];
        }

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
            //if(comparer.Equals(key, linkedListKey))
            int hash = key.GetHashCode();
            int index = hash % buckets.Length;
            if (ContainsKey(key))
            {
                throw new Exception();
            }
            else if(buckets[index] == null)
            {
                buckets[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }
            buckets[index].AddFirst(new KeyValuePair<TKey, TValue>(key, value));
            Count++;

            if(Count == buckets.Length)
            {
                Rehash(buckets.Length * 2);
            }
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
            int index = key.GetHashCode() % buckets.Length;
            if (buckets[index] == null)
            {
                return false;
            }

            foreach (var pair in buckets[index])
            {
                if (pair.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }


        public bool Remove(TKey key)
        {
            int index = key.GetHashCode() % buckets.Length;
            foreach (var pair in buckets[index])
            {
                if (pair.Key.Equals(key))
                {
                    Count--;
                    return buckets[index].Remove(pair);
                }
            }
            
            return false;
            
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            int index = item.Key.GetHashCode() % buckets.Length;
            if (buckets[index].Remove(item))
            {
                Count--;
                return true;
            }
            return false;            
        }

        private void Rehash(int capacity)
        {
            LinkedList<KeyValuePair<TKey, TValue>>[] temp = new LinkedList<KeyValuePair<TKey, TValue>>[capacity];
            for (int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i] != null)
                {
                    foreach (var pair in buckets[i])
                    {
                        int index = pair.Key.GetHashCode() % temp.Length;
                        if (temp[index] == null)
                        {
                            temp[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
                        }
                        temp[index].AddFirst(pair);

                    }
                }
            }
            buckets = temp;
        }

        //Optional
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
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
