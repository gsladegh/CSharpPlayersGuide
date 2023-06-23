/* 
 * Challenge The Dominion of Kings 100 XP
    Three kings, Melik, Casik, and Balik, are sitting around a table, debating who has the greatest kingdom 
    among them. Each king rules an assortment of provinces, duchies, and estates. Collectively, they agree 
    to a point system that helps them judge whose kingdom is greatest: Every estate is worth 1 point, every 
    duchy is worth 3 points, and every province is worth 6 points. They just need a program that will allow 
    them to enter their current holdings and compute a point total.
    Objectives:
    • Create a program that allows users to enter how many provinces, duchies, and estates they have.
    • Add up the user’s total score, giving 1 point per estate, 3 per duchy, and 6 per province.
    • Display the point total to the user 
 */

// KING MELIK
Console.WriteLine("King Melik!  Enter the number of provinces in your kingdom: "); 
int MelikProvinces = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("King Melik!  Enter the number of duchies in your kingdom: ");
int MelikDuchies = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("King Melik! Enter the number of estates in your kingdom: ");
int MelikEstates = Convert.ToInt32(Console.ReadLine());

int MelikPoints = MelikProvinces * 6 + MelikDuchies * 3 + MelikEstates;

// KING CASIK
Console.WriteLine("King Casik!  Enter the number of provinces in your kingdom: ");
int CasikProvinces = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("King Casik!  Enter the number of duchies in your kingdom: ");
int CasikDuchies = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("King Casik! Enter the number of estates in your kingdom: ");
int CasikEstates = Convert.ToInt32(Console.ReadLine());

int CasikPoints = CasikProvinces * 6 + CasikDuchies * 3 + CasikEstates;

// KING BALIK
Console.WriteLine("King Balik!  Enter the number of provinces in your kingdom: ");
int BalikProvinces = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("King Balik!  Enter the number of duchies in your kingdom: ");
int BalikDuchies = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("King Balik! Enter the number of estates in your kingdom: ");
int BalikEstates = Convert.ToInt32(Console.ReadLine());

int BalikPoints = BalikProvinces * 6 + BalikDuchies * 3 + BalikEstates;

// Display Kingdom results
Console.WriteLine("The Melik Kingdom Points: " + MelikPoints);
Console.WriteLine("The Casik Kingdom Points: " + CasikPoints);
Console.WriteLine("The Balik Kingdom Points: " + BalikPoints);
