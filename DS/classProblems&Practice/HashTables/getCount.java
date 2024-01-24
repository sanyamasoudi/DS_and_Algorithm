import java.lang.reflect.Array;
import java.util.ArrayList;

class Solution{
    // public static void main(String[] args) {
    //     getCount(
    //         new int[]{10 ,9, 6, 10 ,19, 12 ,19, 15, 8, 12 ,20 ,1 ,20 ,19 ,13 ,7 ,5, 13 ,20 ,7 ,18 ,7, 16}, 23,
    //         10, 12);
    // }
    static int getCount(int arr[], int n, int num1, int num2) 
    { 
        ArrayList hm = new ArrayList();
        int s=-1;int e=-1;
        for(int i=0;i<n;i++)
        {
            if(arr[i]==num1 && s==-1)
            {
                s=i;
            }
            if(arr[i]==num2)
            {
                e=i;
            }
        }
        return s-e-1;
    }
}