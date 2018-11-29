class Node:
    def __init__(self, info):
        self.info = info
        self.left = None
        self.right = None
        self.level = None

    def __str__(self):
        return str(self.info)

class BinarySearchTree:
    def __init__(self):
        self.root = None

    def create(self, val):
        if self.root == None:
            self.root = Node(val)
        else:
            current = self.root

            while True:
                if val < current.info:
                    if current.left:
                        current = current.left
                    else:
                        current.left = Node(val)
                        break
                elif val > current.info:
                    if current.right:
                        current = current.right
                    else:
                        current.right = Node(val)
                        break
                else:
                    break

"""
Node is defined as
self.left (the left child of the node)
self.right (the right child of the node)
self.info (the value of the node)
"""
def levelOrder(root):
    # Initialize a queue
    queue = []
    if root is None:
        return
    # Enqueueueue a root node
    queue.append(root)

    # Loop until popping all the nodes in the queue
    while(len(queue) > 0):
        # Print a value of a parent node
        print(queue[0].info, end=" ")

        # Save the parent node temporally
        temp_node = queue.pop(0)

        # If the parent node has left node,
        # append it to the queue list
        if temp_node.left:
            queue.append(temp_node.left)

        # If the parent node has right node,
        # append it to the queue list
        if temp_node.right:
            queue.append(temp_node.right)

tree = BinarySearchTree()
t = int(input())

arr = list(map(int, input().split()))

for i in range(t):
    tree.create(arr[i])

levelOrder(tree.root)
