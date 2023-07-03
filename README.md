# **Integer-Multiplication**
This is a code that takes two byte arrays as input and the size N. it always assumes N is a power of 2. With my code is some test cases added by algorithms course prof to test if the code is functional or not.
	This code uses the divide and conquer algorithm. 
	I will add comments later to make my code more clear.
	In my free time, i will try to make my code more efficient and better.

# **Usage**
You can find the code under IntegerMultiplication -> IntegerMultiplication.cs.

You have to give in two arrays of integers as input and the size N and it will calculate the result between them.

# **Functions**
#### IntegerMultiply(byte[] X, byte[] Y, int N) 
	returns byte array with the result 
  	Performs naive multiplication if N is small, else splits code into A, B, C, and D and multiplies AC and BD, and adds AB and CD then calls itself multiplying the 			two additions.
#### Subtract(byte[] a, byte[] b)
	returns byte array with the result 
 	subtracts two byte arrays with regards to the carry as every index can hold only one digit.
#### Add(byte[] a, byte[] b)
	returns byte array with the result 
 	adds two byte arrays with regards to the carry as every index can hold only one digit.
#### ResizeArray(byte[] array, int newSize)
		returns byte array with the result 
		resizes array to wished new size.
#### NaiveMult(int N , byte[] X , byte[] Y) 
		returns byte array with the result 
		performs naive multiplication when the recursive one is not needed as N is too small. 
# Test cases
![image](https://github.com/playboikairoo/IntegerMultiplication-in-C-using-karatsuba-and-byte-arrays/assets/103595234/55e32cdc-f7bb-4aa2-8322-b8bc50cd14cd)
![image](https://github.com/playboikairoo/IntegerMultiplication-in-C-using-karatsuba-and-byte-arrays/assets/103595234/983bd3c8-c4b0-4941-b7ac-cfda2930e7dd)

# Contributing
Contributions to this library are welcome! If you find a bug or have a feature request, please open an issue on the GitHub repository.

# Contact
If you have any questions or concerns about this library, please feel free to contact me at alhusseingomma194@gmail.com
 
