import json
import pathlib
import pytest
from codeland_username_validation import CodelandUsernameValidation

root = pathlib.Path(__file__).resolve().parents[1]
test_cases_path = root / "test_cases.json"

with open(test_cases_path) as f:
    test_cases = json.load(f)


@pytest.mark.parametrize("strParam, expected", test_cases)
def test_codeland_username_validation(strParam, expected):
    assert CodelandUsernameValidation(strParam) == expected
