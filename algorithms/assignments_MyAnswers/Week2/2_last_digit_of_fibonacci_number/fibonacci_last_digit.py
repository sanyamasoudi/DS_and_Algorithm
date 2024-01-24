# def fibonacci_last_digit(n):
#     if n <= 1:
#         return n

#     previous = 0
#     current  = 1

#     for _ in range(n - 1):
#         previous, current = current, previous + current

#     return current % 10

def fibonacci_last_digit(n):
    if n<=1:return n
    fibList=[0,1]
    for i in range(2,n+1):
        fibList.append((fibList[i-1]+fibList[i-2])%10)
    return fibList[-1]

if __name__ == '__main__':
    n = int(input())
    print(fibonacci_last_digit(n))
