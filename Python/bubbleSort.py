# Implementation of Bubble Sort in Python
'''
Bubble Sort repeatedly compares each pair of adjacent items and swaps them
if one is bigger than another.

Big(O)
Worst case performance: O(N^2)
Best case performance: O(N)
Average case performance: O(n^2)
'''

def bubbleSort(unsorted_list):
    _length = len(unsorted_list)

    for i in range(_length):
        for j in range(0, _length-i-1):
            if unsorted_list[j] > unsorted_list[j+1]:
                unsorted_list[j], unsorted_list[j+1] = unsorted_list[j+1], unsorted_list[j]
    return unsorted_list

if __name__ == "__main__":
    user_input = input('Enter numbers separated by a comma "," : ').strip()
    unsorted_list = [int(item) for item in user_input.split(",")]  # Create a unsorted number list
    sorted_list = bubbleSort(unsorted_list)
    print(sorted_list)
