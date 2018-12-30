import math

def diagonal_difference(arr):
    arr_len = len(arr)
    front_index = 0  #start point
    back_index = -1  #end point
    result = []
    for i in range(arr_len):
        result.append(arr[i][front_index]-arr[i][back_index])
        # print(arr[i][front_index], arr[i][back_index])
        front_index += 1
        back_index -= 1
        # print("debug:", result)
    return abs(sum(result))

if __name__ == "__main__":

    num_of_lines = int(input().strip())

    arr = []

    for _ in range(num_of_lines):
        a = list(map(int, input().strip().split()))
        arr.append(a)
    result = diagonal_difference(arr)
    print(result)
