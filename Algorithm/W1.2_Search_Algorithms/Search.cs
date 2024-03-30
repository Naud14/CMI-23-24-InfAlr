namespace ToDo;

public class Search<T> : ISearch<T> where T:IComparable<T>{

    public static int SequentialSearch(T[] a, T v)
    {        
        if(a != null)
        {
            for(int i = 0; i < a.Length; i ++)
            {
                if(a[i].CompareTo(v) == 0) return i;
            }
        }
        return -1;
    }

    public static int BinarySearch(T[] a, T v) 
    {        
        if( a != null)
        {
            int low = 0;
            int high = a.Length -1;

            while(low < high)
            {
                int middle = (low + high) / 2;
                if(a[middle].CompareTo(v) == 1) high = middle -1;
                else if(a[middle].CompareTo(v) == -1) low = middle + 1;
                else return middle;
            }
        }
        return -1;
    }

    public static int BinarySearchRecursive(T[] a, T v, int low, int high)
    {
        Utils.ShowCallStack();

        if(a != null)
        {
            if(low > high) return -1;
            int middle = (low + high) / 2;
            if(a[middle].CompareTo(v) == 1) return BinarySearchRecursive(a, v, low, middle - 1);
            else if(a[middle].CompareTo(v) == -1) return BinarySearchRecursive(a, v, middle + 1, high);
            else return middle;
        }
        return -1;

        
    }

}

