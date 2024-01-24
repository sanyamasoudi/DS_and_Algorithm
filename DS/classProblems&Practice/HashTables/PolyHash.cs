using System.Diagnostics;
//C# program to implement the above approach
using System;

public struct Hash
{
	public long p; // the prime number used for the hash function
	public long m; // the modulus used for the hash function
	public long hash_value;	 // the hash value of the string

	public Hash(string s)
	{
		p = 31;
		m = 1000000007;
		long hash_so_far = 0;
		long p_pow = 1;
		long n = s.Length;
		for (long i = 0; i < n; ++i)
		{
			hash_so_far = (hash_so_far + (s[(int)i] - 'a' + 1) * p_pow) % m;
			p_pow = (p_pow * p) % m;
		}
		hash_value = hash_so_far;
	}

	public static bool operator ==(Hash a, Hash b)
	{
		return a.hash_value == b.hash_value;
	}

	public static bool operator !=(Hash a, Hash b)
	{
		return !(a == b);
	}
}

//Driver code
public class MainClass
{
	// public static void Main()
	// {
	// 	string s = "geeksforgeeks";
	// 	Hash h = new Hash(s);
	// 	Console.WriteLine($"Hash of {s} is: {h.hash_value}");
	// }
}
//contributed by adityasha4x71

public class PolyHash
{
    // public static void Main(string[] args)
    // {
    //     PolyHashCompute("SANYA",5, 2);
    // }
    public static double PolyHashCompute(string S, int p, int x)
    {
        Debug.Assert(1 <= x && x <= p - 1);
        double hash = 0;
        for (var i = 0; i < S.Length; i++)
        {
            hash += S[i] * Math.Pow(x, i) % p;
        }
        return hash;
    }
    public static double PolyHashCompute2(string S, int p, int x)
    {
        Debug.Assert(1 <= x && x <= p - 1);
        double hash = 0;
        for (var i = S.Length - 1; i >= 0; i--)
        {
            hash = (hash*x + S[i]) % p;
        }
        return hash;
    }
}