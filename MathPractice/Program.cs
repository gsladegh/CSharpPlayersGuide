// prefix / postfix
/*
 *  Whether we do x++ or ++x, x is incremented and will have a value of 6 after each code block. 
    But in the first part, ++x will evaluate to 6 (increment first, then produce the new value of x), 
    so y will have a value of 6 as well. The second part, in contrast, evaluates to x’s original value 
    of 5, which is assigned to z, even though x is incremented to 6. 
    The same logic applies to the -- operator.
    C# programmers rarely, if ever, use ++ and -- as a part of an expression. It is far more common 
    to use it as a standalone statement, so these nuances are rarely significant
 */

int x;

// x increment happens before assignment to y
x = 5;
int y = ++x;
Console.WriteLine("x = " + x);
Console.WriteLine("y = " + y);


// x increment happens after assignment to z
x = 5;
int z = x++;
Console.WriteLine("x = " + x);
Console.WriteLine("z = " + z);



short a = 2;
short b = 3;
int total = a + b; // a and b are converted to ints automatically.
Console.WriteLine("short add of 2+3 without a cast: " + total);

short newtotal = (short)(a + b);
Console.WriteLine("short add of 2+3 with (short) cast: " + newtotal);

int amountDone = 20;
int amountToDo = 100;
double fractionDone = amountDone / amountToDo;
Console.WriteLine("double fraction with int values: " + fractionDone);

int amountDone2 = 20;
int amountToDo2 = 100;
double fractionDone2 = (double)amountDone2 / amountToDo2;
Console.WriteLine("double fraction with int values: " + fractionDone2);

// adding parens changes the order of precedence
int amountDone3 = 20;
int amountToDo3 = 100;
double fractionDone3 = (double)(amountDone3 / amountToDo3);
Console.WriteLine("double fraction with int value expression in parens: " + fractionDone3);


float floata = 10000;
float floatb = 0.00001f;
float sum = floata + floatb;
Console.WriteLine(sum);
double sum2 = (double)floata + floatb;
Console.WriteLine(sum2);

// note that you can NOT cast decimal to added float values - below will not compile
// float floatc = 10000;
// float floatd = 0.00001f;
// decimal sume = (decimal)floatc + floatd;

float floatc = 10000;
float floatd = 0.00001f;
decimal sume = (decimal)(floatc + floatd);
Console.WriteLine("sume: " + sume); // evaluates to 10000 because the float add is done first

decimal decimalvalue1 = 10000;
decimal decimalvalue2 = 0.00001M;
decimal sum3 = decimalvalue1 + decimalvalue2;
Console.WriteLine(sum3);
