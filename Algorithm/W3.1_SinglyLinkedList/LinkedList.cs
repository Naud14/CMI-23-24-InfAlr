using System.Collections;

namespace Solution;

public class SinglyLinkedList<T> : ILinkedList<T> where T : IComparable<T>
{
    public SingleNode<T>? Head;
    private int count;

    public SinglyLinkedList()
    {
        Head = null;
        count = 0;
    }

    public int Count => count;

    public void AddFirst(T value)
    {
        Head = new SingleNode<T>(value, Head);
        count ++;
    }

    public void AddLast(T value)
    {
        if (Head == null)
        {
            AddFirst(value);
            return;
        }

        SingleNode<T> curr = Head;
        while (curr.Next != null)
        {
            curr = curr.Next;
        }

        curr.Next = new SingleNode<T>(value, null);
        count++;
    }

    public bool Remove(T value)
    {
        if(Head == null) return false;
        if(Head.Value.CompareTo(value) == 0)
        {
            Head = Head.Next; 
            count--;
            return true;
        }
        
        SingleNode<T> curr = Head;
        while(curr.Next != null)
        {
            if(curr.Next.Value.CompareTo(value) == 0)
            {
                curr.Next = curr.Next.Next;
                count--;
                return true;
            }
            curr = curr.Next;
        }
        return false;
        
    }

    public SingleNode<T>? Search(T value)
    {
        if(Head == null) return default;
        SingleNode<T> curr = Head;
        while(curr != null)
        {
            if(curr.Value.CompareTo(value) == 0) return curr;
            curr = curr.Next;
        }
        return null;
    }

    public bool Contains(T value) => Search(value) != null;

    public void AddSorted(T value)
    {
        if(Head == null || Head.Value.CompareTo(value) > 0)
        {
            Head = new SingleNode<T>(value, Head);
            count++;
            return;
        }
        SingleNode<T>? current = Head;
        while (current.Next != null && current.Next.Value.CompareTo(value) < 0)
        {
            current = current.Next;
        }
        current.Next = new SingleNode<T>(value, current.Next);
        count++;
    }

    public void Clear()
    {
        Head = null;
        count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        SingleNode<T>? current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}