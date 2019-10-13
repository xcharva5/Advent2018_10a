using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2018_10a
{
    class StarDisplay
    {
        StarProcessor Processor { get; set; }
        bool AlreadyDisplayed { get; set; }
        int Iteration { get; set; }

        public StarDisplay(StarProcessor sr)
        {
            Processor = sr;
            AlreadyDisplayed = false;
            Iteration = 0;
        }

        public void DisplayStars()
        {
            while (true)
            {
                if (Processor.StarsAreClose(100))
                {
                    List<string> result = Processor.GenerateView();
                    foreach (string line in result)
                    {
                        Console.WriteLine("{0} {1}", Iteration, line);
                        System.Threading.Thread.Sleep(50);
                    }
                    AlreadyDisplayed = true;
                }
                else if (AlreadyDisplayed)
                {
                    break;
                }

                Iteration++;
                Processor.Update();
            }

            Console.WriteLine("You've seen everything you needed");
            Console.ReadLine();
        }
    }
}
