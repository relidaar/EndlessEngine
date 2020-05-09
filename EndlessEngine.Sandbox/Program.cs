namespace EndlessEngine.Sandbox
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game(800, 600, "Sample Game");
            game.Run();
        }
    }
}