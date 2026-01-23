import json
import pathlib
import pytest
from find_intersection import FindIntersection

root = pathlib.Path(__file__).resolve().parents[1]
test_cases_path = root / "test_cases.json"

with open(test_cases_path) as f:
    test_cases = json.load(f)


@pytest.mark.parametrize('strArr, expected', test_cases)
def test_FindIntersection(strArr, expected):
    assert FindIntersection(strArr) == expected
