# Implementation of Bubble Sort in Python
'''
Bubble Sort repeatedly compares each pair of adjacent items and swaps them
if one is bigger than another.
'''

def bubbleSort(unsorted_list):
    _length = len(unsorted_list)

    for i in range(_length):
        for j in range(0, _length-i-1):
            if unsorted_list[j] > unsorted_list[j+1]:
                unsorted_list[j], unsorted_list[j+1] = unsorted_list[j+1], unsorted_list[j]
    return unsorted_list

if __name__ == "__main__":
    unsorted_list = [21, 23, 5, 46, 1, 4, 8, 96, 65, 85]  # Create a unsorted number list
    sorted_list = bubbleSort(unsorted_list)
    print(sorted_list)
