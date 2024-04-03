namespace Solution;

public class Queue<T> : IQueue<T>
{
    private int front;
    private int back;
    private T[] data;
    private int _count = 0;

    public bool Empty => front == -1;
    public bool Full => _count >= data.Length;
    public int Count => _count;
    public int Size => data.Length;

    public Queue(int capacity = 5)
    {
        data = new T[capacity];
        _count = 0;
        front = back = -1;
    }

    public void Enqueue(T element)
    {
        // Adding an element to the back of the queue
        if(_count >= data.Length) return;
        back = GetNextIndex(back);
       _count++;
        data[back] = element;

    }

    public T? Dequeue()
    {
        // Removing the current element at the front of the queue
        if(_count == 0) return default(T);
        front = GetNextIndex(front);
        _count--;
        return data[front];

    }

    private int GetNextIndex(int index)
    {
        return (index + 1) % data.Length;
    }

}