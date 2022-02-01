using Xunit;

namespace GameOfLife.Test;

public class BoardShould
{
    [Fact(DisplayName = "get no neighbors for a single cell")]
    public void Test01()
    {
        var board = new Board(new[,] { { true } });
        var result = board.GetNeighbors(0, 0);
        Assert.Empty(result);
    }
}
