public static class PolynomialMultiply
{
    //O(n^2)
    public static int[] ComputeNaive(int[] A, int[] B, int n)
    {
        var product = new int[2 * n - 1];
        // for (var i = 0; i < 2 * n - 1; i++)
        // {
        //     product[i] = 0;
        // }
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                product[i + j] += A[i] * B[j];
            }
        }
        return product;
    }
    // T(n) = 4T(n/2)+ kn (O(n)))
    //Bigteta(n^2)
    public static int[] ComputeDivideConquerNaive(int[] A, int[] B, int n, int a1, int b1)
    {
        var product = new int[2 * n - 1];
        if (n == 1)
        {
            product[0] = A[a1] * B[b1];
            return product;
        }
        // product = ComputeDivideConquerNaive(A, B, n / 2, a1, b1);
        // Array.Resize(ref product, 2 * n - 1);
        var result1 = ComputeDivideConquerNaive(A, B, n / 2, a1, b1);
        for (var i = 0; i < n - 1; i++)
        {
            product[i] = result1[i];
        }
        var result2 = ComputeDivideConquerNaive(A, B, n / 2, a1 + n / 2, b1 + n / 2);
        for (var i = n; i < 2 * n - 1; i++)
        {
            product[i] = result2[i - n];
        }
        var D0E1 = ComputeDivideConquerNaive(A, B, n / 2, a1, b1 + n / 2);
        var D1E0 = ComputeDivideConquerNaive(A, B, n / 2, a1 + n / 2, b1);
        for (var i = (int)(n / 2); i < n + (int)(n / 2) - 1; i++)
        {
            product[i] = D0E1[i - (int)(n / 2)] + D1E0[i - (int)(n / 2)];
        }
        return product;
    }
    //karatsuba approach ComputeDivideConquerEfficent
    // public static int[] ComputeDivideConquerEfficent(int[] A, int[] B, int n, int a1, int b1)
    // {
    //     var product = new int[2 * n - 1];
    //     if (n == 1)
    //     {
    //         product[0] = A[a1] * B[b1];
    //         return product;
    //     }
    //     // product = ComputeDivideConquerNaive(A, B, n / 2, a1, b1);
    //     // Array.Resize(ref product, 2 * n - 1);
    //     var result1 = ComputeDivideConquerEfficent(A, B, n / 2, a1, b1);
    //     for (var i = 0; i < n - 1; i++)
    //     {
    //         product[i] = result1[i];
    //     }
    //     var result2 = ComputeDivideConquerEfficent(A, B, n / 2, a1 + n / 2, b1 + n / 2);
    //     for (var i = n; i < 2 * n - 1; i++)
    //     {
    //         product[i] = result2[i - n];
    //     }
    //     var D0E1 = ComputeDivideConquerEfficent(A, B, n / 2, a1, b1 + n / 2);
    //     var D1E0 = ComputeDivideConquerEfficent(A, B, n / 2, a1 + n / 2, b1);
    //     for (var i = (int)(n / 2); i < n + (int)(n / 2) - 1; i++)
    //     {
    //         product[i] = D0E1[i - (int)(n / 2)] + D1E0[i - (int)(n / 2)];
    //     }
    //     return product;
    // }
}