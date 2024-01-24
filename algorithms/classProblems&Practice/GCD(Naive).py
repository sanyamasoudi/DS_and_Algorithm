def GCD(a,b):
    max=0
    if a==0:return b
    elif b==0:return a
    else:
        for i in range(1,a+b):
            if a%i==0 and b%i==0:
                max=i
        return max
print(GCD(0,25))