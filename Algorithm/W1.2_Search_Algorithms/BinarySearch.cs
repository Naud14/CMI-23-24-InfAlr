namespace ToDo;

public class BinarySearch{

    public static int binarySearch<T>(T[] a, T v) where T : IComparable
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

    public static int binarySearchRecursive<T>(T[] a, int low, int high, T v) where T : IComparable
    {
        Utils.ShowCallStack(); //DO NOT comment this line of code
        if(a != null)
        {
            if(low > high) return -1;
            int middle = (low + high) / 2;
            if(a[middle].CompareTo(v) == 1) return binarySearchRecursive(a, low, middle - 1, v);
            else if(a[middle].CompareTo(v) == -1) return binarySearchRecursive(a, middle + 1, high, v);
            else return middle;
        }
        return -1;
        
    }

}   