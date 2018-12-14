import random

def quick_sort(arr):
    # if array is empty or has only 1 element
    # it means the array is already sorted, so return it.
    if len(arr) < 2:
        return arr
    else:
        rand_index = random.randint(0,len(arr)-1)
        pivot = arr[rand_index]
        less = []
        greater = []
        equals = []

        # create less and greater array comparing with pivot
        for i in arr:
            if i < pivot:
                less.append(i)
            elif i > pivot:
                greater.append(i)
            else:
                equals.append(i)

        return quick_sort(less) + equals + quick_sort(greater)

if __name__ == "__main__":
    sample_array = [6,3,7,2,7,4,7,3,21,54,0,6,5,3,1,3]
    sorted_array = quick_sort(sample_array)
    print(sorted_array)

# more Pythonic way
# def quick_sort(L):
#     if L: return quick_sort([x for x in L if x<L[0]]) + [x for x in L if x==L[0]] + quick_sort([x for x in L if x>L[0]])
#     return []
