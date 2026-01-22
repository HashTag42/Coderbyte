from first_factorial import FirstFactorial
import pytest


test_cases = [
    # (num, expected)
    (0, 1),
    (1, 1),
    (2, 2),
    (3, 6),
    (8, 40320),
    (20, 2432902008176640000),
]


@pytest.mark.parametrize('num, expected', test_cases)
def test_FirstFactorial(num, expected):
    assert FirstFactorial(num) == expected
