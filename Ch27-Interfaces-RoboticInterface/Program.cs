/*
 *  Challenge Robotic Interface 75 XP
 *  
    With your knowledge of interfaces, you realize you can refine the old robot you found in the mud to use 
    interfaces instead of the original design. Instead of an abstract RobotCommand base class, it could 
    become an IRobotCommand interface!

    Building on your solution to the Old Robot challenge, perform the changes below:

    Objectives:
    • Change your abstract RobotCommand class into an IRobotCommand interface. 
    • Remove the unnecessary public and abstract keywords from the Run method.
    • Change the Robot class to use IRobotCommand instead of RobotCommand. 
    • Make all of your commands implement this new interface instead of extending the RobotCommand
    class that no longer exists. You will also want to remove the override keywords in these classes.
    • Ensure your program still compiles and runs.
    • Answer this question: Do you feel this is an improvement over using an abstract base class? Why 
    or why not?

 */

Robot robot1 = new Robot();

// i am confused on why you can set the command here - unless it's at the array level 
for (int i = 0; i < robot1.Commands.Length; i++)
{
    Console.Write("Enter a Command (on, off, north, south, east, west): ");
    string choice = Console.ReadLine();

    robot1.Commands[i] = choice switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "east" => new EastCommand(),
        "west" => new WestCommand()
    };
}

robot1.Run();

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }

    // don't need
    // public void SetCommands(RobotCommand[] robotCommands) => Commands = robotCommands;
}

public interface IRobotCommand
{
    void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = true;
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = false;
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y++;
        }

        
    }
}
public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y--;
        }
        
    }
}
public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X--;
        }
        
    }
}
public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X++;
        }        
    }
}

// Answer this question: Do you feel this is an improvement over using an abstract base class? Why or why not?
//
// Author answer: In this situation, I think this is better. For starters, there's less code to do the same thing. No need
// to have those abstracts and overrides everywhere. But at a more substantial level, inheritance is a pretty
// strong relationship, and these commands do not really need to have that strong of a relationship to each
// other. The only thing that really binds them together is that they do the same type of thing. So I think
// it is better for that reason.