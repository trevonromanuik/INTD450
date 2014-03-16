import time
import string
import sys
import winshell

print("Decrypting\n")
for n in range(50):
	time.sleep(0.1)
	print(".", end="")
	sys.stdout.flush()

print("\nDecryption successful.")
sys.stdout.flush()
time.sleep(2)