/*
 *  Challenge The Replicator of D’To 100 XP
 *  
    While searching an abandoned storage building containing strange code artifacts, you uncover the 
    ancient Replicator of D’To. This can replicate the contents of any int array into another array. But it 
    appears broken and needs a Programmer to reforge the magic that allows it to replicate once again.

    Objectives:

    • Make a program that creates an array of length 5.
    • Ask the user for five numbers and put them in the array.
    • Make a second array of length 5.
    • Use a loop to copy the values out of the original array and into the new one.
    • Display the contents of both arrays one at a time to illustrate that the Replicator of D’To works 
    again

 */

Console.WriteLine("The Replicator of D'To");
int i = 0;
int[] array1 = new int[5];

while (i < 5)
{
    Console.Write("Enter a number for the first array: ");
    array1[i] = Convert.ToInt32(Console.ReadLine());
    i++;
}

Console.WriteLine("You are finished.  Copying numbers to new array");
int[] array2 = new int[5];
for (int j = 0; j < array1.Length; j++)
{
    array2[j] = array1[j];
}

Console.WriteLine("Array 1");
for (int k = 0; k < array1.Length; k++)
{
    Console.WriteLine($"array1[{k}]: {array1[k]}");
}

Console.WriteLine("Array 2");
for (int l = 0; l < array2.Length; l++)
{
    Console.WriteLine($"array2[{l}]: {array2[l]}");
}