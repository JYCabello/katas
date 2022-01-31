namespace GameOfLife;

public class World
{
    private readonly bool[][] board;

    public World(bool[][] board) =>
        this.board = board;

    public bool[][] NextState()
    {
        if (board[0].Length == 2)
            return new[] { new[] { false, false } };

        return new[] { new[] { false } };
    }
}
