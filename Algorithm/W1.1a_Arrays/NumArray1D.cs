using System.Numerics;

namespace ToDo;
public class NumArray1D<T> : Array1D<T>, INumArray1D<T> where T : IComparable<T>, INumber<T>
{
    public NumArray1D(int size = 10):base(size) {  }
    public NumArray1D(T[] data):base(data) { }
  
    public T? Aggregate(Func<T, T, T> fx)
    {
        T result = _data[0];
        for(int i = 1; i < Length; i ++)
        {
            result = fx(result, _data[i]);
        }
        return result;
    }

    public T? Max()
    {
        return Aggregate((x, y) => {return x > y ? x : y;});
    }

    public T? Min()
    {
        return Aggregate((x, y) => {return x > y ? y : x;});
    }

    public T? Product(bool IgnoreZeros = true)
    {
        T? result = default;
        bool HasValue = false;

        for(int i = 0; i < Length; i ++)
        {
            if(_data[i].Equals(0) && IgnoreZeros)
            {
                continue;
            }
            else
            {
                if(HasValue)
                {
                    result = _data[i] * result;
                }
                else
                {
                    result = _data[i];
                    HasValue = true;
                }
            }
        }
        return result;
    }

    public T? Sum()
    {
        return Aggregate((x, y) => {return x + y;});
    }
}