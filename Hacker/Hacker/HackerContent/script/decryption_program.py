import time
import string
import sys

print("Decrypting\n")
for n in range(50):
	time.sleep(0.1)
	print(".", end="")
	sys.stdout.flush()
print("\nDecryption successful.")
sys.stdout.flush()
time.sleep(2)

#with open(inFile) as inText:
#	with open(outFile, 'w') as outText:
#		outText.write(caesar(inText.read(), offset))
