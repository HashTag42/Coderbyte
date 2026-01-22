from longest_word import LongestWord
import pytest


test_cases = [
    # (sen, expected)
    ('fun&!! time', 'time'),
    ('I love dogs', 'love'),
]


@pytest.mark.parametrize('sen, expected', test_cases)
def test_LongestWord(sen, expected):
    assert LongestWord(sen) == expected
