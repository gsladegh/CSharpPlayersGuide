/*
 *  You spot something shiny, half-buried in the mud. You pull it out and realize that it seems to be some 
    mechanical automaton with the words “Property of Dynamak” etched into it. As you knock off the cakedon mud, you realize that it seems like this old automaton might even be programmable if you can give it 
    the proper commands. The automaton seems to be structured like this:

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
    }

    You don’t see a definition of that RobotCommand class. Still, you think you might be able to recreate it 
    (a class with only an abstract Run command) and then make derived classes that extend RobotCommand
    that move it in each of the four directions and power it on and off. (You wish you could manufacture a 
    whole army of these!)

    Objectives:
    • Copy the code above into a new project.
    • Create a RobotCommand class with a public and abstract void Run(Robot robot) method. (The 
    code above should compile after this step.)
    • Make OnCommand and OffCommand classes that inherit from RobotCommand and turn the robot 
    on or off by overriding the Run method.
    • Make a NorthCommand, SouthCommand, WestCommand, and EastCommand that move the robot 1 
    unit in the +Y direction, 1 unit in the -Y direction, 1 unit in the -X direction, and 1 unit in the +X 
    direction, respectively. Also, ensure that these commands only work if the robot’s IsPowered
    property is true. 
    • Make your main method able to collect three commands from the console window. Generate new 
    RobotCommand objects based on the text entered. After filling the robot’s command set with these 
    new RobotCommand objects, use the robot’s Run method to execute them. For example:

    on
    north
    west
    [0 0 True]
    [0 1 True]
    [-1 1 True]
    • Note: You might find this strategy for making commands that update other objects useful in some 
    of the larger challenges in the coming levels.

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
        if(!robot.IsPowered)
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
        if(!robot.IsPowered)
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

