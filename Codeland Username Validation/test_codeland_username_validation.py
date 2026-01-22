from codeland_username_validation import CodelandUsernameValidation
import pytest


test_cases = [
    # (strParam, expected)
    ('aa_', False),
    ('u__hello_world123', True),
    ('aaaaaaaaaa', True),
    ('1aaaaaaaaaa', False),
    ('aaaaa*aaaaa', False),
    ('aaaaaaaaaa_', False),
]


@pytest.mark.parametrize('strParam, expected', test_cases)
def test_codeland_username_validation(strParam, expected):
    assert CodelandUsernameValidation(strParam) == expected
