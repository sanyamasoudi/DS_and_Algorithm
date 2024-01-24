# def fibonacci_sum_squares(n):
#     if n <= 1:
#         return n

#     previous, current, sum = 0, 1, 1

#     for _ in range(n - 1):
#         previous, current = current, previous + current
#         sum += current * current

#     return sum % 10

# f1^2 + f2^2 + f3^2 + ... + fn^2 = fn * fn+1

def fibonacci_number(n):
    if n<=1:return n
    fibList=[0,1]
    for i in range(2,n+1):
        fibList.append((fibList[i-1]+fibList[i-2])%10)
    return fibList[-1]


def fibonacci_sum_squares(n):
    return ((fibonacci_number(n%60)*fibonacci_number((n+1)%60))%10)
if __name__ == '__main__':
    n = int(input())
    print(fibonacci_sum_squares(n))

