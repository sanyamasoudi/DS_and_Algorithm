public class Arr<T>
{
    public int Capacity;
    public int Size;
    public T[] myArr;
    public Arr(int capacity)
    {
        this.Capacity = capacity;
        this.Size = 0;
        this.myArr = new T[capacity];
    }
    public int GetCapacity() => this.Capacity;
    public int GetSize() => this.Size;
    public T GetElement(int i)
    { 
        if(i<Capacity)return myArr[i];
        else throw new IndexOutOfRangeException();
    }
    public void Add(T element)
    {
        if (Size < Capacity)
        {
            myArr[Size] = element;
            Size++;
        }
        else
        {
            T[] newArr = new T[Capacity * 2];
            for (var i = 0; i < Capacity; i++)
            {
                newArr[i] = myArr[i];
            }
            myArr = new T[Capacity * 2];
            myArr = newArr;
            myArr[Size] = element;
            Size++;
            this.Capacity *= 2;
        }
    }
    public int Find(T element)
    {
        for (var i = 0; i < Capacity; i++)
        {
            if (myArr[i].Equals(element)) return i;
        }
        return -1;
    }
    public void Remove(T element)
    {
        int index=Find(element);
        if(index!=-1)
        {
            for (var i = index; i < Size && i+1<Capacity; i++)
            {
                myArr[i]=myArr[i+1];
            }
        }

    }
    public void PrintArr()
    {
        Console.WriteLine(String.Join(" ", myArr));
    }

}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Arr<int> myArr = new Arr<int>(3);
//         myArr.Add(1);
//         myArr.Add(2);
//         myArr.Add(3);
//         myArr.Add(4);
//         myArr.Remove(4);
//         myArr.PrintArr();
//         Console.WriteLine(myArr.GetSize());
//         Console.WriteLine(myArr.GetCapacity());
//         Console.WriteLine(myArr.GetElement(5));
//     }
// }