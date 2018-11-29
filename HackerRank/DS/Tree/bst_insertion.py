class Node:
    def __init__(self, info):
        self.info = info
        self.left = None
        self.right = None
        self.level = None

    def __str__(self):
        return str(self.info)

def preOrder(root):
    if root == None:
        return
    print (root.info, end=" ")
    preOrder(root.left)
    preOrder(root.right)

class BinarySearchTree:
    def __init__(self):
        self.root = None

#Node is defined as
#self.left (the left child of the node)
#self.right (the right child of the node)
#self.info (the value of the node)

    def insert(self, val):
            # Create a new node with a given value
            new_node = Node(val)
            # if the root is empty, then set.
            if self.root is None:
                self.root = new_node
            else:
                temp_node = self.root
                # Find a leaf to add a new node
                while(temp_node is not None):
                    # Save temp_node as a parent node
                    # before temp_node gets empty below
                    parent_node = temp_node
                    # Find a leaf node and set it into temp_node
                    if new_node.info < temp_node.info:
                        temp_node = temp_node.left
                    else:
                        temp_node = temp_node.right
                if new_node.info < parent_node.info:
                    parent_node.left = new_node
                else:
                    parent_node.right = new_node
                # TODO: Actually after all, must add a parent node to the new node
                # However, since there's no parent attribute in Node class,
                # we skip this process for now.


tree = BinarySearchTree()
t = int(input())

arr = list(map(int, input().split()))

for i in range(t):
    tree.insert(arr[i])

preOrder(tree.root)
