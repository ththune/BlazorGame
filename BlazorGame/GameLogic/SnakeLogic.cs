namespace BlazorGame.GameLogic;

public class SnakeLogic
{
    public LinkedList<(int Row, int Column)> Body { get; } = [];
    public Direction CurrentDirection { get; set; } = Direction.Right;

    public SnakeLogic(int startRow, int startColumn) => Body.AddFirst((startRow, startColumn));

    // Move the snake one step in the current direction.
    public void Move(bool grow = false)
    {
        if (Body.First == null) throw new InvalidOperationException("Snake body is empty.");

        // Get the current head position
        var head = Body.First.Value;

        // Calculate the new head position based on the current direction
        // and add it to the front of the body
        (int Row, int Column) newHead = CurrentDirection switch
        {
            Direction.Up => (head.Row - 1, head.Column),
            Direction.Down => (head.Row + 1, head.Column),
            Direction.Left => (head.Row, head.Column - 1),
            Direction.Right => (head.Row, head.Column + 1),
            _ => throw new ArgumentOutOfRangeException(nameof(CurrentDirection), CurrentDirection, null)
        };

        Body.AddFirst(newHead);

        // If not growing, remove the last segment of the snake, indicating it has moved
        if (!grow) Body.RemoveLast();
    }

    // Change the snake's direction if the new direction is valid
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

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}