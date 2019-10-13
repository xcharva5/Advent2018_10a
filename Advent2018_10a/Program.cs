using System;
using System.Collections.Generic;
using System.Linq;
using static Advent2018_10a.Star;

namespace Advent2018_10a
{
    class Program
    {
        


        static void Main(string[] args)
        {
            StarReader sr = new StarReader("../../../input.txt"); // 
            sr.LoadStarsFromFile();

            int i = 0;
            while(true)
            {
                ++i;
                if(sr.StarsAreClose(100))
                {
                    List<string> result = sr.Display();
                    foreach(string line in result)
                    {
                        Console.WriteLine(i + line);
                        System.Threading.Thread.Sleep(70);
                    }
                    
                }

                sr.Update();
            }
            
            

           



            Console.ReadLine();
        }
    }
}
