def fibonacci_number(n):
    if n<=1:return n
    fibList=[0,1]
    for i in range(2,n+1):
        fibList.append(fibList[i-1]+fibList[i-2])
    return fibList[-1]


if __name__ == '__main__':
    input_n = int(input())
    print(fibonacci_number(input_n))
