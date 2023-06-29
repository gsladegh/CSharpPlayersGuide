/*
 *  Boss Battle The Color 100 XP
 *  
    The second pedestal asks you to create a Color class to represent a color. The pedestal includes an 
    etching of this diagram that illustrates its potential usage:
    The color consists of three parts or channels: red, green, and blue, which indicate how much those 
    channels are lit up. Each channel can be from 0 to 255. 0 means completely off; 255 means completely 
    on.

    The pedestal also includes some color names, with a set of numbers indicating their specific values for 
    each channel. These are commonly used colors: White (255, 255, 255), Black (0, 0, 0), Red (255, 0, 0), 
    Orange (255,165, 0), Yellow (255, 255, 0), Green (0, 128, 0), Blue (0, 0, 255), Purple (128, 0, 128).

    Objectives:

    • Define a new Color class with properties for its red, green, and blue channels.
    • Add appropriate constructors that you feel make sense for creating new Color objects.
    • Create static properties to define the eight commonly used colors for easy access.
    • In your main method, make two Color-typed variables. Use a constructor to create a color instance 
    and use a static property for the other. Display each of their red, green, and blue channel values.

 */

Color red = Color.Red;
Color blueish = new Color(0, 12, 240);

Console.WriteLine($"red: {red.R} {red.G} {red.B}");
Console.WriteLine($"bluish: {blueish.R} {blueish.G} {blueish.B}");

public class Color
{
    public int R { get; set; }
    public int G { get; set; }
    public int B { get; set; }

    public static Color White = new Color(255, 255, 255);
    public static Color Black = new Color(0, 0, 0);
    public static Color Red = new Color(255, 0, 0);
    public static Color Orange = new Color(255, 165, 0);
    public static Color Yellow = new Color(255, 255, 0);
    public static Color Green = new Color(0, 128, 0);
    public static Color Blue = new Color(0, 0, 255);
    public static Color Purple = new Color(128, 0, 128);

    public Color() : this(0, 0, 0) { }

    public Color(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }
}