namespace GameOfLife;

public class Board
{
    private readonly bool[,] board;

    public int Height => board.GetLength(0);
    public int Width => board.GetLength(1);

    public bool IsAlive(int y, int x) => board[y, x];

    public Board(bool[,] board) =>
        this.board = board;

    public bool[] GetNeighbors(int y, int x)
    {
        var height = board.GetLength(0);
        var width = board.GetLength(1);
        var neigbors = new List<bool>();

        var isOnRightBorder = width == x + 1;
        var isOnLeftBorder = x == 0;
        var isOnBottomBorder = height == y + 1;
        var isOnTopBorder = y == 0;

        if (!isOnRightBorder)
            neigbors.Add(board[y, x + 1]);

        if (!isOnLeftBorder)
            neigbors.Add(board[y, x - 1]);

        if (!isOnBottomBorder)
            neigbors.Add(board[y + 1, x]);

        if (!isOnTopBorder)
            neigbors.Add(board[y - 1, x]);

        if (!isOnLeftBorder && !isOnTopBorder)
            neigbors.Add(board[y - 1, x - 1]);

        if (!isOnRightBorder && !isOnTopBorder)
            neigbors.Add(board[y - 1, x + 1]);

        if (!isOnRightBorder && !isOnBottomBorder)
            neigbors.Add(board[y + 1, x + 1]);

        if (!isOnLeftBorder && !isOnBottomBorder)
            neigbors.Add(board[y + 1, x - 1]);

        return neigbors.ToArray();
    }

    public void Process(Action<bool[,], Board> action) =>
        action(board, this);
}
