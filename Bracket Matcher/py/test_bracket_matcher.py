import json
import pathlib
import pytest
from bracket_matcher import BracketMatcher

root = pathlib.Path(__file__).resolve().parents[1]
test_cases_path = root / "test_cases.json"

with open(test_cases_path) as f:
    test_cases = json.load(f)


@pytest.mark.parametrize('strParam, expected', test_cases)
def test_BracketMatcher(strParam, expected):
    assert BracketMatcher(strParam) == expected
