#!/bin/python3

import math
import os
import random
import re
import sys

# URL: https://www.hackerrank.com/challenges/two-strings/problem

# Complete the twoStrings function below.
def twoStrings(s1, s2):
    set_s1 = set(s1)
    set_s2 = set(s2)
    shared = set_s1.intersection(set_s2)
    return "NO" if shared == set() else "YES" # return string value "YES" or "NO"

if __name__ == '__main__':
    num_of_lines = int(input())
    result = ""
    for _ in range(num_of_lines):
        s1 = input()
        s2 = input()
        result = result + twoStrings(s1, s2) + "\n"
    print (result)
