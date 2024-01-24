def EuclideanGCD(a,b):
    while(True):
        if b==0:
            return a
        r=a%b
        return EuclideanGCD(b,r)
    
print(EuclideanGCD(25,15))