# theory_of_language_project_3
This program receives the Turing machine as input, decodes it, and then tests each of the input strings on the machine.
# input
The first line of input is a binary string (consisting of 0's and 1's) which is the encoded string of a Turing machine. In the second line of the input, there is an integer n, which represents the number of strings to be tested on the machine as input. Then in each of the next n lines, in each line a coded string comes as input, which must be tested on the implemented machine.
# output
The output of the program contains exactly n lines, in each line the test result of each input on the Turing machine is printed in order. If each entry is accepted, the word Accepted should be printed, otherwise, the word Rejected should be printed.
# example
input:
<br>
101101011011001010110101
<br>
3
<br>

11011011
<br>
110111011
<br>
output:
<br>
Accepted
<br>
Accepted
<br>
Rejected
