/*
 *  Challenge The Laws of Freach 50 XP
 *  
    The town of Freach recently had an awful looping disaster. The lead investigator found that it was a faulty 
    ++ operator in an old for loop, but the town council has chosen to ban all loops but the foreach loop. 
    Yet Freach uses the code presented earlier in this level to compute the minimum and the average value 
    in an int array. They have hired you to rework their existing for-based code to use foreach loops 
    instead.

    Objectives:

    • Start with the code for computing an array’s minimum and average values in the section Some 
    Examples with Arrays, starting on page 94. 
    • Modify the code to use foreach loops instead of for loops.
 */

// find the smallest value
int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
int currentSmallest = int.MaxValue; // Start higher than anything in the array. 
foreach (int value in array)
{
    if (value < currentSmallest)
        currentSmallest = value;
}
Console.WriteLine(currentSmallest);

// find the average value
int[] array2 = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
int total = 0;
foreach (int value in array2)
    total += value;
float average = (float)total / array2.Length;
Console.WriteLine(average);