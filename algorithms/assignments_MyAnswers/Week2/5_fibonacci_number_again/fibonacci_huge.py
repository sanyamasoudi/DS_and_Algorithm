# def fibonacci_huge_naive(n, m):
#     if n <= 1:
#         return n

#     previous = 0
#     current  = 1

#     for _ in range(n - 1):
#         previous, current = current, previous + current

#     return current % m

# def fibonacci_huge_naive(n, m):
#     if n<=1:return n
#     fibList=[0,1]
#     for i in range(2,n+1):
#         fibList.append((fibList[i-1]+fibList[i-2])%m)
#     return fibList[-1]
def pisano_period_length(n):
    a, b = 0, 1
    for i in range(0, n*n):
        c = (a + b) % n
        a = b
        b = c
        if (a == 0 and b == 1):
            return i + 1
    return None

def fibonacci_number(n):
    if n<=1:return n
    fibList=[0,1]
    for i in range(2,n+1):
        fibList.append(fibList[i-1]+fibList[i-2])
    return fibList[-1]

def fibonacci_huge_naive(n, m):
    pisano_length=pisano_period_length(m)
    indexResult=n%pisano_length
    return fibonacci_number(indexResult)%m

if __name__ == '__main__':
    n, m = map(int, input().split())
    print(fibonacci_huge_naive(n, m))
