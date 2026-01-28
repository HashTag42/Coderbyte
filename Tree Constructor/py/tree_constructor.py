'''
Tree Constructor
https://coderbyte.com/information/Tree%20Constructor

Have the function TreeConstructor(strArr) take the array of strings stored in strArr, which will contain pairs of
integers in the following format: (i1,i2), where i1 represents a child node in a tree and the second integer i2
signifies that it is the parent of i1. For example: if strArr is ["(1,2)", "(2,4)", "(7,2)"], then this forms the
following tree:

      4
     2
    1 7

which you can see forms a proper binary tree. Your program should, in this case, return the string true because a valid
binary tree can be formed. If a proper binary tree cannot be formed with the integer pairs, then return the string
false. All of the integers within the tree will be unique, which means there can only be one node in the tree with the
given integer value.

Example 1
    Input: ["(1,2)", "(2,4)", "(5,7)", "(7,2)", "(9,5)"]
    Output: "true"
Example 2
    Input: ["(1,2)", "(3,2)", "(2,12)", "(5,2)"]
    Output: "false"
'''


def TreeConstructor(strArr) -> str:
    parent_child_count = {}  # Track how many children each parent has
    child_parent_count = {}  # Track how many parents each child has

    for pair in strArr:
        # Parse "(child,parent)" - remove parentheses and split
        nums = pair.strip("()").split(",")
        child = int(nums[0])
        parent = int(nums[1])

        # Count children for each parent
        parent_child_count[parent] = parent_child_count.get(parent, 0) + 1
        # Count parents for each child
        child_parent_count[child] = child_parent_count.get(child, 0) + 1

        # Binary tree: parent can have at most 2 children
        if parent_child_count[parent] > 2:
            return "false"

        # Each node can have only 1 parent
        if child_parent_count[child] > 1:
            return "false"

    return "true"
