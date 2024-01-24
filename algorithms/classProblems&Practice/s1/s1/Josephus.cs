public static  class Josephus
{
    public static int calPosSurviv(int n,int k)
    {
        if (n == 1)
            return 0;
        else 
            return (calPosSurviv(n-1,k)+k)%n;
    }
}