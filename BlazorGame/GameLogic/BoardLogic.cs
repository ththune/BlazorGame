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


    /// <summary>
    ///  Gets a list of empty cells on the board that are not occupied by the snake.
    /// </summary>
    /// <param name="snakeBody"></param>
    /// <returns></returns>
    public List<(int Row, int Column)> GetEmptyCells(LinkedList<(int Row, int Column)> snakeBody)
    {
        var emptyCells = new List<(int rows, int columns)>();
        for (var row = 0; row < Rows; row++)
        {
            for (var column = 0; column < Columns; column++)
            {
                if (!IsSnakeCell(row, column, snakeBody)) emptyCells.Add((row, column));
            }
        }

        return emptyCells;
    }

    //TODO: Should use Position intstead of (row, column)...
    /// <summary>
    ///  Check if the snake occupies the specified cell.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="column"></param>
    /// <param name="snakeBody"></param>
    /// <returns></returns>
    public static bool IsSnakeCell(int row, int column, IEnumerable<(int Row, int Column)> snakeBody) =>
        snakeBody.Any(cell => cell.Row == row && cell.Column == column);


    /// <summary>
    /// Check if food occupies the specified cell.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="column"></param>
    /// <param name="foodPosition"></param>
    /// <returns></returns>
    public static bool IsFoodCell(int row, int column, (int Row, int Column) foodPosition) =>
        foodPosition.Row == row && foodPosition.Column == column;
}