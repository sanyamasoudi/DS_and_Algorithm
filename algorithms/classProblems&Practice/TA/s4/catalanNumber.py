import math

# روش اول اگه استفاده از تابع اماده امکانپذیر باشه
def ComputeCatalanNumber(n):
    c = (int)(math.factorial(2*n)/(math.factorial(n)*math.factorial(n+1)))
    return c

# روش دوم
def factorial(n):
    if n<=1:
        return n
    sum=n*factorial(n-1)
    return sum
def factorial2(n):
    arr=[0]*(n+1)
    arr[1]=1
    for i in range(2,n+1):
        arr[i]=arr[i-1]*i
    return arr[n] 
def factorial3(n):
    arr=[0]*(n+1)
    arr[1]=1
    for i in range(2,n+1):
        arr[i]=arr[i-1]*i
    return arr[n] 
def ComputeCatalanNumber2(n):
    c = (int)(factorial(2*n)/(factorial(n)*factorial(n+1)))
    return c
if __name__ == '__main__':
    # for item in range(1, 11):
    #     print(ComputeCatalanNumber(item))
    print(factorial2(3))