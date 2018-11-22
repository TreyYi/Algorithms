from sys import argv

class Node:

    def __init__(self, value, parent):
        self.value = value
        self.left = None
        self.right = None
        self.parent = parent

    def setLeft(self, left):
        self.left = left

    def setRight(self, right):
        self.right = right

    def setParent(self, parent):
        self.parent = parent

    def getValue(self):
        return self.value

    def getLeft(self):
        return self.left

    def getRight(self):
        return self.right

    def getParent(self):
        return self.parent

class BinarySearchTree:

    def __init__(self):
        self.root = None

    def insert(self, value):

        # Create a new node object
        newNode = Node(value, None)
        # If it's a empty tree (no root)
        if (self.isEmpty()):
            self.root = newNode
        else:
            # If it has a root
            currentNode = self.root
            # loop to find a leaf.
            # Get a leaf node
            while currentNode is not None:
                parentNode = currentNode
                # get currentNode's left or right subtree
                # to insert a newNode.
                if newNode.getValue() < currentNode.getValue():
                    currentNode = currentNode.getLeft()
                else:
                    currentNode = currentNode.getRight()
            # Set a newNode to a leaf node
            if newNode.getValue() < parentNode.getValue():
                parentNode.setLeft(newNode)
            else:
                parentNode.setRight(newNode)
            # Set a parent node for the new node
            newNode.setParent(parentNode)

    # Check if the tree is empty
    # or you can say we check if the root node is empty
    def isEmpty(self):
        if (self.root is None):
            return True
        return False

# Inorder: Left, Root, Right
# Each parent node is visited before(pre) its children
def inorder(bst):
    if bst is None:
        return
    print(bst.getValue())
    inorder(bst.getLeft())
    inorder(bst.getRight())

# Preorder: Root, Left, Right
# Each parent node is visited in between its children
def preorder():
    print()

# Postorder: Left, Right, Root
# Each parent node is visited after(post) its children
def postorder():
    print()


if __name__ == "__main__":
    tree = BinarySearchTree()
    tree.insert(10)
    tree.insert(12)
    tree.insert(1)
    tree.insert(4)
    tree.insert(5)
    tree.insert(11)
    tree.insert(0)
    inorder(tree.root)
