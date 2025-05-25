namespace BlazorGame.GameLogic;

public readonly struct Position : IEquatable<Position>
{
    /// <summary> Represents the row index of the position on the game board. </summary>
    public int Row { get; }

    /// <summary> Represents the column index of the position on the game board. </summary>
    public int Column { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Position"/> struct with specified row and column indices.
    /// </summary>
    public Position(int row, int column)
    {
        Row = row;
        Column = column;
    }

    /// <summary> Checks if the current position is equal to another position. </summary>
    public bool Equals(Position other) => Row == other.Row && Column == other.Column;
}