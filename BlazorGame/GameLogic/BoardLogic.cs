namespace BlazorGame.GameLogic;

public class BoardLogic
{
    /// <summary> Represents the number of rows in the game board. </summary>
    public int Rows { get; set; }

    /// <summary> Represents the number of columns in the game board. </summary>
    public int Columns { get; set; }


    /// <summary>
    ///  Initializes a new instance of the <see cref="BoardLogic"/> class with specified rows and columns.
    /// </summary>
    /// <param name="rows"></param>
    /// <param name="columns"></param>
    public BoardLogic(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
    }
}