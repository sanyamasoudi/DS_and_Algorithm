def fibNumberRecurs(n):
    if n<=1:
        return n
    else:
        return fibNumberRecurs(n-1)+fibNumberRecurs(n-2)
    

print(fibNumberRecurs(4))