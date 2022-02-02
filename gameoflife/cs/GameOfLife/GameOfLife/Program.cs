// See https://aka.ms/new-console-template for more information

using System.Text;
using GameOfLife;

var world = new World(new [,]
{
    { true, false, true, false, false },
    { false, true, false, false, false },
    { true, false, true, false, false },
    { false, false, false, true, false },
    { false, false, false, false, true }
});

void Render(Board board)
{
    var output = new StringBuilder();
    for (var y = 0; y < board.Height; y++)
    {
        for (var x = 0; x < board.Width; x++)
            output.Append(board.IsAlive(x, y) ? "██" : "  ");

        output.Append(Environment.NewLine);
    }
    Console.Write(output.ToString());
}

while (true)
{
    world.Process(Render);
    Thread.Sleep(1000);
    Console.Clear();
    world.NextState();
}
