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
        private const int defaultCapacity = 10;
        LinkedList<KeyValuePair<TKey, TValue>>[] buckets;
        IEqualityComparer<TKey> comparer;

        //constructors
        public HashMap() : this(defaultCapacity, null) { }
        public HashMap(int capacity) : this(capacity, null) { }
        public HashMap(IEqualityComparer<TKey> comparer) : this(defaultCapacity, comparer) { }
        public HashMap(int capacity, IEqualityComparer<TKey> comparer)
        {
            this.comparer = comparer ?? EqualityComparer<TKey>.Default;
            buckets = new LinkedList<KeyValuePair<TKey, TValue>>[capacity];
        }

        public TValue this[TKey key]
        {
            get
            {
                if (ContainsKey(key))
                {
                    int index = comparer.GetHashCode(key) % buckets.Length;
                    foreach (var pair in buckets[index])
                    {
                        if (comparer.Equals(key, pair.Key))
                        {
                            return pair.Value;
                        }
                    }
                }

                throw new KeyNotFoundException();
            }
            set
            {
                if (ContainsKey(key))
                {
                    int index = comparer.GetHashCode(key) % buckets.Length;
                    foreach (var pair in buckets[index])
                    {
                        if (comparer.Equals(key, pair.Key))
                        {
                            buckets[index].Remove(pair);
                            buckets[index].AddFirst(new KeyValuePair<TKey, TValue>(key, value));
                        }
                    }
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        //turns keys into collection
        public ICollection<TKey> Keys => throw new NotImplementedException();

        public ICollection<TValue> Values => throw new NotImplementedException();

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key))
            {
                throw new Exception();
            }

            int hash = comparer.GetHashCode(key); //key.GetHashCode();
            int index = hash % buckets.Length;

            if (buckets[index] == null)
            {
                buckets[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }
            buckets[index].AddFirst(new KeyValuePair<TKey, TValue>(key, value));
            Count++;

            if (Count == buckets.Length)
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
            if (Count > 0)
            {
                Array.Clear(buckets, 0, buckets.Length);
            }
            Count = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ContainsKey(item.Key);
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
                if (comparer.Equals(key, pair.Key))
                {
                    return true;
                }
            }
            return false;
        }


        public bool Remove(TKey key)
        {
            int index = comparer.GetHashCode(key) % buckets.Length;
            foreach (var pair in buckets[index])
            {
                if (comparer.Equals(key, pair.Key))
                {
                    Count--;
                    return buckets[index].Remove(pair);
                }
            }

            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            int index = comparer.GetHashCode(item.Key) % buckets.Length;
            if (buckets[index].Remove(item))
            {
                Count--;
                return true;
            }
            return false;
        }

        private void Rehash(int capacity)
        {
            var temp = new LinkedList<KeyValuePair<TKey, TValue>>[capacity];
            for (int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i] != null)
                {
                    foreach (var pair in buckets[i])
                    {
                        int index = comparer.GetHashCode(pair.Key) % temp.Length;
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
            //bounds checking

            throw new NotImplementedException();
        }

        //Optional
        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        //It's own lesson:
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            //go through each Key Value Pair and yeild return each one
            for(int i = 0; i < buckets.Length; i++)
            {
                if(buckets[i] != null)
                {
                    foreach (var pair in buckets[i])
                    {
                        yield return pair;
                    }

                }
                
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
