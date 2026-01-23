from questions_marks import QuestionsMarks
import pytest


test_cases = [
    # (strParam, expected)
    ('abc', 'false'),
    ('6??4', 'false'),
    ('aa6?9', 'false'),
    ('acc?7??sss?3rr1??????5', 'true'),
    ('arrb6???4xxbl5???eee5', 'true'),
    ('9???1???9???1???9', 'true'),
    ('9???1???9??1???9', 'false'),
    ('5??aaaaaaaaaaaaaaaaaaa?5?5', 'false'),
    ('5??aaaaaaaaaaaaaaaaaaa?5?a??5', 'true'),
]


@pytest.mark.parametrize('strParam, expected', test_cases)
def test_QuestionsMarks(strParam, expected):
    assert QuestionsMarks(strParam) == expected
