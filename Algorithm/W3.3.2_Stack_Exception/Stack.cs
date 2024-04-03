
//-----This file HAS to be modified----

public class Stack<T> : SimpleStack<T>
{
    public Stack() : base(){ }

    public override void Push(T item)
    {
        // If the Stack is full (value of top is equal to Capacity - 1)
        // the method Push creates an array of double the size of the inner array (Capacity is also doubled).
        // The old array is copied to the new array (which then becomes the Stack inner array),
        // the element to be pushed is written in the first available position of the inner array (after the previous elements), 
        // here the value of the top has to be modified.

        if(top == Capacity - 1)
        {
            T[] NewArray = new T[Capacity * 2];
            for(int i = 0; i < Capacity; i ++)
            {
                NewArray[i] = arr[i];
            }
            arr = NewArray;
            Capacity *= 2;
        }
        base.Push(item);
    }

    public override T Pop()
    {
        // method Pop and Peek generate a StackEmptyException when the methods are called on an empty Stack.
        if(IsEmpty()) throw new StackEmptyException("The Stack is empty.");
        else
        {
            return base.Pop();
        }
    }

    public override T Peek()
    {
        // method Pop and Peek generate a StackEmptyException when the methods are called on an empty Stack.
        if(IsEmpty()) throw new StackEmptyException("The Stack is empty.");
        else
        {
            return base.Peek();
        }
    }
}
