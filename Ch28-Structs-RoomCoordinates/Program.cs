/*
 * Challenge Room Coordinates 50 XP
 * 
    The time to enter the Fountain of Objects draws closer. While you don’t know what to expect, you have 
    found some scrolls that describe the area in ancient times. It seems to be structured as a set of rooms 
    in a grid-like arrangement. 

    Locations of the room may be represented as a row and column, and you take it upon yourself to try to 
    capture this concept with a new struct definition.

    Objectives:
    • Create a Coordinate struct that can represent a room coordinate with a row and column.
    • Ensure Coordinate is immutable.
    • Make a method to determine if one coordinate is adjacent to another (differing only by a single row 
    or column).
    • Write a main method that creates a few coordinates and determines if they are adjacent to each 
    other to prove that it is working correctly
 */

Coordinate firstCoordinate = new Coordinate(0, 0);
Coordinate secondCoordinate = new Coordinate(1, 0);
Coordinate thirdCoordinate = new Coordinate(2, 0);

Console.WriteLine($"Are adjacent? {IsAdjacent(firstCoordinate, secondCoordinate)}");
Console.WriteLine($"Are adjacent? {IsAdjacent(firstCoordinate, thirdCoordinate)}");

bool IsAdjacent(Coordinate coord1, Coordinate coord2) => (coord1.Row - coord2.Row <= 1 && coord1.Row - coord2.Row >= -1) && (coord1.Col - coord2.Col <= 1 && coord1.Col - coord2.Col >= -1);

public struct Coordinate
{
    public int Row { get; }
    public int Col { get; }

    public Coordinate(int row, int col) 
    {
        Row = row;
        Col = col;
    }    
}

