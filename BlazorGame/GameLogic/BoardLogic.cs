namespace BlazorGame.GameLogic;

public class BoardLogic
{
    public int Rows { get; set; }
    public int Columns { get; set; }

    // Represents the game board as a 2D array of integers
    public int[,] Cells { get; set; }

    // Constructor
    public BoardLogic(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Cells = new int[rows, columns];
    }
    
    // Reset each cell to 0
    public void Reset()
    {
        for (var row = 0; row < Rows; row++)
        {
            for (var column = 0; column < Columns; column++)
            {
                Cells[row, column] = 0;
            }
        }
    }
}