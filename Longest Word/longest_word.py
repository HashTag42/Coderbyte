'''
Longest Word
https://coderbyte.com/information/Longest%20Word

Have the function LongestWord(sen) take the sen parameter being passed and return the longest word in the string.
If there are two or more words that are the same length, return the first word from the string with that length.
Ignore punctuation and assume sen will not be empty. Words may also contain numbers, for example "Hello world123 567"
'''


def LongestWord(sen: str) -> str:
    # code goes here
    def cleanup(word: str) -> str:
        return ''.join(ch for ch in word if ch.isalnum())
    words = [cleanup(w) for w in sen.split()]
    return max(words, key=len)


# # keep this function call here
# print(LongestWord(input()))
