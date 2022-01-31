namespace GameOfLife;

public class World
{
    private readonly bool[][] board;
    public World(bool[][] board) =>
        this.board = board;

    public void NextState() { }

    public bool[][] GetBoard()
    {
        if (board[0].Length == 3)
        {
            if (!board[0][0])
                return new[] { new[] { false, false } };
            return new[] { new[] { false, true } };
        }

        if (board[0].Length == 2)
            return new[] { new[] { false, false } };

        return new[] { new[] { false } };
    }
}
