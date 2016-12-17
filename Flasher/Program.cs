using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flasher
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("USAGE: flasher.exe <flashcardfile>");
                return;
            }

            var flashCardFile = args[0];
            if (!File.Exists(flashCardFile))
            {
                Console.WriteLine($"File not found '{flashCardFile}'");
                return;
            }

            var cards = File.ReadAllLines(flashCardFile).Select(l => l.Trim()).Where(l => !String.IsNullOrEmpty(l) && !l.StartsWith("#")).ToArray();
            if (cards.Length == 0)
            {
                Console.WriteLine("No cards in file. Each card must be placed on its own line.");
                return;
            }

            Console.WriteLine($"{cards.Length} cards found. Press enter to start, then enter to get a new card. Press 'q' to quit.");
            Console.ReadKey();

            var rand = new Random(DateTime.Now.Millisecond);
            do
            {
                Console.Clear();
                Console.WriteLine(cards[rand.Next(cards.Length)]);
            }
            while (Console.ReadKey().KeyChar != 'q');
        }
    }
}
