public class Myclass
{
    public int facorialRecurs(int n)
    {
        if (n <= 1)
            return 1;
        return n * facorialRecurs(n - 1);
    }
}