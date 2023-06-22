Console.WriteLine("What kind of thing are we talking about?");
string a = Console.ReadLine(); /* names the thing */
Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
string b = Console.ReadLine(); /* describes the thing */
string c = "Doom"; /* type of thing it is */
string d = "3000"; /* version of the thing */
Console.WriteLine("The " + b + " " + a + " of " + c + " " + d + "!");