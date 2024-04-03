namespace Solution;

public class Stack<T> : IStack<T>
{
    private T[] A;
    private int Top; 
    private int Capacity; 


    public bool Empty => Top == -1;

    public bool Full => Top == Capacity -1;

    public int Count => Top + 1;

    public int Size => Capacity;

    public Stack(int size = 4)
    {
        //ToDo
        if(size <=  0) throw new Exception("Choose a size higher then 0");
        A = new T[size];
        Top = -1;
        Capacity = size;
    }

    public T? Peek()
    {
        // Accessing the current element on the top of the stack
        if(Empty) return default;
        return A[Top];
    }

    public T? Pop()
    {
        // Removing the current element on the top of the stack
        if(Empty) return default;

        T Item = A[Top];
        A[Top--] = default;
        return Item;
    }

    public void Push(T Item)
    {
        // Adding an element onto the top of the stack
        if(Full) Resize();
        A[++Top] = Item;
    }

    private void Resize()
    {
        T[] NewArray = new T[Size * 2];
        for(int i = 0; i < Size; i ++)
        {
            NewArray[i] = A[i];
        }
        A = NewArray;
        Capacity *= 2;
    }
}
