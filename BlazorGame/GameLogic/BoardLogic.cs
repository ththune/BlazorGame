﻿namespace BlazorGame.GameLogic;

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
    public List<Position> GetEmptyCells(LinkedList<Position> snakeBody)
    {
        var emptyCells = new List<Position>();
        for (var row = 0; row < Rows; row++)
        {
            for (var column = 0; column < Columns; column++)
            {
                if (!IsSnakeCell(new Position(row, column), snakeBody))
                {
                    emptyCells.Add(new Position(row, column));
                }
            }
        }

        return emptyCells;
    }

    public bool CheckCollision(LinkedList<Position> snakeBody)
    {
        if (snakeBody.First == null) throw new InvalidOperationException("Snake body is empty.");

        var head = snakeBody.First.Value;

        var isWallCollision = head switch
        {
            { Row: < 0 } => true,
            { Row: var row } when row >= Rows => true,
            { Column: < 0 } => true,
            { Column: var column } when column >= Columns => true,
            _ => false
        };

        // Check if the snake collides with the wall
        // or if the snake collides with itself (ignoring the head)
        return isWallCollision ||
               snakeBody.Skip(1).Any(body => body.Equals(head));
    }

    /// <summary>
    ///  Check if the snake occupies the specified cell.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="snakeBody"></param>
    /// <returns></returns>
    public static bool IsSnakeCell(Position position, IEnumerable<Position> snakeBody) =>
        snakeBody.Any(cell => cell.Equals(position));


    /// <summary>
    /// Check if food occupies the specified cell.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="foodPosition"></param>
    /// <returns></returns>
    public static bool IsFoodCell(Position position, Position foodPosition) => foodPosition.Equals(position);
}