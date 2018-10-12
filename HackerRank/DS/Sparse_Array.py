#!/bin/python3

import os
import sys

if __name__ == '__main__':
    N = int(input())
    n_arr = []
    for n in range(N):
        strings = input().rstrip().split()
        n_arr.append(strings)

    Q = int(input())
    q_arr = []
    for q in range(Q):
        queries = input().rstrip().split()
        q_arr.append(queries)

    count = 0
    for query in q_arr:
        for string in n_arr:
            if query == string:
                count += 1
        if count != 0:
            print (count)
            count = 0
        else:
            count = 0
            print (count)
