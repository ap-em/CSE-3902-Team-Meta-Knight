using System;

namespace Sprint0
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {

            using (var game = new Game0())
                Game0.Instance.Run();
               // game.Run();
        }
    }
}
