'''
Find Intersection
https://coderbyte.com/information/Find%20Intersection

Have the function FindIntersection(strArr) read the array of strings stored in strArr which will contain 2 elements:
the first element will represent a list of comma-separated numbers sorted in ascending order, the second element will
represent a second list of comma-separated numbers (also sorted). Your goal is to return a comma-separated string
containing the numbers that occur in elements of strArr in sorted order. If there is no intersection, return the string
false.

Example 1
    Input: ["1, 3, 4, 7, 13", "1, 2, 4, 13, 15"]
    Output: "1, 4, 13"
Example 2
    Input: ["1, 3, 9, 10, 17, 18", "1, 4, 9, 10"]
    Output: "1, 9, 10"
Example 3
    Input: ["1, 2, 3, 4, 5", "6, 7, 8, 9, 10"]
    Output: "false"
'''


def FindIntersection(strArr):
    # code goes here
    set0 = set([int(x) for x in strArr[0].split(',')])
    set1 = set([int(x) for x in strArr[1].split(',')])
    intersection = sorted(list(set0 & set1))
    if len(intersection) == 0:
        return 'false'
    return ', '.join(str(x) for x in intersection)


# # keep this function call here
# print(FindIntersection(input()))
