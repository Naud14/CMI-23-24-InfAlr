using System.Collections.ObjectModel;

namespace Solution;

public class HashTable<K, V> : IHashTable<K, V>
{
    Entry<K, V>[]? buckets { get; set;}

    public ReadOnlyCollection<Entry<K, V>> data => buckets == null? null : buckets.AsReadOnly();

    public HashTable() { buckets = null; }

    public HashTable(Entry<K, V>[]? input) { importData(input);}

    public HashTable(int capacity)
    {
        buckets = new Entry<K, V>[capacity];
    }

    protected int getIndex(K key)
    {
        int hashCode = Math.Abs(key.GetHashCode());
        return buckets == null ? -1 : hashCode % buckets.Length;
    }
    protected int getNextIndex(int index) => (index + 1) % buckets.Length;

    public bool Add(K key, V value)
    {
        var index = getIndex(key);
        if(index == -1) return false;

        if(buckets[index] == null)
        {
            buckets[index] = new Entry<K, V>(key, value);
            return true;
        }
        if(buckets[index] != null && buckets[index].Key.Equals(key)) return false;
        
        // collision -> we have to do probing to find an empty bucket
        var potential_index = (index + 1) % buckets.Length;

        while(buckets[potential_index] != null)
        {
            if(potential_index == index || buckets[potential_index].Key.Equals(key)) return false;
            potential_index = (potential_index + 1) % buckets.Length;
        }
        buckets[potential_index] = new Entry<K, V>(key, value);
        return true;
    }
    
    public V? Find(K key)
    {
        int index = FindIndex(key);
        if(index == -1) return default; 
        return buckets[index].Value;
    }

    private int FindIndex(K key)
    {
        int index = getIndex(key);
        if(buckets[index] == null) return -1;
        
        if(buckets[index].Key.Equals(key)) return index;

        int potentialIndex = getNextIndex(index); 
        while(potentialIndex != index)
        {
            if(buckets[potentialIndex] != null && buckets[potentialIndex].Key.Equals(key)) return potentialIndex;
            potentialIndex = getNextIndex(potentialIndex);
        }   
        return -1;
    }

    public bool Delete(K key)
    {
        int index = FindIndex(key);
        if(index == -1) return false;
        buckets[index] = default;
        return true;
    }


    //DO NOT REMOVE the following method:
    private void importData(Entry<K, V>[]? inputData){
        if(inputData != null) {
            buckets = new Entry<K, V>[inputData.Length];
            for (int i = 0; i < inputData.Length; ++i) 
                buckets[i] = inputData[i];
        }
    }
}

