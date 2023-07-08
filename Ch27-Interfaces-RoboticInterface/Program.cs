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
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }

    // don't need
    // public void SetCommands(RobotCommand[] robotCommands) => Commands = robotCommands;
}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (!robot.IsPowered)
        {
            return;
        }

        robot.Y++;
    }
}
public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (!robot.IsPowered)
        {
            return;
        }
        robot.Y--;
    }
}
public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (!robot.IsPowered)
        {
            return;
        }
        robot.X--;
    }
}
public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (!robot.IsPowered)
        {
            return;
        }
        robot.X++;
    }
}
