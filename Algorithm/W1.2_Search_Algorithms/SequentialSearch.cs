namespace ToDo;

public class SequentialSearch {
    public static int sequentialSearch(int[] a, int v)
    { 
        if(a != null)
        {
            for(int i = 0; i < a.Length; i ++)
            {
                if(a[i] == v) return i;
            }
        }
        return -1;

    }

    public static int sequentialSearch<T>(T[] a, T v) where T : IComparable
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
    
}

