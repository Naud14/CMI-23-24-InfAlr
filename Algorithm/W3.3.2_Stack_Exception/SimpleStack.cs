
//-----This file HAS to be modified----

public class SimpleStack<T>
{
    protected T?[] arr;
    protected int top;
    public int Capacity { get; protected set; }
    
    public SimpleStack()
    {
        Capacity = 4;
        arr = new T[Capacity];
        top = -1;
    }
    public bool IsEmpty()
    {
        return top == -1;
    }
    virtual public void Push(T item) //change something here
    {
        if(top == Capacity - 1)
        {
          return;
        }
        arr[++top] = item;
    }
    virtual public T? Peek()        //change something here
    {
        if(IsEmpty())
            return default(T);
        return arr[top];
    }
    virtual public T? Pop()         //change something here
    {
        if(IsEmpty())
            return default(T);
        T? temp = arr[top];
        arr[top] = default(T);
        top--;
        return temp;
    }
}
