# Uses python3
# import sys
# def fibonacci_partial_sum_naive(from_, to):
#     _sum = 0

#     current = 0
#     _next  = 1

#     for i in range(to + 1):
#         if i >= from_:
#             _sum += current

#         current, _next = _next, current + _next

#     return _sum % 10



# def fibonacci_partial_sum_naive(m, n):
#     fibList=[0,1]
#     for i in range(2,n+1):
#         fibList.append((fibList[i-1]+fibList[i-2])%10)
#     fibList = fibList[m:n + 1]
#     return (sum(fibList[i] for i in range(len(fibList))))%10



def fibonacciLastDigit(n):
    if n <= 1:
        return n
    fib_list = [0, 1]
    for i in range(2, n+1):
        fib_list.append((fib_list[i-1] + fib_list[i-2]) )

    return fib_list[-1]

# def fibonacci_partial_sum_naive(m, n):
#     if n <= 1:
#         return n

#     # Pisano period for mod 10 is 60
#     pisano_period = 60
#     m = m % pisano_period
#     n = n % pisano_period

#     if n < m:
#         n += pisano_period

#     fib_sum_m = fibonacciLastDigit(m - 1)
#     fib_sum_n = fibonacciLastDigit(n)

#     return (fib_sum_n - fib_sum_m) % 10

def fibonacci_partial_sum_naive(m, n):
    if n<=1:return n
    numberNpluseTwoOfN=fibonacciLastDigit((n+2)%60)
    if numberNpluseTwoOfN==0: resultN=9
    else: resultN=numberNpluseTwoOfN-1
    numberNpluseTwoOfM=fibonacciLastDigit((m+1)%60)
    if numberNpluseTwoOfM==0: resultM=9
    else: resultM=numberNpluseTwoOfM-1
    return (resultN-resultM)%10
if __name__ == '__main__':
    # input = sys.stdin.read();
    from_, to = map(int, input().split())
    print(fibonacci_partial_sum_naive(from_, to))
