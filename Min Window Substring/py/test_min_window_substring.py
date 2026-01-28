import json
import pathlib
import pytest
from min_window_substring import MinWindowSubstring

root = pathlib.Path(__file__).resolve().parents[1]
test_cases_path = root / "test_cases.json"

with open(test_cases_path) as f:
    test_cases = json.load(f)


@pytest.mark.parametrize('strArr, expected', test_cases)
def test_MinWindowSubstring(strArr, expected):
    assert MinWindowSubstring(strArr) == expected
