/*
 * Challenge Watchtower 100 XP
 * 
    There are watchtowers in the region around Consolas that can alert 
    you when an enemy is spotted. With some help from you, they can tell 
    you which direction the enemy is from the watchtower.

    Objectives:
    • Ask the user for an x value and a y value. These are coordinates of 
    the enemy relative to the watchtower’s location.
    • Using the image on the right, if statements, and relational 
    operators, display a message about what direction the enemy is 
    coming from. For example, “The enemy is to the northwest!” or 
    “The enemy is here!”

 */

int x;
int y;

Console.Write("Enter x value: ");
x = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter y value: ");
y = Convert.ToInt32(Console.ReadLine());

if (x < 0 && y > 0)
{
    Console.WriteLine("");
}