#include <stdio.h>
#include <stdlib.h>

int *arr;
int Size = 0;
int Capacity;
void CreateArr(int c)
{
    Capacity = c;
    arr = (int *)malloc(Capacity * sizeof(int));
    for (size_t i = 0; i < Capacity; i++)
    {
        arr[i] = 0;
    }
}
void PushBack(int element)
{
    if (Size < Capacity)
    {
        arr[Size] = element;
        Size++;
    }
    else
    {
        int *newArr = (int *)malloc(Capacity * 2 * sizeof(int));
        for (size_t i = 0; i < Capacity; i++)
        {
            newArr[i] = arr[i];
        }
        free(arr);
        arr=newArr;Capacity*=2;

        // int *cpyArr = (int *)malloc(Capacity * sizeof(int));
        // for (size_t i = 0; i < Capacity; i++)
        // {
        //     cpyArr[i] = arr[i];
        // }
        // free(arr);

        // Capacity *= 2;
        // arr = (int *)malloc(Capacity * sizeof(int));
        // for (size_t i = 0; i < Size; i++)
        // {
        //     arr[i] = cpyArr[i];
        // }
        // free(cpyArr);

        arr[Size] = element;
        Size++;
    }
}
int Get(int i)
{
    if (i < 0 || i >= Size)
    {
        printf("IndexOut of Ranges Code: ");
        return -1;
    }
    else
        return arr[i];
}
void Set(int i, int Val)
{
    if (i < 0 || i >= Size)
    {
        printf("IndexOut of Ranges Code: ");
    }
    arr[i] = Val;
}
int GetSize()
{
    return Size;
}
int GetCapacity()
{
    return Capacity;
}
void Remove(int index)
{
    for (size_t i = index; i < Size; i++)
    {
        arr[i] = arr[i + 1];
    }
    Size--;
}
void Print()
{
    for (size_t i = 0; i < Size; i++)
    {
        printf("%d ", arr[i]);
    }
    printf("\n");
}
int main()
{
    CreateArr(2);
    PushBack(1);
    PushBack(2);
    PushBack(3);
    Print();
    printf("Capacity:%d Size:%d", GetCapacity(), GetSize());
    // printf("\n");
    // printf("Get first element:%d", Get(0));
    // Set(0, 99);
    // printf("\n");
    // Print();
    printf("%d", Get(-1));
    // Remove(0);
    // printf("\n");
    // Print();
    // printf("Capacity:%d Size:%d", GetCapacity(), GetSize());
}