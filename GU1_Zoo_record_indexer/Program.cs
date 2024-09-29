namespace GU1_Zoo_record_indexer;

class Program
{
        static void Main()
        {
                var zooSmall = new rcZoo("Small zoo", 5);
                var zooLarge = new rcZoo("Large zoo", 25);

                Console.WriteLine(zooSmall);
                Console.WriteLine(zooLarge);

                var biggestZoo = new rcZoo();
                Console.WriteLine(biggestZoo);

                // Här använder vi våran
                Console.WriteLine(biggestZoo[62]);
        }
}