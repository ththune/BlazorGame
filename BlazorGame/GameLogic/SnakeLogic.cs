namespace BlazorGame.GameLogic;

public class SnakeLogic
{
    public LinkedList<(int Row, int Column)> Body { get; } = [];
    public Direction CurrentDirection { get; set; } = Direction.Right;

    public SnakeLogic(int startRow, int startColumn) => Body.AddFirst((startRow, startColumn));

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
            _ => throw new ArgumentOutOfRangeException(nameof(CurrentDirection))
        };

        Body.AddFirst(newHead);

        // If not growing, remove the last segment of the snake, indicating it has moved
        if (!grow) Body.RemoveLast();
    }
}

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}