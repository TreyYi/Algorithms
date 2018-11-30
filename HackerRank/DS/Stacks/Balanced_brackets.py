#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the isBalanced function below.
def isBalanced(s):
    dic = { ')': '(', ']': '[', '}': '{' }
    open_bracket = ['(', '{', '[']
    stack = []
    for char in s:
        if not stack: # when the stack is empty
            stack.append(char)
        elif char in open_bracket: # add an open bracket
            stack.append(char)
        elif dic.get(char) == stack[-1]: # when char is closed bracket
            stack.pop()
        else:
            return "NO"
    return "NO" if stack else "YES"


if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    t = int(input())

    for t_itr in range(t):
        s = input()

        result = isBalanced(s)

        fptr.write(result + '\n')

    fptr.close()
