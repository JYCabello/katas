namespace GameOfLife;

public class Board
{
    private readonly bool[,] board;

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

        if (!isOnRightBorder)
            neigbors.Add(board[y, x + 1]);

        if (!isOnLeftBorder)
            neigbors.Add(board[y, x - 1]);

        if (!isOnBottomBorder)
            neigbors.Add(board[y + 1, x]);

        return neigbors.ToArray();
    }
}
