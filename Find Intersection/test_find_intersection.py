from find_intersection import FindIntersection
import pytest


test_cases = [
    # (strArr, expected)
    (["1, 3, 4, 7, 13", "1, 2, 4, 13, 15"], "1, 4, 13"),
    (["1, 3, 9, 10, 17, 18", "1, 4, 9, 10"], "1, 9, 10"),
    (["1, 2, 3, 4, 5", "6, 7, 8, 9, 10"], "false"),
]


@pytest.mark.parametrize('strArr, expected', test_cases)
def test_FindIntersection(strArr, expected):
    assert FindIntersection(strArr) == expected
