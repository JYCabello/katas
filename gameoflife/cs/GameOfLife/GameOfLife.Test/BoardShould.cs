using System.Linq;
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

    [Fact(DisplayName = "get one neighbor on the right")]
    public void Test02()
    {
        var board = new Board(new[,] { { true, false } });
        var result = board.GetNeighbors(0, 0);
        Assert.Single(result);
        Assert.False(result[0]);
    }

    [Fact(DisplayName = "get one neighbor on the left")]
    public void Test03()
    {
        var board = new Board(new[,] { { true, false } });
        var result = board.GetNeighbors(0, 1);
        Assert.Single(result);
        Assert.True(result[0]);
    }

    [Fact(DisplayName = "get one neighbor below")]
    public void Test04()
    {
        var board = new Board(new[,]
        {
            { true },
            { false }
        });
        var result = board.GetNeighbors(0, 0);
        Assert.Single(result);
        Assert.False(result[0]);
    }

    [Fact(DisplayName = "get one neighbor above")]
    public void Test05()
    {
        var board = new Board(new[,]
        {
            { true },
            { false }
        });
        var result = board.GetNeighbors(1, 0);
        Assert.Single(result);
        Assert.True(result[0]);
    }

    [Fact(DisplayName = "get top left neighbor")]
    public void Test06()
    {
        var board = new Board(new[,]
        {
            { true, false },
            { false, false }
        });
        var result = board.GetNeighbors(1, 1);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result.Count(b => b));
    }

    [Fact(DisplayName = "get top right neighbor")]
    public void Test07()
    {
        var board = new Board(new[,]
        {
            { false, true },
            { false, false }
        });
        var result = board.GetNeighbors(1, 0);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result.Count(b => b));
    }

    [Fact(DisplayName = "get bottom right neighbor")]
    public void Test08()
    {
        var board = new Board(new[,]
        {
            { false, false },
            { false, true }
        });
        var result = board.GetNeighbors(0, 0);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result.Count(b => b));
    }
}
