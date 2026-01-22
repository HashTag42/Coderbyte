from first_reverse import FirstReverse
import pytest


test_cases = [
    # (strParam, expected)
    ('coderbyte', 'etybredoc'),
    ('Coderbyte', 'etybredoC'),
    ('I Love Code', 'edoC evoL I'),
]


@pytest.mark.parametrize('strParam, expected', test_cases)
def test_FirstReverse(strParam, expected):
    assert FirstReverse(strParam) == expected
