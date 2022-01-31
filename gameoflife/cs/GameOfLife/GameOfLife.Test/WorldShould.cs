using Xunit;

namespace GameOfLife.Test;

public class WorldShould
{
    [Fact(DisplayName = "kill a single cell")]
    public void Test1()
    {
        var world = new World(new []
        {
            new [] { true }
        });
        var result = world.NextState();
        Assert.False(result[0][0]);
    }

    [Fact(DisplayName = "kill an isolated cell")]
    public void Test2()
    {
        var world = new World(new []
        {
            new [] { true, true }
        });
        var result = world.NextState();
        Assert.False(result[0][1]);
    }

    [Fact(DisplayName = "kill an isolated cell in a longer row")]
    public void Test3()
    {
        var world = new World(new []
        {
            new [] { false, true, false }
        });
        var result = world.NextState();
        Assert.False(result[0][1]);
    }

    [Fact(DisplayName = "keep a sustained cell in a longer row alive")]
    public void Test4()
    {
        var world = new World(new []
        {
            new [] { true, true, true }
        });
        var result = world.NextState();
        Assert.True(result[0][1]);
    }

}
