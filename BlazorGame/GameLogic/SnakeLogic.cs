namespace BlazorGame.GameLogic;

public class SnakeLogic
{
    /// <summary> Represents the body of the snake as a linked list of (Row, Column) tuples. </summary>
    public LinkedList<Position> Body { get; } = [];

    /// <summary> Gets the current head position of the snake. </summary>
    public Position Head =>
        Body.First?.Value ?? throw new InvalidOperationException("Snake body is empty.");

    /// <summary> The current direction of the snake. </summary>
    public Direction CurrentDirection { get; set; } = Direction.Right;

    /// <summary> Constructor </summary>
    public SnakeLogic(int startRow, int startColumn) => Body.AddFirst(new Position(startRow, startColumn));

    /// <summary>
    ///  Moves the snake in the current direction.
    /// </summary>
    /// <param name="grow">True if the snake has eated food</param>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void Move(bool grow = false)
    {
        if (Body.First == null) throw new InvalidOperationException("Snake body is empty.");

        // Get the current head position
        var head = Body.First.Value;

        // Calculate the new head position based on the current direction
        // and add it to the front of the body
        Position newHead = CurrentDirection switch
        {
            Direction.Up => new Position(head.Row -1, head.Column),
            Direction.Down => new Position(head.Row + 1, head.Column),
            Direction.Left => new Position(head.Row, head.Column - 1),
            Direction.Right => new Position(head.Row, head.Column + 1),
            _ => throw new ArgumentOutOfRangeException(nameof(CurrentDirection), CurrentDirection, null)
        };

        Body.AddFirst(newHead);

        // If not growing, remove the last segment of the snake, indicating it has moved
        if (!grow) Body.RemoveLast();
    }

    /// <summary>
    ///  Changes the direction of the snake.
    /// </summary>
    /// <param name="newDirection"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void ChangeDirection(Direction newDirection)
    {
        // Ensure the new direction is not directly opposite to the current direction
        var canChangeDirection = newDirection switch
        {
            Direction.Up => CurrentDirection != Direction.Down,
            Direction.Down => CurrentDirection != Direction.Up,
            Direction.Left => CurrentDirection != Direction.Right,
            Direction.Right => CurrentDirection != Direction.Left,
            _ => throw new ArgumentOutOfRangeException(nameof(newDirection), newDirection, null)
        };

        if (!canChangeDirection) return;

        CurrentDirection = newDirection;
    }
}

/// <summary> Represents the possible directions the snake can move. </summary>
public enum Direction
{
    Up,
    Down,
    Left,
    Right
}