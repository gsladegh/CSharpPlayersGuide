Console.Title = "Defense of Consolas";

Console.Write("Target Row? ");
int row = Convert.ToInt32(Console.ReadLine());

Console.Write("Target Column? ");
int column = Convert.ToInt32(Console.ReadLine());

string defensePoint1 = @$"({row}, {column - 1})";
string defensePoint2 = @$"({row - 1}, {column})";
string defensePoint3 = @$"({row}, {column + 1})";
string defensePoint4 = @$"({row + 1}, {column})";

Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Red;

// interesting that if you do a clear it will change the whole window, if not, just the text
//Console.Clear();

Console.WriteLine("Deploy to:");
Console.WriteLine(defensePoint1);
Console.WriteLine(defensePoint2);
Console.WriteLine(defensePoint3);
Console.WriteLine(defensePoint4);

Console.Beep();