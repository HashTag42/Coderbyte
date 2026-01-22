from codeland_username_validation import CodelandUsernameValidation
import pytest


test_cases = [
    # (strParam, expected)
    ('aa_', 'false'),
    ('u__hello_world123', 'true'),
    ('aaaaaaaaaa', 'true'),
    ('1aaaaaaaaaa', 'false'),
    ('aaaaa*aaaaa', 'false'),
    ('aaaaaaaaaa_', 'false'),
]


@pytest.mark.parametrize('strParam, expected', test_cases)
def test_codeland_username_validation(strParam, expected):
    assert CodelandUsernameValidation(strParam) == expected
