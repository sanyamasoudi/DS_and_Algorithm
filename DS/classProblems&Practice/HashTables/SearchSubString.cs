
// Following program is a C# implementation
// of Rabin Karp Algorithm given in the CLRS book
using System;
public class GFG {
	// d is the number of characters in the input alphabet
	public readonly static int d = 256;

	/* pat -> pattern
		txt -> text
		q -> A prime number
	*/
	static void search(String pat, String txt, int q)
	{
		int M = pat.Length;
		int N = txt.Length;
		int i, j;
		int p = 0; // hash value for pattern
		int t = 0; // hash value for txt
		int h = 1;

		// The value of h would be "pow(d, M-1)%q"
		for (i = 0; i < M - 1; i++)
			h = (h * d) % q;

		// Calculate the hash value of pattern and first
		// window of text
		for (i = 0; i < M; i++) {
			p = (d * p + pat[i]) % q;
			t = (d * t + txt[i]) % q;
		}

		// Slide the pattern over text one by one
		for (i = 0; i <= N - M; i++) {

			// Check the hash values of current window of
			// text and pattern. If the hash values match
			// then only check for characters one by one
			if (p == t) {
				/* Check for characters one by one */
				for (j = 0; j < M; j++) {
					if (txt[i + j] != pat[j])
						break;
				}

				// if p == t and pat[0...M-1] = txt[i, i+1,
				// ...i+M-1]
				if (j == M)
					Console.WriteLine(
						"Pattern found at index " + i);
			}

			// Calculate hash value for next window of text:
			// Remove leading digit, add trailing digit
			if (i < N - M) {
				t = (d * (t - txt[i] * h) + txt[i + M]) % q;

				// We might get negative value of t,
				// converting it to positive
				if (t < 0)
					t = (t + q);
			}
		}
	}

	/* Driver Code */
	// public static void Main()
	// {
	// 	String txt = "GEEKS FOR GEEKS";
	// 	String pat = "GEEK";

	// 	// A prime number
	// 	int q = 101;

	// 	// Function Call
	// 	search(pat, txt, q);
	// }
}

// This code is contributed by PrinciRaj19992


class GFG2
{

    public static void search(String txt, String pat)
    {
        int M = pat.Length;
        int N = txt.Length;

        /* A loop to slide pat one by one */
        for (int i = 0; i <= N - M; i++)
        {
            int j;

            /* For current index i, check for pattern
			match */
            for (j = 0; j < M; j++)
                if (txt[i + j] != pat[j])
                    break;

            // if pat[0...M-1] = txt[i, i+1, ...i+M-1]
            if (j == M)
                Console.WriteLine("Pattern found at index "
                                + i);
        }
    }

    // // Driver's code
    // public static void Main()
    // {
    //     String txt = "AABAACAADAABAAABAA";
    //     String pat = "AABA";

    //     // Function call
    //     search(txt, pat);
    // }
}
// This code is Contributed by Sam007

public class SearchSubStringEfficent
{
    // public static void Main(string[] args)
    // {
    //     var r = RabinKarps("aaaaa", "aa");
    //     Console.WriteLine(String.Join(" ", r));
    // }
    public static int[] PreComputeHashes(string T, string P, int p, int x)
    {
        int[] H = new int[T.Length - P.Length + 1];
        var S = T.Substring(T.Length - P.Length, P.Length);
        H[T.Length - P.Length] = PolyHash(S, p, x);
        int y = 1;
        for (var i = 1; i <= P.Length; i++)
        {
            y = y * x % p;
        }
        for (var i = T.Length - P.Length - 1; i >= 0; i--)
        {
            H[i] = (x * H[i + 1] + (T[i] - y * T[i + P.Length])) % p;
        }
        return H;
    }
    public static List<int> RabinKarps(string T, string P)
    {
        int p = 31; int x = 256;
        var pHash = PolyHash(P, p, x);
        var positions = new List<int>();
        var H = PreComputeHashes(T, P, p, x);
        for (var i = 0; i < T.Length - P.Length + 1; i++)
        {
            // var tHash = PolyHash(T.Substring(i, P.Length), p, x);
            // if (pHash != tHash)
            // {
            //     continue;
            // }
            if (pHash != H[i])
            {
                continue;
            }
            if (SearchSubStringNaive.AreEqual(T.Substring(i, P.Length), P))
            {
                positions.Add(i);
            }
        }
        return positions;
    }
    public static int PolyHash(string S, int p, int x)
    {
        int hash = 0;
        for (var i = S.Length - 1; i >= 0; i--)
        {
            hash = (hash * x + S[i]) % p;
        }
        return hash;
    }
    private static int PolyHashCompute2(string s1, int p, int m)
    {
        int hash = 0; int p_pow = 1;
        for (var i = 0; i < s1.Length; i++)
        {
            hash += (s1[i] - 'a' + 1) * p_pow % m;
            p_pow *= p % m;
        }
        return hash;
    }


}
public class SearchSubStringNaive
{
    // public static void Main(string[] args)
    // {
    //     FindStringNaive("abcdababa","ab");
    // }
    // O((|T|-|P|+1)|P|)=O(|T||P|)
    public static List<int> FindStringNaive(string T, string P)
    {
        var positions = new List<int>();
        for (var i = 0; i <= T.Length - P.Length; i++)
        {
            if (AreEqual(T.Substring(i, P.Length), P))
            {
                positions.Add(i);
            }
        }
        return positions;
    }
    // O(|p|)
    public static bool AreEqual(string s1, string s2)
    {
        if (s1.Length != s2.Length)
        {
            return false;
        }
        for (var i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
            {
                return false;
            }
        }
        return true;
    }
}