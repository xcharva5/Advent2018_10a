namespace Advent2018_10a
{
    class Program
    {
        static void Main(string[] args)
        {            
            StarProcessor sp = new StarProcessor("../../../input.txt");
            StarDisplay sd = new StarDisplay(sp);

            sp.LoadStarsFromFile();
            sd.DisplayStars();           
        }
    }
    
}
