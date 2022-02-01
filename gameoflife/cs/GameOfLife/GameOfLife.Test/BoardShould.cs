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

    [Fact(DisplayName = "gets one neighbor on the right")]
    public void Test02()
    {
        var board = new Board(new[,] { { true, false } });
        var result = board.GetNeighbors(0, 0);
        Assert.Single(result);
        Assert.False(result[0]);
    }

    [Fact(DisplayName = "gets one neighbor on the left")]
    public void Test03()
    {
        var board = new Board(new[,] { { true, false } });
        var result = board.GetNeighbors(0, 1);
        Assert.Single(result);
        Assert.True(result[0]);
    }
}
