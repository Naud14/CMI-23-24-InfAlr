namespace ToDo;
public class Sort<T> : ISort<T> where T : IComparable<T>
{
    public static void BubbleSort(T[] data)
    {
        bool swapped = true;
        while(swapped)
        {
            swapped = false;
            for(int i = 0; i < data.Length -1; i ++)
            {
                if(data[i].CompareTo(data[i + 1]) == 1)
                {
                    (data[i + 1], data[i]) = (data[i], data[i + 1]);
                    swapped = true;
                }
            }
        }
    }

    public static void InsertionSort(T[] data)
    {
        for(int i = 1; i < data.Length; i ++)
        {
            T key = data[i];
            int curr = i -1;
            while(curr >= 0 && data[curr].CompareTo(key) == 1)
            {
                data[curr + 1] = data[curr];
                curr = curr -1;
            }
            data[curr + 1] = key;
        }
    }


    public static void MergeSort(T[] array, int low, int high)
    {
        if(low < high)
        {
            int middle = (low + high) / 2;
            MergeSort(array, low, middle);
            MergeSort(array, middle + 1, high);
            Merge(array, low, middle, high);
        }
    }

    public static void Merge(T[] array, int low, int middle, int high)
    {
        int LeftSide = middle - low + 1;
        int RightSide = high - middle;
        T[] LeftArray = new T[LeftSide];
        T[] RightArray = new T[RightSide];

        for(int i = 0; i < LeftSide; i ++)
        {
            LeftArray[i] = array[low + i];
        }
        for(int j = 0; j < RightSide; j ++)
        {
            RightArray[j] = array[middle + 1 + j];
        }

        int leftindex = 0;
        int rightindex = 0;

        for(int k = low; k <= high; k ++)
        {
            if (leftindex < LeftSide && (rightindex >= RightSide || LeftArray[leftindex].CompareTo(RightArray[rightindex]) <= 0))
            {
                array[k] = LeftArray[leftindex];
                leftindex++;
            }
            else
            {
                array[k] = RightArray[rightindex];
                rightindex++;
            }
        }
    }
}