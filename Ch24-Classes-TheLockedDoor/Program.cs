/*
 *  The fourth pedestal demands constructing a door class with a locking mechanism that requires a unique
    numeric code to unlock. You have done something similar before without using a class, but the locking 
    mechanism is new. The door should only unlock if the passcode is the right one. The following statements 
    describe how the door works.

    • An open door can always be closed. 
    • A closed (but not locked) door can always be opened.
    • A closed door can always be locked.
    • A locked door can be unlocked, but a numeric passcode is needed, and the door will only unlock if 
    the code supplied matches the door’s current passcode.
    • When a door is created, it must be given an initial passcode.
    • Additionally, you should be able to change the passcode by supplying the current code and a new 
    one. The passcode should only change if the correct, current code is given. 

    Objectives:
    • Define a Door class that can keep track of whether it is locked, open, or closed.

    • Make it so you can perform the four transitions defined above with methods. 

    • Build a constructor that requires the starting numeric passcode.

    • Build a method that will allow you to change the passcode for an existing door by supplying the 
    current passcode and new passcode. Only change the passcode if the current passcode is correct.

    • Make your main method ask the user for a starting passcode, then create a new Door instance. Allow 
    the user to attempt the four transitions described above (open, close, lock, unlock) and change the 
    code by typing in text commands.

 */



Door door = CreateNewDoor();
PlayWithDoor(door);
Console.WriteLine("ALL DONE!");

void PlayWithDoor(Door door)
{
    string choice = "";
    while(choice != "quit")
    {
        Console.Write("What would you like to do with the door? (open, close, lock, unlock, change passcode, quit): ");
        choice = Console.ReadLine();

        switch (choice)
        {
            case "open":
                if(door.OpenDoor())
                {
                    Console.WriteLine("You opened the door.");
                }
                break;
            case "close":
                if (door.CloseDoor())
                {
                    Console.WriteLine("You closed the door");
                }
                break;
            case "unlock": 
                if(door.UnlockDoor())
                {
                    Console.WriteLine("You unlocked the door.");
                }
                break;
            case "lock":
                if(door.LockDoor())
                {
                    Console.WriteLine("You locked the door.");
                }
                break;
            case "change passcode":
                ChangePasscode();
                break;
            case "quit":
                break;
            default:
                Console.WriteLine("I don't understand that command. Try again.");
                break;
        }
    }
}

Door CreateNewDoor()
{
    Console.Write("Create a new door with a new passcode: ");
    int passCode = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"You entered {passCode}! Don't forget it!");
    Door door = new Door(passCode);
    Console.WriteLine($"Initial State of Door is {door._DoorState}");
    return new Door(passCode);
}

bool ChangePasscode()
{
    Console.Write("Enter current passcode: ");
    int currentPasscode = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter new passcode: ");
    int newPasscode = Convert.ToInt32(Console.ReadLine());
    if (door.ChangePasscode(currentPasscode, newPasscode))
    {
        Console.WriteLine("Passcode change was successful!");
        return true;
    }

    Console.WriteLine("Passcode change was NOT successful!");
    return false;
}

DoorState GetDoorState(Door door)
{
    return door._DoorState;
}




class Door
{
    public DoorState _DoorState { get; set; }

    private int _passcode;

    public Door(int passcode)
    {
        _passcode = passcode;
        _DoorState = DoorState.Closed;
    }

    public bool ChangePasscode(int currentPasscode, int newPasscode)
    {
        if (passcodeIsCorrect(currentPasscode))
        {
            _passcode = newPasscode;
            return true;
        }
        return false;            
    }

    private bool passcodeIsCorrect(int passcode) => _passcode == passcode;   

    // acceptable state is Doorstate.Closed
    public bool OpenDoor()
    {
        if (_DoorState == DoorState.Closed)
        {
            _DoorState = DoorState.Open;
            return true;
        }
        return false;
    }

    // acceptable state is DoorState.Open
    public bool CloseDoor()
    {
        if(_DoorState == DoorState.Open)
        {
            _DoorState = DoorState.Closed;
            return true;
        }
        return false;
    }

    // door must be closed
    public bool LockDoor()
    {
        if(_DoorState == DoorState.Closed)
        {
            _DoorState = DoorState.Locked;
            return true;
        }
        return false;
    }

    public bool UnlockDoor()
    {
        if(_DoorState == DoorState.Locked)
        {
            _DoorState = DoorState.Closed;
            return true;
        }
        return false;
    }
}

enum DoorState
{
    Open,
    Closed,
    Locked,
}