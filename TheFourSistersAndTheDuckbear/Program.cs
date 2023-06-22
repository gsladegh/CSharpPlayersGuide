/* 
 * Challenge The Four Sisters and the Duckbear 100 XP
Four sisters own a chocolate farm and collect chocolate eggs laid by chocolate chickens every day. But 
more often than not, the number of eggs is not evenly divisible among the sisters, and everybody knows 
you cannot split a chocolate egg into pieces without ruining it. The arguments have grown more heated 
over time. The town is tired of hearing the four sisters complain, and Chandra, the town’s Arbiter, has 
finally come up with a plan everybody can agree to. All four sisters get an equal number of chocolate 
eggs every day, and the remainder is fed to their pet duckbear. All that is left is to have some skilled 
Programmer build a program to tell them how much each sister and the duckbear should get. 
Objectives: 
• Create a program that lets the user enter the number of chocolate eggs gathered that day.
• Using / and %, compute how many eggs each sister should get and how many are left over for the
duckbear.
• Answer this question: What are three total egg counts where the duckbear gets more than each 
sister does? You can use the program you created to help you find the answer
 */

string chocolateEggsText;
int numberOfSisters = 4;

Console.WriteLine("Enter the number of chocolate eggs that the chocolate chickens laid today: ");
chocolateEggsText = Console.ReadLine();

int chocolateEggsInt = Convert.ToInt32(chocolateEggsText);
int numberOfEggsPerSister = chocolateEggsInt / numberOfSisters;
int remainingEggsForDuckbear = chocolateEggsInt % numberOfSisters;

Console.WriteLine("The sisters get " + numberOfEggsPerSister + " eggs each.");
Console.WriteLine("The duckbear gets " + remainingEggsForDuckbear);

Console.ReadLine();