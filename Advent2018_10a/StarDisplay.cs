using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2018_10a
{
    class StarDisplay
    {
        StarReader Reader { get; set; }
        bool AlreadyDisplayed { get; set; }
        int Iteration { get; set; }

        public StarDisplay(StarReader sr)
        {
            Reader = sr;
            AlreadyDisplayed = false;
            Iteration = 0;
        }

        public void DispalyStars()
        {
            while (true)
            {
                if (Reader.StarsAreClose(100))
                {
                    List<string> result = Reader.Display();
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
                Reader.Update();
            }

            Console.WriteLine("You've seen everything you needed");
            Console.ReadLine();
        }
    }
}
