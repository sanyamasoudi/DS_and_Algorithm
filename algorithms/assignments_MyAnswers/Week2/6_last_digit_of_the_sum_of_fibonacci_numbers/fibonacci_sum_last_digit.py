# def fibonacci_sum(n):
#     if n <= 1:
#         return n

#     previous, current, _sum = 0, 1, 1

#     for _ in range(n - 1):
#         previous, current = current, previous + current
#         _sum += current

#     return _sum % 10

# def fibonacci_sum(n):
#     sumList=[1,2]
#     if n<=1: return n
#     for i in range(2,n):
#         sumList.append((sumList[i-1]+sumList[i-2]+1)%10)
#     return sumList[-1]


#we can use the fact that the last digit of a Fibonacci number repeats every 60 numbers.
#𝐹0 + 𝐹1 + 𝐹2 + · · · + 𝐹𝑛 = 𝐹𝑛+2 - 1

def fibonacciLastDigit(n):
    fibList=[0,1]
    for i in range(2,n+1):
        fibList.append((fibList[i-1]+fibList[i-2])%10)
    return fibList[-1]
def fibonacci_sum(n):
    if n<=1:return n
    numberNpluseTwo=fibonacciLastDigit((n+2)%60)
    if numberNpluseTwo==0:return 9
    return numberNpluseTwo-1

if __name__ == '__main__':
    n = int(input())
    print(fibonacci_sum(n))
