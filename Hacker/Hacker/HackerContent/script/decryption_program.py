import time
import string
import sys

def caesar(plaintext, shift):
    alphabet = string.ascii_lowercase
    shifted_alphabet = alphabet[shift:] + alphabet[:shift]
    table = str.maketrans(alphabet, shifted_alphabet)
    return plaintext.translate(table)
	
inFile = "Tech_Analysis.txt"
outFile = "Cipher_Result.txt"
offset = 18

print("Decrypting\n")
for n in range(50):
	time.sleep(0.1)
	print(".", end="")
	sys.stdout.flush()
print("\nDecryption successful.")

with open(inFile) as inText:
	with open(outFile, 'w') as outText:
		outText.write(caesar(inText.read(), offset))
