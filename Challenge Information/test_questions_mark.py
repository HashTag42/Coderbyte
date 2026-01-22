from questions_mark import QuestionsMark
import pytest


test_cases = [
    # (strParam, expected)
    ('aa6?9', 'false'),
    ('acc?7??sss?3rr1??????5', 'true'),
    ('arrb6???4xxbl5???eee5', 'true'),
]


@pytest.mark.parametrize('strParam, expected', test_cases)
def test_QuestionsMark(strParam, expected):
    assert QuestionsMark(strParam) == expected
