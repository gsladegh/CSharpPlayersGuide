/* 
 * Challenge The Variable Shop 100 XP
 * You see an old shopkeeper struggling to stack up variables in a window display. “Hoo-wee! All these 
 * variable types sure are exciting but setting them all up to show them off to excited new programmers 
 * like yourself is a lot of work for these aching bones,” she says. “You wouldn’t mind helping me set up this 
 * program with one variable of every type, would you?”
 * Objectives:
 * • Build a program with a variable of all fourteen types described in this level.
 * • Assign each of them a value using a literal of the correct type.
 * • Use Console.WriteLine to display the contents of each variable.
 * 
 */

// INTEGER TYPES
byte aUnsignedByteMinValue = 0;
byte aUnsignedByteMaxValue = 255;

sbyte aSignedByteMinValue = -128;
sbyte aSignedByteMaxValue = 127;

short aSignedShortMinValue = -32_768;
short aSignedShortMaxValue = 32_767;

ushort aUnsignedShortMinValue = 0;
ushort aUnsignedShortMaxValue = 65_535;

int aSignedIntMinValue = -2_147_483_648;
int aSignedIntMaxValue = 2_147_483_647;

uint aUnsignedIntMinValue = 0;
uint aUnsignedIntMaxValue = 4_294_967_295;

long aSignedLongMinValue = -9_223_372_036_854_775_808;
long aSignedLongMaxValue = 9_223_372_036_854_775_807;

ulong aUnsignedLongMinValue = 0;
ulong aUnsignedLongMaxValue = 18_446_744_073_709_551_615;

// CHAR AND STRING TYPES
char aCharValue = 'a';
string aStringValue = "Here's a string!";

// FLOATING POINT TYPES
float aFloatValue = 3.5623f;
double aDoubleValue = 3.5623;
decimal aDecimalValue = 3.5623m; // m stands for monetary

// BOOOLEAN
bool aTrueBoolean = true;

Console.WriteLine("Here are all the variable types in C#!");
Console.WriteLine();

Console.WriteLine("INTEGER TYPES");
Console.WriteLine("Unsigned Byte Range: " + aUnsignedByteMinValue + " - " + aUnsignedByteMaxValue);
Console.WriteLine("Signed Byte Range: " + aSignedByteMinValue + " - " + aSignedByteMaxValue);
Console.WriteLine("Unsigned Short Range: " + aUnsignedShortMinValue + " - " + aUnsignedShortMaxValue);
Console.WriteLine("Signed Short Range: " + aSignedShortMinValue + " - " + aSignedShortMaxValue);
Console.WriteLine("Unsigned Int Range: " + aUnsignedIntMinValue + " - " + aUnsignedIntMaxValue);
Console.WriteLine("Signed Int Range: " + aSignedIntMinValue + " - " + aSignedIntMaxValue);
Console.WriteLine("Unsigned Long Range: " + aUnsignedLongMinValue + " - " + aUnsignedLongMaxValue);
Console.WriteLine("Signed Long Range: " + aSignedLongMinValue + " - " + aSignedLongMaxValue);
Console.WriteLine();

Console.ReadKey();

Console.WriteLine("CHAR AND STRING TYPES");
Console.WriteLine("Char: " + aCharValue);
Console.WriteLine("String: " + aStringValue);
Console.WriteLine();

Console.ReadKey();

Console.WriteLine("FLOATING TYPES");
Console.WriteLine("Float: " + aFloatValue);
Console.WriteLine("Double: " + aDoubleValue);
Console.WriteLine("Decimal: " + aDecimalValue);
Console.WriteLine();

Console.ReadKey();
Console.WriteLine("BOOLEAN TYPES");
Console.WriteLine("bool: " + aTrueBoolean);

