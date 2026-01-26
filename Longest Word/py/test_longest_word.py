import json
import pathlib
import pytest
from longest_word import LongestWord

root = pathlib.Path(__file__).resolve().parents[1]
test_cases_path = root / "test_cases.json"

with open(test_cases_path) as f:
    test_cases = json.load(f)


@pytest.mark.parametrize('sen, expected', test_cases)
def test_LongestWord(sen, expected):
    assert LongestWord(sen) == expected
