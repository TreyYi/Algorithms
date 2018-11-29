#!/bin/python3

import math
import os
import random
import re
import sys

class SinglyLinkedListNode:
    def __init__(self, node_data):
        self.data = node_data
        self.next = None

class SinglyLinkedList:
    def __init__(self):
        self.head = None
        self.tail = None

    def insert_node(self, node_data):
        # Create a new node with a given node_data
        node = SinglyLinkedListNode(node_data)

        # Set a new node as a head if it's None
        if not self.head:
            self.head = node
        # Else, link a new node as self's next node
        else:
            self.tail.next = node
        # Set the new node as new tail of self node
        self.tail = node

def printLinkedList(head):
    if (head != None):
        if (head.next != None):
            print(head.data)
            printLinkedList(head.next)
        else:
            print(head.data)

if __name__ == '__main__':
    llist_count = int(input())

    llist = SinglyLinkedList()

    for _ in range(llist_count):
        llist_item = int(input())
        llist.insert_node(llist_item)

    printLinkedList(llist.head)
